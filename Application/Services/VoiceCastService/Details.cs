using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.VoiceCastService
{
    public class Details
    {
        public class Query : IRequest<Result<VoiceCastDto>>
        {
            public Guid Id {get;set;}
        }
        public class Handler : IRequestHandler<Query, Result<VoiceCastDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<VoiceCastDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var voiceCast = await _dataContext.VoiceCasts.Where(s => s.Id == request.Id).FirstOrDefaultAsync();
                if (voiceCast != null)
                    return Result<VoiceCastDto>.Success(_mapper.Map<VoiceCastDto>(voiceCast));
                else
                    return Result<VoiceCastDto>.Failure("Voice cast don't found");
            }
        }
    }
}