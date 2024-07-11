namespace Core.Domain.Entities
{
    public class GenrePin
    {
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
        public Guid AnimeId { get; set; }
        public Anime? Anime { get; set; }
    }
}