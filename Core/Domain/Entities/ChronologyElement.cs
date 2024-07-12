namespace Core.Domain.Entities
{
    public class ChronologyElement
    {
        public Guid Id { get; set; }
        public Guid ChronologyId { get; set; }
        public Guid AnimeId { get; set; }
        public int Index { get; set; } = 1;
        public Chronology? Chronology { get; set; }
        public Anime? Anime { get; set; }
    }
}