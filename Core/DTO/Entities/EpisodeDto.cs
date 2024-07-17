namespace Core.DTO.Entities
{
    public class EpisodeDto
    {
        public Guid Id { get; set; }
        public Guid AnimeId { get; set; }
        public Guid VoiceCastId { get; set; }
        public int Number { get; set; }
        public string? Link { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
    }
}