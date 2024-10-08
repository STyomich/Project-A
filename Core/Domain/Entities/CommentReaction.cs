using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class CommentReaction
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public Comment? Comment { get; set; }
        public ApplicationUser? User { get; set; }
    }
}