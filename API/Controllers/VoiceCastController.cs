using Application.Services.VoiceCastService;
using Core.Domain.Entities;
using Core.DTO.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VoiceCastController : BaseApiController
    {
        private readonly IMediator _mediator;

        public VoiceCastController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<VoiceCastDto>>> GetAllVoiceCasts()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost]
        public async Task<IActionResult> CreateVoiceCast(VoiceCast voiceCast)
        {
            return HandleResult(await Mediator.Send(new Create.Command {VoiceCast = voiceCast}));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoiceCastDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditVoiceCast(Guid id, VoiceCast voiceCast)
        {
            voiceCast.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { VoiceCast = voiceCast }));
        }
        [HttpPost("add-episode")]
        public async Task<IActionResult> AddVoiceCastToEpisode(VoiceCastPin voiceCastPin)
        {
            return HandleResult(await Mediator.Send(new AddEpisode.Command {VoiceCastPin = voiceCastPin}));
        }
    }
}