using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.NotificationService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Notification? Notification { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Notification == null)
                    return Result<Unit>.Failure("Notification entity is null.");
                if (request.Notification.AnimeId == null)
                    return Result<Unit>.Failure("Can't identify anime.");
                if (request.Notification.Content == null)
                    return Result<Unit>.Failure("Content of notification is null.");
                if (request.Notification.Title == null)
                    return Result<Unit>.Failure("Title of notification is null");
                else
                {
                    //TODO: Should be functionality when we add notification to all users which have this anime in his list.
                    await _dataContext.Notifications.AddAsync(request.Notification);
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to create a notification.");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
}