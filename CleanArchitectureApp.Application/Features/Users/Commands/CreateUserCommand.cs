using AutoMapper;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Interfaces.Services;
using CleanArchitectureApp.Application.Wrappers;
using CleanArchitectureApp.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Users.Commands
{
    public partial class CreateUserCommand : IRequest<Response<Guid>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public Guid CreatedBy { get; set; }

    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<Guid>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _PasswordService;
        private readonly IUserStatusRepositoryAsync _userStatusRepository;
        public CreateUserCommandHandler(IUserRepositoryAsync userRepository, IMapper mapper, IPasswordService passwordService, IUserStatusRepositoryAsync userStatusRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _PasswordService = passwordService;
            _userStatusRepository = userStatusRepository;
        }
        public async Task<Response<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.CreatedDate = DateTime.UtcNow;
            user.UserStatuses = (await _userStatusRepository.FindByCondition(x => x.StatusValue.ToLower() == "active").ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            string passwordHash, passwordSalt;
            _PasswordService.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var userObject = await _userRepository.AddAsync(user).ConfigureAwait(false);
            return new Response<Guid>(userObject.UserId);
        }
    }

}
