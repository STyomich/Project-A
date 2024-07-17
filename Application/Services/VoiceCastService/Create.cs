using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.VoiceCastService
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public VoiceCast? VoiceCast { get; set; }
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
                if(request.VoiceCast == null)
                    return Result<Unit>.Failure("Voice cast entity is null.");
                else
                {
                    await _dataContext.VoiceCasts.AddAsync(request.VoiceCast);
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    if (!result)
                        return Result<Unit>.Failure("Failed to create a voice cast.");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
}