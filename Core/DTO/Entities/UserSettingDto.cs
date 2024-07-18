namespace Core.DTO.Entities
{
    public class UserSettingDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool ProfileIsPublic { get; set; } = true;
        public bool WatchingIsPublic { get; set; } = true;
        public bool WillWatchIsPublic { get; set; } = true;
        public bool WatchedIsPublic { get; set; } = true;
        public bool AbandonedIsPublic { get; set; } = true;
        public bool FriendListIsPublic { get; set; } = true;
    }
}