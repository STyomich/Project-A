using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.EpisodeService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Episode? Episode { get; set; }
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
                if (request.Episode == null)
                    return Result<Unit>.Failure("Episode entity is null");
                else
                {
                    await _dataContext.Episodes.AddAsync(request.Episode);
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to create an episode.");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
}