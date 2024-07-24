using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.ChronologyService
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var chronology = await _dataContext.Chronologies.FindAsync(request.Id);
                if (chronology == null) return null;
                _dataContext.Remove(chronology);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (result)
                    return Result<Unit>.Success(Unit.Value);
                else
                    return Result<Unit>.Failure("Failed to delete chronology.");
            }
        }
    }
}