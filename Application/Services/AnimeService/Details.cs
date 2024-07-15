using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AnimeService
{
    public class Details
    {
        public class Query : IRequest<Result<Anime>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Anime>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }
            public async Task<Result<Anime>> Handle(Query request, CancellationToken cancellationToken)
            {
                var anime = await _dataContext.Animes.Where(a => a.Id == request.Id).Include(a => a.AnimePins).Include(a => a.Comments).FirstOrDefaultAsync();
                if (anime != null)
                    return Result<Anime>.Success(anime);
                else
                    return Result<Anime>.Failure("Anime don't found");
            }
        }
    }

}