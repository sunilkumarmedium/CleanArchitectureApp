namespace CleanArchitectureApp.WebApi.Controllers.V1
{
    using System.Threading.Tasks;
    using CleanArchitectureApp.Application.Features.Users.Commands;
    using CleanArchitectureApp.Application.Features.Users.Queries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Authorize]
    public class UserController : BaseApiController
    {
        [HttpPost("CreateUser")]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(GetAllUsersQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost("GetUserById")]
        public async Task<IActionResult> GetUserById(GetUserByIdQuery command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPut("UpdateUserById")]
        public async Task<IActionResult> UpdateUserById(UpdateUserCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
