using XPAND.Server.Models.DTOs;
using XPAND.Server.Models;
using AutoMapper;

namespace XPAND.Server.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.CaptainId, opt => opt.MapFrom(src => src.CaptainId))
                    .ForMember(dest => dest.RobotIds, opt => opt.MapFrom(src => src.RobotIds))
                    .ReverseMap();
        }
    }
}