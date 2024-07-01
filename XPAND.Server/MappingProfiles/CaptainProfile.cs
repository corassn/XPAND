using XPAND.Server.Models.DTOs;
using XPAND.Server.Models;
using AutoMapper;

namespace XPAND.Server.MappingProfiles
{
    public class CaptainProfile : Profile
    {
        public CaptainProfile()
        {
            CreateMap<Captain, CaptainDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ReverseMap();
        }
    }
}
