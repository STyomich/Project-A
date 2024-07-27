using Core.Enums;

namespace Core.DTO.Entities
{
    public class AnimePinDto
    {
        public Guid UserId { get; set; }
        public Guid AnimeId { get; set; }
        public string PinType { get; set; } = AnimePinTypeEnum.Watching.ToString(); //AnimePinTypeEnum
        public int? Grade { get; set; } //1-10
        public bool isFavorite { get; set; } = false;
        public DateTime AddDate { get; set; } = DateTime.UtcNow;
        public AnimeDto? Anime { get; set; }
    }
}