using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.UserSettingService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UserSetting? UserSetting { get; set; }
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
                if(request.UserSetting == null)
                    return Result<Unit>.Failure("User setting entity is empty.");
                if(request.UserSetting.UserId == null)
                    return Result<Unit>.Failure("User identifier is null.");
                await _dataContext.UserSettings.AddAsync(request.UserSetting);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result)
                    return Result<Unit>.Failure("Failed to create user setting.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}