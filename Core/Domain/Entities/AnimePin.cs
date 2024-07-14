using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.IdentityEntities;
using Core.Enums;

namespace Core.Domain.Entities
{
    public class AnimePin
    {
        public Guid UserId { get; set; }
        public Guid AnimeId { get; set; }
        public string PinType { get; set; } = AnimePinTypeEnum.Watching.ToString(); //AnimePinTypeEnum
        public int? Grade { get; set; } //1-10
        public bool isFavorite { get; set; } = false;
        public ApplicationUser? User { get; set; }
        public Anime? Anime { get; set; }
    }
}