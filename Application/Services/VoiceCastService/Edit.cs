using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.VoiceCastService
{
    public class Edit
    {
         public class Command : IRequest<Result<Unit>>
        {
            public VoiceCast? VoiceCast { get; set; }
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
                var voiceCast = await _dataContext.VoiceCasts.FindAsync(request.VoiceCast.Id);
                if(voiceCast == null) return null;
                _mapper.Map(request.VoiceCast, voiceCast);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update voice cast.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}