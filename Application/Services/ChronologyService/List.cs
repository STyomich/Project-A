using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ChronologyService
{
    public class List
    {
        public class Query : IRequest<List<ChronologyDto>> { }
        public class Handler : IRequestHandler<Query, List<ChronologyDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<ChronologyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<ChronologyDto>>(await _dataContext.Chronologies.ToListAsync());
            }
        }
    }
}