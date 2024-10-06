using AutoMapper;
using Core.DTO.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AnimePinService
{
    public class List
    {
        public class Query : IRequest<List<AnimePinDto>>
        {
            public string? Nickname { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<AnimePinDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<AnimePinDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _dataContext.Users.Where(u => u.UserNickname == request.Nickname).FirstOrDefaultAsync();
                var animePins = await _dataContext.AnimePins.Where(ap => ap.UserId == user.Id).Include(a => a.Anime).ThenInclude(a => a.Picture).ToListAsync();
                return _mapper.Map<List<AnimePinDto>>(animePins);
            }
        }
    }
}