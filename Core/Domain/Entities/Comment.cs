using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Guid AnimeId { get; set; }
        public string? Content { get; set; }
        public ApplicationUser? User { get; set; }
        public Anime? Anime { get; set; }
        public ICollection<CommentReaction>? CommentReactions { get; set; }
    }
}