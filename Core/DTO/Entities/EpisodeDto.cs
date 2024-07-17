namespace Core.DTO.Entities
{
    public class EpisodeDto
    {
        public Guid Id { get; set; }
        public Guid AnimeId { get; set; }
        public int Number { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public ICollection<VoiceCastPinDto>? VoiceCastPins { get; set; }
    }
}