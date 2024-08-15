using Application.Services.ImageService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ImageController : BaseApiController
    {
        [HttpPost("add-avatar")]
        public async Task<IActionResult> AddAvatar([FromForm] AddAvatar.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }
        [HttpPost("add-anime-picture/{id}")]
        public async Task<IActionResult> AddAnimePicture(Guid id, [FromForm] IFormFile picture)
        {
            return HandleResult(await Mediator.Send(new AddAnimePicture.Command{ File = picture, AnimeId = id}));
        }
    }
}