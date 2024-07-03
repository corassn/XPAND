using AutoMapper;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;

namespace XPAND.Server.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<LoginDto, AppUser>().ReverseMap();
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
