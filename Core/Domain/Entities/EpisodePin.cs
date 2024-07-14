using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.IdentityEntities;

namespace Core.Domain.Entities
{
    public class EpisodePin
    {
        public Guid UserId { get; set; }
        public Guid AnimeId { get; set; }
        public bool IsWatched { get; set; } = false;
        public ApplicationUser? User { get; set; }
        public Anime? Anime { get; set; }
    }
}