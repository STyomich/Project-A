using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.EpisodeService
{
    public class List
    {
        public class Query : IRequest<List<EpisodeDto>> { }
        public class Handler : IRequestHandler<Query, List<EpisodeDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<EpisodeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<EpisodeDto>>(await _dataContext.Episodes.ToListAsync());
            }
        }
    }
}