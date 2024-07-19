using Core.DTO.Entities;

namespace Core.DTO.Identity
{
    public class UserDto
    {
        public string? Picture { get; set; }
        public string? Banner { get; set; }
        public string? UserNickname { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string? Country { get; set; }
        public string? Token { get; set; }
        public UserSettingDto? UserSettings { get; set; }
    }
}