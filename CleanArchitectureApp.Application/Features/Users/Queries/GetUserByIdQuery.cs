using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureApp.Application.DTOs.User;
using CleanArchitectureApp.Application.Interfaces.Repositories;
using CleanArchitectureApp.Application.Wrappers;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<Response<UserViewModel>>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<UserViewModel>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepositoryAsync userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Response<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userObject = (await _userRepository.FindByCondition(x => x.UserId.Equals(request.UserId)).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
            return new Response<UserViewModel>(_mapper.Map<UserViewModel>(userObject));
        }
    }
}