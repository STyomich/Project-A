namespace Core.Domain.Entities
{
    public class VoiceCastPin
    {
        public Guid EpisodeId { get; set; }
        public Guid VoiceCastId { get; set; }
        public string? Link { get; set; }
        public Episode? Episode { get; set; }
        public VoiceCast? VoiceCast { get; set; }
    }
}