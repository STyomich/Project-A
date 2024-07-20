using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.AnimeService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Anime? Anime { get; set; }
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
                if (request.Anime.TitleInEnglish == null && request.Anime.TitleInJapanese == null && request.Anime.TitleInRussian == null && request.Anime.TitleInUkrainian == null) return Result<Unit>.Failure("Failed to create an anime.");

                if (request.Anime != null) await _dataContext.Animes.AddAsync(request.Anime);
                var result = await _dataContext.SaveChangesAsync() > 0;
                
                if (!result) return Result<Unit>.Failure("Failed to create an anime.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}