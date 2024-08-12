using AutoMapper;
using Core.Domain.Entities;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AnimeService
{
    public class AnimesOfSeason
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
                DateTime today = DateTime.UtcNow;

                DateTime springStart = new DateTime(today.Year, 3, 1);
                DateTime springEnd = new DateTime(today.Year, 5, 31);

                DateTime summerStart = new DateTime(today.Year, 6, 1);
                DateTime summerEnd = new DateTime(today.Year, 8, 31);

                DateTime autumnStart = new DateTime(today.Year, 9, 1);
                DateTime autumnEnd = new DateTime(today.Year, 11, 30);

                DateTime winterStart = new DateTime(today.Month >= 12 ? today.Year : today.Year - 1, 12, 1);
                DateTime winterEnd = new DateTime(today.Month <= 2 ? today.Year : today.Year + 1, 2, 28);

                // Проверка, находится ли текущая дата в диапазоне зимы
                bool isInSpring = today >= springStart && today <= springEnd;
                bool isInSummer = today >= summerStart && today <= summerEnd;
                bool isInAutumn = today >= autumnStart && today <= autumnEnd;
                bool isInWinter = today >= winterStart && today <= winterEnd;

                var seasonAnimes = new List<Anime>();

                if (isInSpring)
                {
                    seasonAnimes = await _dataContext.Animes
                   .Include(a => a.GenrePins).ThenInclude(gp => gp.Genre)
                   .Include(a => a.Studio)
                   .Include(a => a.Episodes).ThenInclude(e => e.VoiceCastPins).ThenInclude(vcp => vcp.VoiceCast)
                   .Include(a => a.Comments).ThenInclude(c => c.User)
                   .Where(a => a.StartDate >= springStart && a.StartDate <= springEnd)
                   .ToListAsync();
                }
                if (isInSummer)
                {
                    seasonAnimes = await _dataContext.Animes
                   .Include(a => a.GenrePins).ThenInclude(gp => gp.Genre)
                   .Include(a => a.Studio)
                   .Include(a => a.Episodes).ThenInclude(e => e.VoiceCastPins).ThenInclude(vcp => vcp.VoiceCast)
                   .Include(a => a.Comments).ThenInclude(c => c.User)
                   .Where(a => a.StartDate >= summerStart && a.StartDate <= summerEnd)
                   .ToListAsync();
                }
                if (isInAutumn)
                {
                    seasonAnimes = await _dataContext.Animes
                   .Include(a => a.GenrePins).ThenInclude(gp => gp.Genre)
                   .Include(a => a.Studio)
                   .Include(a => a.Episodes).ThenInclude(e => e.VoiceCastPins).ThenInclude(vcp => vcp.VoiceCast)
                   .Include(a => a.Comments).ThenInclude(c => c.User)
                   .Where(a => a.StartDate >= autumnStart && a.StartDate <= autumnEnd)
                   .ToListAsync();
                }
                if (isInWinter)
                {
                    seasonAnimes = await _dataContext.Animes
                   .Include(a => a.GenrePins).ThenInclude(gp => gp.Genre)
                   .Include(a => a.Studio)
                   .Include(a => a.Episodes).ThenInclude(e => e.VoiceCastPins).ThenInclude(vcp => vcp.VoiceCast)
                   .Include(a => a.Comments).ThenInclude(c => c.User)
                   .Where(a => a.StartDate >= winterStart && a.StartDate <= winterEnd)
                   .ToListAsync();
                }
                return _mapper.Map<List<AnimeDto>>(seasonAnimes);
            }
        }
    }
}