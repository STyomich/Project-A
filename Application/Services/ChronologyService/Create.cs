using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.ChronologyService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Chronology? Chronology { get; set; }
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
                if (request.Chronology == null)
                    return Result<Unit>.Failure("Chronology entity is null");
                else
                {
                    await _dataContext.Chronologies.AddAsync(request.Chronology);
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to create a chronology.");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
}