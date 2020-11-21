using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Wrappers;
using CleanArchitectureApp.Domain;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<Response<Guid>>
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public int UserStatus { get; set; }
        public Guid UpdatedBy { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<Guid>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserStatusRepositoryAsync _userStatusRepository;

        public UpdateUserCommandHandler(IUserRepositoryAsync userRepository, IUserStatusRepositoryAsync userStatusRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userStatusRepository = userStatusRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.UpdatedDate = DateTime.UtcNow;
            user.UserStatuses = (await _userStatusRepository.FindByCondition(x => x.UserStatusId == request.UserStatus).ConfigureAwait(false)).AsQueryable().FirstOrDefault();

            var userObject = await _userRepository.AddAsync(user).ConfigureAwait(false);
            return new Response<Guid>(userObject.UserId);
        }
    }
}