using AutoMapper;
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
                var animes = await _dataContext.Animes
                    .Include(a => a.GenrePins).ThenInclude(gp => gp.Genre)
                    .Include(a => a.Studio)
                    .Include(a => a.Episodes).ThenInclude(e => e.VoiceCastPins).ThenInclude(vcp => vcp.VoiceCast)
                    .Include(a => a.Comments).ThenInclude(c => c.User)
                    .Include(a => a.Picture)
                    .ToListAsync();
                return _mapper.Map<List<AnimeDto>>(animes);
            }
        }
    }
}