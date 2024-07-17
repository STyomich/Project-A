using Application.Services.EpisodeService;
using Core.Domain.Entities;
using Core.DTO.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EpisodeController : BaseApiController
    {
        private readonly IMediator _mediator;
        public EpisodeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<EpisodeDto>>> GetAllEpisodes()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost]
        public async Task<IActionResult> CreateEpisode(Episode episode)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Episode = episode }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisodeDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEpisode(Guid id, Episode episode)
        {
            episode.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Episode = episode }));
        }
    }
}