using AutoMapper;
using Core.Domain.Entities;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AnimeService
{
    public class List
    {
        public class Query : IRequest<List<AnimeDto>> { }
        public class Handler : IRequestHandler<Query, List<AnimeDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public async Task<List<AnimeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var animes = await _dataContext.Animes.Include(a => a.Studio).Include(a => a.Episodes).ThenInclude(a => a.VoiceCastPins).ThenInclude(vcp => vcp.VoiceCast).ToListAsync();
                return _mapper.Map<List<AnimeDto>>(animes);
            }
        }
    }
}