using System.Text.Json.Serialization;

namespace Core.Domain.Entities
{
    public class Studio
    {
        public Guid Id { get; set; }
        public string? Picture { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Anime>? Animes { get; set; }
    }
}