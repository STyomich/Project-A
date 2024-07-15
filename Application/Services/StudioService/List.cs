using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.StudioService
{
    public class List
    {
        public class Query : IRequest<List<Studio>> { }
        public class Handler : IRequestHandler<Query, List<Studio>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<List<Studio>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Studios.ToListAsync();
            }
        }
    }
}