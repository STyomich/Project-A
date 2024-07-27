using Application.Interfaces;
using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AnimePinService
{
    public class AnimePinToUser
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AnimePin? AnimePin { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            public Handler(DataContext dataContext, IUserAccessor userAccessor, IMapper mapper)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.AnimePin.AnimeId == null)
                    return Result<Unit>.Failure("Can't identify anime.");
                if (request.AnimePin.PinType == null)
                    return Result<Unit>.Failure("Can't identify pin type.");
                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserNickname == _userAccessor.GetUserNickname());
                request.AnimePin.UserId = user.Id;
                var animePin = await _dataContext.AnimePins.FirstOrDefaultAsync(ap => ap.AnimeId == request.AnimePin.AnimeId && ap.UserId == request.AnimePin.UserId);
                if (animePin == null)
                    await _dataContext.AnimePins.AddAsync(request.AnimePin);
                else
                {
                    _mapper.Map(request.AnimePin, animePin);
                }
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result)
                    return Result<Unit>.Failure("Failed to pin anime to user.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}