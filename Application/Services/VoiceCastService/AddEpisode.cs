using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.VoiceCastService
{
    public class AddEpisode
    {
        public class Command : IRequest<Result<Unit>>
        {
            public VoiceCastPin? VoiceCastPin { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if(request.VoiceCastPin == null)
                    return Result<Unit>.Failure("Object to pin voice cast to episode is null.");
                else
                {
                    await _dataContext.VoiceCastPins.AddAsync(request.VoiceCastPin);
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to pin voice cast to episode.");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
}