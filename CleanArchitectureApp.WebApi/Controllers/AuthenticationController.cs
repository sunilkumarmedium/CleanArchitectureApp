namespace CleanArchitectureApp.WebApi.Controllers
{
    using CleanArchitectureApp.Application.DTOs.Authentication;
    using CleanArchitectureApp.Application.Interfaces.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return this.Ok(await this.authenticationService.AuthenticateAsync(request, this.GenerateIPAddress()));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest tokenRequest)
        {
            return this.Ok(await this.authenticationService.RefreshTokenAsync(tokenRequest, this.GenerateIPAddress()));
        }

        [AllowAnonymous]
        [HttpPost("revoke-token")]
        public async Task<ActionResult> RevokeToken([FromBody] RevokeTokenRequest revoketoken)
        {
            return this.Ok(await this.authenticationService.RevokeTokenAsync(revoketoken, this.GenerateIPAddress()));
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordRequest forgotPasswordModel)
        {
            return this.Ok(await this.authenticationService.ForgotPassword(forgotPasswordModel));
        }

        private string GenerateIPAddress()
        {
            if (this.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return this.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return this.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}