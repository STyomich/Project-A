using Application.Services.AnimePinService;
using Core.Domain.Entities;
using Core.DTO.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AnimePinController : BaseApiController
    {
        [HttpPost("pin-anime-to-user")]
        public async Task<IActionResult> PinAnimeToUser(AnimePin animePin)
        {
            return HandleResult(await Mediator.Send(new AnimePinToUser.Command { AnimePin = animePin }));
        }
        [HttpGet("users-anime/{nickname}")]
        public async Task<ActionResult<List<AnimePinDto>>> ListOfAnimeWhichUserPin(string nickname)
        {
            return await Mediator.Send(new List.Query { Nickname = nickname });
        }
    }
}