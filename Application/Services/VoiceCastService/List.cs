using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.VoiceCastService
{
    public class List
    {
        public class Query : IRequest<List<VoiceCastDto>> { }
        public class Handler : IRequestHandler<Query, List<VoiceCastDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<VoiceCastDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<VoiceCastDto>>(await _dataContext.VoiceCasts.ToListAsync());
            }
        }
    }
}