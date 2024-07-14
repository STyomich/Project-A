using System.Collections;
using Core.Enums;

namespace Core.Domain.Entities
{
    public class Anime
    {
        public Guid Id { get; set; }
        public Guid StudioId { get; set; }
        public string? Picture { get; set; }
        public string? Title { get; set; }
        public string? TitleInJapanese { get; set; }
        public string Type { get; set; } = TypeOfAnimeEnum.Undefined.ToString();
        public string? AnimeState { get; set; } = AnimeStateEnum.Undefined.ToString();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReleasedEpisodes { get; set; } = 0;
        public int ExpectedEpisodes { get; set; } = 1;
        public string OriginalSource { get; set; } = OriginalSourceEnum.Undefined.ToString();
        public string Description { get; set; } = "No information";
        public string? AdminsNote { get; set; }
        public Studio? Studio { get; set; }
        public ChronologyElement? ChronologyElement { get; set; }
        public ICollection<GenrePin>? GenrePins { get; set; }
        public ICollection<Episode>? Episodes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<AnimePin>? AnimePins { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}