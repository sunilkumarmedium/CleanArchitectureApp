using AutoMapper;
using CleanArchitectureApp.Application.DTOs.User;
using CleanArchitectureApp.Application.Features.Users.Commands;
using CleanArchitectureApp.Domain;

namespace CleanArchitectureApp.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.UserStatus, opt => opt.MapFrom(x => x.UserStatuses.StatusValue))
                .ReverseMap();
        }
    }
}
