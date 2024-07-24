using Application.Services.CommentService;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CommentController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Comment = comment }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditComment(Guid id, Comment comment)
        {
            comment.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Comment = comment }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> List(Guid id) // Returns list of comments via user id.
        {
            return Ok(await Mediator.Send(new List.Query { Id = id }));
        }
    }
}