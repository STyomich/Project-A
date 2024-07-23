using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.IdentityEntities;
using Core.DTO.Entities;
using Core.DTO.Identity;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Anime, Anime>();
            CreateMap<Anime, AnimeDto>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.GenrePins.Select(gp => gp.Genre)));

            CreateMap<Studio, Studio>();
            CreateMap<Studio, StudioDto>();

            CreateMap<VoiceCast, VoiceCast>();
            CreateMap<VoiceCast, VoiceCastDto>();
            CreateMap<VoiceCastPin, VoiceCastPin>();
            CreateMap<VoiceCastPin, VoiceCastPinDto>();

            CreateMap<Episode, Episode>();
            CreateMap<Episode, EpisodeDto>();

            CreateMap<UserSetting, UserSetting>();
            CreateMap<UserSetting, UserSettingDto>();
            CreateMap<UserSettingDto, UserSetting>();

            CreateMap<Genre, Genre>();
            CreateMap<Genre, GenreDto>();

            CreateMap<Comment, Comment>();
            CreateMap<Comment, CommentDto>();

            CreateMap<ApplicationUser, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}