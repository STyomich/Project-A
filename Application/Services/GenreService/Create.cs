using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.GenreService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Genre? Genre { get; set; }
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
                if (request.Genre == null)
                    return Result<Unit>.Failure("Genre entity is null.");
                else
                {
                    await _dataContext.Genres.AddAsync(request.Genre);
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to create a genre.");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
}