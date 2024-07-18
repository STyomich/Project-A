using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTO.Identity
{
    public class RegisterDto
    {
        public string? Email { get; set; }
        public string? UserNickname { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}