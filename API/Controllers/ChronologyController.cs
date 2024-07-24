using Application.Services.ChronologyService;
using Core.Domain.Entities;
using Core.DTO.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ChronologyController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ChronologyDto>>> GetAllChronologies()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChronologyDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> CreateChronology(Chronology chronology)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Chronology = chronology }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditChronology(Guid id, Chronology chronology)
        {
            chronology.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Chronology = chronology }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChronology(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPost("add-anime")]
        public async Task<IActionResult> AddAnimeToChronology(ChronologyElement chronologyElement)
        {
            return HandleResult(await Mediator.Send(new AddAnime.Command { ChronologyElement = chronologyElement }));
        }
    }
}