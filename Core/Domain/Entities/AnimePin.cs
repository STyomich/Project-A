using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class AnimePin
    {
        public Guid Id { get; set; }
        public Guid AnimeId { get; set; }
        public string? PinType { get; set; } //AnimePinTypeEnum
        public bool isFavorite { get; set; } = false;
    }
}