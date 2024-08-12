using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.AnimeService
{
    public class TopHundred
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
                double C = _dataContext.AnimePins
                          .Where(ap => ap.Grade.HasValue)
                          .Average(ap => ap.Grade.Value);

                int m = 1; // Минимальное количество голосов

                // Взвешенный рейтинг для каждого аниме
                var topAnimes = _dataContext.AnimePins
                    .Where(ap => ap.Grade.HasValue)
                    .GroupBy(ap => new { ap.AnimeId, ap.Anime.TitleInEnglish })
                    .Select(g => new
                    {
                        Anime = g.Key.TitleInEnglish,
                        v = g.Count(), // Количество голосов для сериала
                        R = g.Average(ap => ap.Grade.Value), // Средний рейтинг сериала
                        WR = ((g.Count() / (g.Count() + m)) * g.Average(ap => ap.Grade.Value)) + ((m / (g.Count() + m)) * C) // Взвешенный рейтинг
                    })
                    .Where(a => a.v >= m) // Только те аниме, которые набрали минимум m голосов
                    .OrderByDescending(a => a.WR)
                    .Take(100)
                    .Select(a => new { a.Anime, a.WR })
                    .ToList();
                return _mapper.Map<List<AnimeDto>>(topAnimes);
            }
        }
    }
}