using AutoMapper;
using XPAND.Server.Models.DTOs;
using XPAND.Server.Models;

namespace XPAND.Server.MappingProfiles
{
    public class RobotProfile : Profile
    {
        public RobotProfile()
        {
            CreateMap<Robot, RobotDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ReverseMap();
        }
    }
}
