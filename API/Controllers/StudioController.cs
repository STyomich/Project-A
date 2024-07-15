using Application.Services.StudioService;
using Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StudioController : BaseApiController
    {
        private readonly IMediator _mediator;
        public StudioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Studio>>> GetAllStudios()
        {
            return await _mediator.Send(new List.Query());
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudio(Studio studio)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Studio = studio }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudioDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query {Id = id}));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudio(Guid id, Studio studio)
        {
            studio.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command{ Studio = studio}));
        }
    }
}