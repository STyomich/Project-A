using AutoMapper;
using Core.Domain.Entities;
using Infrastructure.DbContext;
using MediatR;

namespace Application.Services.UserSettingService
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UserSetting? UserSetting { get; set; }
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
                var userSetting = await _dataContext.UserSettings.FindAsync(request.UserSetting.UserId);
                if (userSetting == null) return null;
                _mapper.Map(request.UserSetting, userSetting);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update user setting.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}