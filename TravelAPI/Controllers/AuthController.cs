using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Auth;
using TravelApi.Services.Interfaces.Interfaces;

namespace TravelAPI.Controllers
{
    [Route ("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ISettingsService _settingsService;

        public AuthController(IAuthService authService, ISettingsService settingsService)
        {
            _authService = authService;
            _settingsService = settingsService;
        }

        [HttpPost("signin"), AllowAnonymous]
        public async Task<ActionResult<OperationResult<AuthResponse>>> SigninAsync(AuthRequest request)
        {
            var response = await _authService.AuthenticateAsync(request);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("signup"), AllowAnonymous]
        public async Task<ActionResult<OperationResult<AuthResponse>>> SignupAsync(SignupRequest request)
        {
            var response = await _authService.SingupAsync(request);
            if (response.Success) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("twosignin"), Authorize]
        public async Task<ActionResult<OperationResult<bool>>> TwoSigninAsync (string authCode)
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _authService.TwoStageAuthenticateAsync(authHeader.Substring("Bearer ".Length), authCode);
                if (response.Success) return Ok(response);
                else return BadRequest(response);
            }
            
            return BadRequest("Fail authentication");
        }

        [HttpPost("resendingcode"), Authorize]
        public async Task<ActionResult<OperationResult<string>>> ResendingAuthenticationCodeAsync()
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _authService.SendingAuthCodeByEmailAsync(authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
                return BadRequest(response);
            }

            return BadRequest("Fail authentication");
        }

        [HttpPost("sendingcode"), Authorize]
        public async Task<ActionResult<OperationResult<string>>> SendingVerificationCodeAsync()
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _authService.SengingVerificationCodeAsync(authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
                return BadRequest(response);
            }

            return BadRequest("Fail authentication");
        }

        [HttpPut("verification"), Authorize]
        public async Task<ActionResult<OperationResult<string>>> VericationPersonDataAsync()
        {
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var response = await _authService.VerificationAsync(authHeader.Substring("Bearer ".Length));
                if (response.Success) return Ok(response);
                return BadRequest(response);
            }
            return BadRequest("Fail authentication");
        }
    } 
}
