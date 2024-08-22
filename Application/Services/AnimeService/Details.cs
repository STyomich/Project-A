using AutoMapper;
using Core.Domain.Entities;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AnimeService
{
    public class Details
    {
        public class Query : IRequest<Result<AnimeDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AnimeDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public async Task<Result<AnimeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var anime = await _dataContext.Animes.Where(a => a.Id == request.Id).Include(a => a.Studio).Include(a => a.Episodes).Include(a => a.Picture).Include(a=> a.GenrePins).ThenInclude(gp => gp.Genre).FirstOrDefaultAsync();
                if (anime != null)
                    return Result<AnimeDto>.Success(_mapper.Map<AnimeDto>(anime));
                else
                    return Result<AnimeDto>.Failure("Anime don't found");
            }
        }
    }

}