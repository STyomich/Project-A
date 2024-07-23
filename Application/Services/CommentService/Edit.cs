using Application.Interfaces;
using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.CommentService
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Comment? Comment { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext dataContext, IMapper mapper, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Comment.UserId != await _dataContext.Users.Where(u => u.UserNickname == _userAccessor.GetUserNickname()).Select(u => u.Id).FirstOrDefaultAsync())
                    return Result<Unit>.Failure("User in comment doesn't equals with users in auth.");
                var comment = await _dataContext.Comments.FindAsync(request.Comment.Id);
                _mapper.Map(request.Comment, comment);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update comment.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}