using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.EpisodeService
{
    public class Details
    {
        public class Query : IRequest<Result<EpisodeDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<EpisodeDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<EpisodeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var episode = await _dataContext.Episodes.Where(s => s.Id == request.Id).FirstOrDefaultAsync();
                if (episode != null)
                    return Result<EpisodeDto>.Success(_mapper.Map<EpisodeDto>(episode));
                else
                    return Result<EpisodeDto>.Failure("Episode don't found");
            }
        }
    }
}