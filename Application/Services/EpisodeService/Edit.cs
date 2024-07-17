using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.EpisodeService
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Episode? Episode { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var episode = await _dataContext.Episodes.FindAsync(request.Episode.Id);
                if(episode == null) return null;
                _mapper.Map(request.Episode, episode);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update episode.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}