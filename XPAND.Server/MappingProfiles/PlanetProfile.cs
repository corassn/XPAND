using AutoMapper;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;

namespace XPAND.Server.MappingProfiles
{
    public class PlanetProfile : Profile
    {
        public PlanetProfile()
        {
            CreateMap<Planet, UpdatePlanetDto>()
                    .ForMember(dest => dest.PlanetId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId))
                    .ReverseMap();

            CreateMap<Planet, PlanetDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                    .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId))
                    .ReverseMap();

            CreateMap<Planet, AddPlanetDto>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                    .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId))
                    .ReverseMap();
        }
    }
}
