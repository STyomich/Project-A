namespace Core.Domain.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<GenrePin>? GenrePins {get;set;}
    }
}