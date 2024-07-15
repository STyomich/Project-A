using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.StudioService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Studio? Studio {get;set;}
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
                if (request.Studio == null)
                    return Result<Unit>.Failure("Studio entity is null");
                else
                {
                    await _dataContext.Studios.AddAsync(request.Studio);
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to create a studio.");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
}