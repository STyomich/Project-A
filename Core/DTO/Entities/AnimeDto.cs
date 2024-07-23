using Core.Domain.Entities;
using Core.Enums;

namespace Core.DTO.Entities
{
    public class AnimeDto
    {
        public Guid Id { get; set; }
        public Guid StudioId { get; set; }
        public string? Picture { get; set; }
        public string? TitleInEnglish { get; set; }
        public string? TitleInJapanese { get; set; }
        public string? TitleInUkrainian { get; set; }
        public string? TitleInRussian { get; set; }
        public string Type { get; set; } = TypeOfAnimeEnum.Undefined.ToString();
        public string? AnimeState { get; set; } = AnimeStateEnum.Undefined.ToString();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReleasedEpisodes { get; set; } = 0;
        public int ExpectedEpisodes { get; set; } = 1;
        public string OriginalSource { get; set; } = OriginalSourceEnum.Undefined.ToString();
        public string Description { get; set; } = "No information";
        public string? AdminsNote { get; set; }
        public StudioDto? Studio { get; set; }
        public ICollection<EpisodeDto>? Episodes { get; set; }
        public ICollection<GenreDto>? Genres { get; set; }
        public ICollection<CommentDto>? Comments { get; set; }
    }
}