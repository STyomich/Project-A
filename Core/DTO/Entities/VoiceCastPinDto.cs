namespace Core.DTO.Entities
{
    public class VoiceCastPinDto
    {
        public Guid EpisodeId { get; set; }
        public Guid VoiceCastId { get; set; }
        public string? Link { get; set; }
        public VoiceCastDto? VoiceCast { get; set; }
    }
}