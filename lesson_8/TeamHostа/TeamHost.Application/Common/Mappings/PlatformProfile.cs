using AutoMapper;
using TeamHost.Application.Features.Games.DTOs;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Common.Mappings
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformDto>()
                .ForMember(dest => dest.ImagePath,
                    opt => opt.MapFrom(src => src.Image.Path));
        }
    }
}
