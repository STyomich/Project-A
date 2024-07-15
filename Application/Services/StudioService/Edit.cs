using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.StudioService
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Studio? Studio { get; set; }
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
                var studio = await _dataContext.Studios.FindAsync(request.Studio.Id);
                if(studio == null) return null;
                _mapper.Map(request.Studio, studio);

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update studio.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}