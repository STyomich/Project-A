using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ChronologyService
{
    public class Details
    {
        public class Query : IRequest<Result<ChronologyDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<ChronologyDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<ChronologyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var chronology = await _dataContext.Chronologies.Where(c => c.Id == request.Id).Include(c => c.ChronologyElements).ThenInclude(ce => ce.Anime).FirstOrDefaultAsync();
                if (chronology != null)
                    return Result<ChronologyDto>.Success(_mapper.Map<ChronologyDto>(chronology));
                else
                    return Result<ChronologyDto>.Failure("Chronology don't found");
            }
        }
    }
}