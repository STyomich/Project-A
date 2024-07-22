using Application.Services.GenreService;
using Core.Domain.Entities;
using Core.DTO.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GenreController : BaseApiController
    {
        private readonly IMediator _mediator;
        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GenreDto>>> GetAllGenres()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost]
        public async Task<IActionResult> CreateGenre(Genre genre)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Genre = genre }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditGenre(Guid id, Genre genre)
        {
            genre.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Genre = genre }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPost("to-anime")]
        public async Task<IActionResult> AddGenreToAnime(GenrePin genrePin)
        {
            return HandleResult(await Mediator.Send(new AddGenreToAnime.Command { GenrePin = genrePin }));
        }
    }
}