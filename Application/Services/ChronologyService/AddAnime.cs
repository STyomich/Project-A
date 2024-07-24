using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.ChronologyService
{
    public class AddAnime
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ChronologyElement? ChronologyElement { get; set; }
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
                if (request.ChronologyElement == null)
                    return Result<Unit>.Failure("Object to add anime to chronology is null.");
                var anime = _dataContext.Animes.FindAsync(request.ChronologyElement.AnimeId);
                if (anime == null)
                    return Result<Unit>.Failure("Anime doen't exist.");
                var chronology = _dataContext.Chronologies.FindAsync(request.ChronologyElement.ChronologyId);
                if (chronology == null)
                    return Result<Unit>.Failure("Anime doen't exist.");

                await _dataContext.ChronologyElements.AddAsync(request.ChronologyElement);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result)
                    return Result<Unit>.Failure("Failed add chronology element.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}