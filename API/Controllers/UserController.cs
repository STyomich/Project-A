
using Core.Domain.IdentityEntities;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserManager<ApplicationUser>? _userManager;
        public UserController(UserManager<ApplicationUser>? userManager)
        {
            userManager = _userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.Include(u => u.UserSettings).SingleOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized();
            if (result)
            {
                return new UserDto
                {
                    Picture = user.Picture,
                    Banner = user.Banner,
                    UserNickname = user.UserNickname,
                    UserSurname = user.UserSurname,
                    Email = user.Email,
                    Bio = user.Bio,
                    Country = user.Country,
                    UserSettings = user.UserSettings
                };
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserNickname == registerDto.UserNickname))
            {
                ModelState.AddModelError("usernickname", "This nickname is already taken");
                return ValidationProblem();
            }
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                ModelState.AddModelError("email", "This email is already taken");
                return ValidationProblem();
            }
            var user = new ApplicationUser
            {
                UserNickname = registerDto.UserNickname,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                //To Do: Add creating of UserSettings.
                return new UserDto
                {
                    Picture = user.Picture,
                    Banner = user.Banner,
                    UserNickname = user.UserNickname,
                    UserSurname = user.UserSurname,
                    Email = user.Email,
                    Bio = user.Bio,
                    Country = user.Country,
                    UserSettings = user.UserSettings
                };
            }

            return BadRequest(result.Errors);
        }
    }
}