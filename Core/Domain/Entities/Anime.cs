using Core.Enums;

namespace Core.Domain.Entities
{
    public class Anime
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? TitleInJapanese { get; set; }
        public string Type { get; set; } = TypeOfAnimeEnum.Undefined.ToString();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Studio { get; set; }
        public int AmountOfEpisodes { get; set; } = 1;
        public string OriginalSource { get; set; } = OriginalSourceEnum.Undefined.ToString();
        public ICollection<GenrePin> GenrePins {get;set;}
    }
}