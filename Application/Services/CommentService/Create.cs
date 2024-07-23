using Application.Interfaces;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.CommentService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Comment? Comment { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext dataContext, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Comment.AnimeId == null)
                    return Result<Unit>.Failure("Failed to create comment.");

                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserNickname == _userAccessor.GetUserNickname());
                request.Comment.UserId = user.Id;
                
                await _dataContext.Comments.AddAsync(request.Comment);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create comment");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}