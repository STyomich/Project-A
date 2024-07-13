using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AnimeService
{
    public class List
    {
        public class Query : IRequest<List<Anime>> {}
        public class Handler : IRequestHandler<Query, List<Anime>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }
            public async Task<List<Anime>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Animes.ToListAsync();
            }
        }
    }
}