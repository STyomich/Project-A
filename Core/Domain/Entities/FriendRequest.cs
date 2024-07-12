using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class FriendRequest
    {
        public Guid FirstUserId { get; set; }
        public Guid SecondUserId { get; set; }
        public bool isFriend { get; set; } = false;
        public ApplicationUser? FirstUser { get; set; }
        public ApplicationUser? SecondUser { get; set; }
    }
}