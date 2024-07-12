using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid AnimeId { get; set; }
        public Guid UserId { get; set; }
        public bool isChecked { get; set; } = false;
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Anime? Anime { get; set; }
        public ApplicationUser? User { get; set; }
    }
}