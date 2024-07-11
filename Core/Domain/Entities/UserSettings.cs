using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class UserSetting
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool ProfileIsPublic { get; set; } = true;
        public bool WatchingIsPublic { get; set; } = true;
        public bool WillWatchIsPublic { get; set; } = true;
        public bool WatchedIsPublic { get; set; } = true;
        public bool AbandonedIsPublic { get; set; } = true;
        public bool FriendListIsPublic { get; set; } = true;
        
    }
}