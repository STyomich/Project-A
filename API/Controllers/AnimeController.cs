using Core.Domain.Entities;
using Core.Services.AnimeService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AnimeController : BaseApiController
    {
        private readonly IMediator _mediator;
        public AnimeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet] //api/anime
        public async Task<ActionResult<List<Anime>>> GetAllAnime()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnime(Anime anime)
        {
            return Ok(await Mediator.Send(new Create.Command { Anime = anime }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAnime(Guid Id, Anime anime)
        {
            anime.Id = Id;
            return Ok(await Mediator.Send(new Edit.Command { Anime = anime }));
        }
    }
}