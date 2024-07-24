namespace Core.DTO.Entities
{
    public class ChronologyElementDto
    {
        public Guid Id { get; set; }
        public Guid ChronologyId { get; set; }
        public Guid AnimeId { get; set; }
        public int Index { get; set; }
        public AnimeDto? Anime { get; set; }
    }
}