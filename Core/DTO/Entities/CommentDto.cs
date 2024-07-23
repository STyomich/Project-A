using Core.DTO.Identity;

namespace Core.DTO.Entities
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AnimeId { get; set; }
        public string? Content { get; set; }
        public UserDto? User { get; set; }
        //public ICollection<CommentReaction>? CommentReactions { get; set; }
    }
}