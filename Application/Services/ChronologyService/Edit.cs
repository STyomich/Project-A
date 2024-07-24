using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.ChronologyService
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Chronology? Chronology { get; set; }
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
                var chronology = await _dataContext.Chronologies.FindAsync(request.Chronology.Id);
                if (chronology == null) return null;
                _mapper.Map(request.Chronology, chronology);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update chronology info.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}