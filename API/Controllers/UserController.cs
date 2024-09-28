using System.Security.Claims;
using Application.Services.UserService;
using Application.Services.UserSettingService;
using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.IdentityEntities;
using Core.DTO.Entities;
using Core.DTO.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        public UserController(UserManager<ApplicationUser> userManager, IMediator mediator, IMapper mapper, TokenService tokenService)
        {
            _userManager = userManager;
            _mediator = mediator;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.Include(u => u.UserSettings).Include(u => u.Avatar).SingleOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null) return Unauthorized();
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized();
            if (result)
            {
                return new UserDto
                {
                    Avatar = user.Avatar,
                    UserNickname = user.UserNickname,
                    UserName = user.UserName,
                    UserSurname = user.UserSurname,
                    Email = user.Email,
                    Bio = user.Bio,
                    Country = user.Country,
                    Token = _tokenService.CreateToken(user),
                    UserSettings = _mapper.Map<UserSettingDto>(user.UserSettings)
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
                UserName = registerDto.UserName,
                Id = Guid.NewGuid()
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                //TODO: Do functionality of creating User Settings.
                var userSetting = new UserSetting
                {
                    UserId = user.Id
                };
                await _mediator.Send(new Create.Command { UserSetting = userSetting });
                user.UserSettings = userSetting;
                return new UserDto
                {
                    Avatar = user.Avatar,
                    UserNickname = user.UserNickname,
                    UserName = user.UserName,
                    UserSurname = user.UserSurname,
                    Email = user.Email,
                    Bio = user.Bio,
                    Country = user.Country,
                    Token = _tokenService.CreateToken(user),
                    UserSettings = _mapper.Map<UserSettingDto>(user.UserSettings)
                };
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.Users.Include(u => u.UserSettings).Include(u => u.Avatar).SingleOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

            return new UserDto
            {
                Avatar = user.Avatar,
                UserNickname = user.UserNickname,
                UserName = user.UserName,
                UserSurname = user.UserSurname,
                Email = user.Email,
                Bio = user.Bio,
                Country = user.Country,
                Token = _tokenService.CreateToken(user),
                UserSettings = _mapper.Map<UserSettingDto>(user.UserSettings)
            };
        }
    }
}