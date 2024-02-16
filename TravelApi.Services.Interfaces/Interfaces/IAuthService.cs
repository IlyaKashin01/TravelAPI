using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Auth;

namespace TravelApi.Services.Interfaces.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request);
        Task<OperationResult<int>> SingupAsync(SignupRequest request);
        Task<OperationResult<string>> SendingAuthCodeByEmailAsync(string token);
        Task<OperationResult<string>> SengingVerificationCodeAsync(string token);
        Task<OperationResult<bool>> TwoStageAuthenticateAsync(string token, string authCode);
        Task<OperationResult<bool>> VerificationAsync(string token, string verificationCode);
    }
}
