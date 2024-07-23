using Application.Services.CommentService;
using Core.Domain.Entities;
using MediatR;
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
    }
}