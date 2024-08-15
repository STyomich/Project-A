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
    }
}