using AutoMapper;
using Sat.Recruitment.Business.Dtos;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReponseDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }

    }
}
