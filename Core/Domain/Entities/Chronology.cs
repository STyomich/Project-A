namespace Core.Domain.Entities
{
    public class Chronology
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<ChronologyElement>? ChronologyElements { get; set; }
    }
}