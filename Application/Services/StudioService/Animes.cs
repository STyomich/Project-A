using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.StudioService
{
    public class Animes
    {
        public class Query : IRequest<List<AnimeDto>>
        {
            public Guid StudioId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<AnimeDto>>
        {
            public readonly DataContext _dataContext;
            public readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<AnimeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<AnimeDto>>(await _dataContext.Animes.Include(a => a.Studio).Where(a => a.Studio.Id == request.StudioId).ToListAsync());
            }
        }
    }
}