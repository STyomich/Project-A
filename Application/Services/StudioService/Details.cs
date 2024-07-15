using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.StudioService
{
    public class Details
    {
        public class Query : IRequest<Result<Studio>>
        {
            public Guid Id {get;set;}
        }
        public class Handler : IRequestHandler<Query, Result<Studio>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<Studio>> Handle(Query request, CancellationToken cancellationToken)
            {
                var studio = await _dataContext.Studios.Where(s => s.Id == request.Id).FirstOrDefaultAsync();
                if (studio != null)
                    return Result<Studio>.Success(studio);
                else
                    return Result<Studio>.Failure("Studio don't found");
            }
        }
    }
}