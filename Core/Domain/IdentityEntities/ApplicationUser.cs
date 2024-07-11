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
        public string? UserNickname { get; set; }
        public string? UserSurname { get; set; }
        public string? Bio { get; set; }
        public string? Country { get; set; }
        public UserSetting UserSettings { get; set; }
    }
}