using Application.Services.AnimeService;
using Core.Domain.Entities;
using Core.DTO.Entities;
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
        public async Task<ActionResult<List<AnimeDto>>> GetAllAnime()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnime(Anime anime)
        {
            return Ok(await Mediator.Send(new Create.Command { Anime = anime }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimeDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAnime(Guid id, Anime anime)
        {
            anime.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Anime = anime }));
        }
        [HttpGet("of-season")]
        public async Task<ActionResult<List<AnimeDto>>> GetAnimeOfSeason()
        {
            return await _mediator.Send(new AnimesOfSeason.Query());
        }
    }
}