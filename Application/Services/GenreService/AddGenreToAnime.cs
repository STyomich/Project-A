using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.GenreService
{
    public class AddGenreToAnime
    {
        public class Command : IRequest<Result<Unit>>
        {
            public GenrePin? GenrePin { get; set; }
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
                var searchingForGenrePin = await _dataContext.GenrePins.FirstOrDefaultAsync(gp => gp.GenreId == request.GenrePin.GenreId && gp.AnimeId == request.GenrePin.AnimeId);
                if (searchingForGenrePin != null) return Result<Unit>.Failure("This genre already pined to this anime.");

                if (request.GenrePin != null)
                    await _dataContext.GenrePins.AddAsync(request.GenrePin);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result)
                    return Result<Unit>.Failure("Failed to pin genre to anime.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}