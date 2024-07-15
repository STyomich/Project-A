using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AnimeId { get; set; }
        public int ScenarioGrade { get; set; }
        public string? ScenarioContent { get; set; }
        public int? CharactersGrade { get; set; }
        public string? CharactersContent { get; set; }
        public int? MusicGrade { get; set; }
        public string? MusicContent { get; set; }
        public int? ImpressionGrade { get; set; }
        public string? ImpressionContent { get; set; }
        public bool IsApproved { get; set; } = false;
        public ApplicationUser? User {get;set;}
        public Anime? Anime {get;set;}
    }
}