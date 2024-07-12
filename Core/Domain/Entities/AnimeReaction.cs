using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class AnimeReaction
    {
        public Guid Id { get; set; }
        public Guid AnimeId { get; set; }
        public Guid UserId { get; set; }
        public int Grade { get; set; }
        public Anime? Anime { get; set; }
        public ApplicationUser? User { get; set; }
    }
}