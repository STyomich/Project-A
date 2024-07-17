namespace Core.Domain.Entities
{
    public class VoiceCast
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<Episode>? Episodes { get; set; }
    }
}