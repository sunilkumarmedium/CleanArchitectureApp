using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using FluentValidation;

namespace CleanArchitectureApp.Application.Features.Users.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {

        private readonly IUserStatusRepositoryAsync _userStatusRepository;
        public UpdateUserCommandValidator(IUserStatusRepositoryAsync userStatusRepository)
        {
            _userStatusRepository = userStatusRepository;
            RuleFor(p => p.UserStatus)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MustAsync(IsValidUserStatus).WithMessage("{PropertyName} not exists.");

        }

        private async Task<bool> IsValidUserStatus(int UserStatus, CancellationToken cancellationToken)
        {
            var userStatus = (await _userStatusRepository.FindByCondition(x => x.UserStatusId == UserStatus).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            if (userStatus != null)
            {
                return true;
            }
            return false;
        }
    }
}