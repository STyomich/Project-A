using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.StudioService
{
    public class Details
    {
        public class Query : IRequest<Result<StudioDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<StudioDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<StudioDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var studio = await _dataContext.Studios.Where(s => s.Id == request.Id).FirstOrDefaultAsync();
                if (studio != null)
                    return Result<StudioDto>.Success(_mapper.Map<StudioDto>(studio));
                else
                    return Result<StudioDto>.Failure("Studio don't found");
            }
        }
    }
}