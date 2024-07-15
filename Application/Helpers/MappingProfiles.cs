using AutoMapper;
using Core.Domain.Entities;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Anime, Anime>();
            CreateMap<Studio, Studio>();
        }
    }
}