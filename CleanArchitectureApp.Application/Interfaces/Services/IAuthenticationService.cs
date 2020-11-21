using CleanArchitectureApp.Application.DTOs.Authentication;
using CleanArchitectureApp.Application.Wrappers;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<AuthenticationResponse>> RefreshTokenAsync(RefreshTokenRequest request, string ipAddress);
        Task<Response<string>> RevokeTokenAsync(RevokeTokenRequest request, string ipAddress);
        Task<Response<string>> ForgotPassword(ForgotPasswordRequest request);

        Task<Response<string>> ResetPassword(ResetPasswordRequest request);
    }
}