using AngleSharp.Common;
using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TravelApi.Common.Auth;
using TravelApi.Common.Email;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Services.Interfaces.DTO.Auth;
using TravelApi.Services.Interfaces.DTO.Person;
using TravelApi.Services.Interfaces.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace TravelApi.Infrastructure.Business
{
    public class AuthService : IAuthService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMapper _mapper;
        private readonly AuthOptions _authOptions;
        private readonly EmailOptions _emailOptions;
        private static ConcurrentDictionary<int, string> _verificationCode = new ConcurrentDictionary<int, string>();
        public AuthService(IPersonRepository personRepository, IMapper mapper, IOptions<AuthOptions> authOptions, IOptions<EmailOptions> emailOptions, IImageRepository imageRepository, ISettingsRepository settingsRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _authOptions = authOptions.Value;
            _emailOptions = emailOptions.Value;
            _imageRepository = imageRepository;
            _settingsRepository = settingsRepository;
        }

        public async Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request)
        {
            var person = await _personRepository.GetPersonByLoginAsync(request.Login);

            if (person == null)
                return OperationResult<AuthResponse>.Fail(
                    OperationCode.Unauthorized,
                    $"Пользователь с логином {request.Login} не зарегистрирован");

            if(BC.Verify(request.Password, person.PasswordHash))
            {
                var token = GenerateJwtTokenAsync(person);
                var data = new AuthResponse
                {
                    Person = _mapper.Map<PersonResponse>(person),
                    Token = token
                };
                var response = new OperationResult<AuthResponse>(data);
                var setting = await _settingsRepository.GetSettingByPersonAsync(person.Id, "Двухэтапная аутентификация");
                if (setting != null && setting.Status)
                {
                    var emailResponse = await SendingAuthCodeByEmailAsync(token);
                    if (!emailResponse.Success)
                    {
                        response.ErrorCode = emailResponse.ErrorCode;
                        response.Message = emailResponse.Message;
                        return response;
                    }
                }

                return response;
            }
            return OperationResult<AuthResponse>.Fail(OperationCode.ValidationError, "Неверный пароль");
        }

        public async Task<OperationResult<int>> SingupAsync(SignupRequest request)
        {
            if (await _personRepository.GetPersonByLoginAsync(request.Login) is not null)
                return OperationResult<int>.Fail(
                    OperationCode.AlreadyExists,
                    $"Пользователь с логином {request.Login} уже существует");

            var person = _mapper.Map<Person>(request);

            person.CreatedDate = DateTime.UtcNow;
            person.PasswordHash = BC.HashPassword(request.Password);
            person.Role = "user";
            var result = await _personRepository.CreateAsync(person);

            return new OperationResult<int>(result);
        }

        public async Task<OperationResult<string>> SendingAuthCodeByEmailAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            if (tokenS != null) {
                string personId = tokenS.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").Value;
                var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                if (person is not null)
                {
                    return await SendEmailMessageAsync(person, false);
                }
            }
            return OperationResult<string>.Fail(OperationCode.Unauthorized, "Пользователь не авторизован");
        }

        public async Task<OperationResult<string>> SengingVerificationCodeAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            if (tokenS != null)
            {
                string personId = tokenS.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").Value;
                var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                if (person is not null)
                {
                    return await SendEmailMessageAsync(person, true);
                }
            }
            return OperationResult<string>.Fail(OperationCode.Unauthorized, "Пользователь не авторизован");
        }

        public async Task<OperationResult<bool>> VerificationAsync(string token, string verificationCode)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            if (tokenS != null)
            {
                string personId = tokenS.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").Value;
                var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                if (person is not null)
                {
                    _verificationCode.TryGetValue(person.Id, out var key);
                    if(key == verificationCode)
                    {
                        person.IsVerified = true;
                        person.Verified = DateTime.UtcNow;
                        var result = await _personRepository.UpdatePersonAsync(person);
                        if (result) return new OperationResult<bool>(result);
                        else return OperationResult<bool>.Fail(OperationCode.Error, "Ошибка обновления данных пользователя в БД");
                    }
                    else return OperationResult<bool>.Fail(OperationCode.ValidationError, "Неверный код двухфакторной авторизации");
                }
                else return OperationResult<bool>.Fail(OperationCode.EntityWasNotFound, "Не существует пользователя, для которого запрашивается подтверждение данных");
            }
            else
                return OperationResult<bool>.Fail(OperationCode.Unauthorized, "Ошибка при чтении токена");
        }
        public async Task<OperationResult<bool>> TwoStageAuthenticateAsync(string token, string authCode)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            if (tokenS != null)
            {
                string personId = tokenS.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").Value;
                var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                if (person is not null)
                {
                    if (person.IsVerified)
                    {
                        _verificationCode.TryGetValue(person.Id, out var key);
                        if (key != "" && key == authCode)
                        {
                            _verificationCode.Remove(person.Id, out _);
                            return new OperationResult<bool>(true);
                        }
                        else
                            return OperationResult<bool>.Fail(OperationCode.Error, "Неверный код двухфакторной авторизации");
                    }
                    return OperationResult<bool>.Fail(OperationCode.Error, "Данные пользователя не подтверждены");
                }
                return OperationResult<bool>.Fail(OperationCode.EntityWasNotFound, "Данные пользователя не найдены, возможно неправильный jwt токен");
            }
            return OperationResult<bool>.Fail(OperationCode.Unauthorized, "Пользователь не авторизован");
        }

        private string GenerateJwtTokenAsync(Person person)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Sid, person.Id.ToString()),
                new Claim(ClaimTypes.Role, person!.Role)
            };
            var jwt = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_authOptions.TokenLifeTime),  // действие токена истекает через 7 дней
                signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private async Task<OperationResult<string>> SendEmailMessageAsync(Person person, bool isVerifidedEmail)
        {
            Random random = new Random();
            int[] numbers = new int[6];
            string key = "";
            for (int i = 0; i < 6; i++)
            {
                numbers[i] = random.Next(1, 9);
                key += numbers[i].ToString();
            }
            if (_verificationCode.AddOrUpdate(person.Id, key, (id, key) => key) == "")
                return OperationResult<string>.Fail(OperationCode.Error, "Код не был сохранен в памяти");
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("TravelPlanner", _emailOptions.Email));
            emailMessage.To.Add(new MailboxAddress("", person.Email));
            if (isVerifidedEmail)
            {
                emailMessage.Subject = "Подтверждение данных для приложения TravelPlanner";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = $"Ваш код для подтверждения email и телефона в приложении TravelPlanner {key}. Никому его не сообщайте."
                };
            }
            else
            {
                emailMessage.Subject = "Двухэтапная аутентификация в приложении TravelPlanner";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = $"Ваш код для авторизации в приложении TravelPlanner {key}. Никому его не сообщайте."
                };
            }
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync(_emailOptions.Email, _emailOptions.Password);
                if (client.IsAuthenticated) await client.SendAsync(emailMessage);
                else return OperationResult<string>.Fail(OperationCode.Unauthorized, "Ошибка авторизации Email");
                await client.DisconnectAsync(true);
            }
            return new OperationResult<string>($"Сообщение отправлено пользователю на email: {person.Email}");
        }
    }
}
