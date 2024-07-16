using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.DTO.Identity
{
    public class UserDto
    {
        public string? Picture { get; set; }
        public string? Banner { get; set; }
        public string? UserNickname { get; set; }
        public string? UserSurname { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string? Country { get; set; }
        public UserSetting? UserSettings { get; set; }
    }
}