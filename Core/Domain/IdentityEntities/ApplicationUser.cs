using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Picture { get; set; }
        public string? Banner { get; set; }
        public string? UserNickname { get; set; }
        public string? UserSurname { get; set; }
        public string? Bio { get; set; }
        public string? Country { get; set; }
        public UserSetting? UserSettings { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<CommentReaction>? CommentReactions { get; set; }
        public ICollection<AnimePin>? AnimePins { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<FriendRequest>? FriendRequests { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<EpisodePin>? EpisodePins { get; set; }
    }
}