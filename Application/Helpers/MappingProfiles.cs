using AutoMapper;
using Core.Domain.Entities;
using Core.DTO.Entities;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Anime, Anime>();
            CreateMap<Anime, AnimeDto>();

            CreateMap<Studio, Studio>();
            CreateMap<Studio, StudioDto>();

            CreateMap<VoiceCast, VoiceCast>();
            CreateMap<VoiceCast, VoiceCastDto>();
            CreateMap<VoiceCastPin, VoiceCastPin>();
            CreateMap<VoiceCastPin, VoiceCastPinDto>();

            CreateMap<Episode, Episode>();
            CreateMap<Episode, EpisodeDto>();
        }
    }
}