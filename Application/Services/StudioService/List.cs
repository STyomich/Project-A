using AutoMapper;
using Core.Domain.Entities;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.StudioService
{
    public class List
    {
        public class Query : IRequest<List<StudioDto>> { }
        public class Handler : IRequestHandler<Query, List<StudioDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<StudioDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<StudioDto>>(await _dataContext.Studios.ToListAsync());
            }
        }
    }
}