using Application.Interfaces;
using Core.Domain;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ImageService
{
    public class AddAvatar
    {
        public class Command : IRequest<Result<Image>>
        {
            public IFormFile File { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Image>>
        {
            private readonly DataContext _dataContext;
            private readonly IImageAccessor _imageAccessor;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext dataContext, IImageAccessor imageAccessor, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _imageAccessor = imageAccessor;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Image>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _dataContext.Users.Include(u => u.Avatar).FirstOrDefaultAsync(u => u.UserNickname == _userAccessor.GetUserNickname());
                if (user == null) return null;

                if (user.AvatarId != null)
                {
                    var resultDeleting = _imageAccessor.DeletePhoto(user.AvatarId);
                    if (resultDeleting == null) return Result<Image>.Failure("Problem deleting existing avatar.");
                    var avatar = await _dataContext.Images.FindAsync(user.AvatarId);
                    if (avatar != null)
                    {
                        _dataContext.Images.Remove(avatar);
                    }
                    user.AvatarId = null;
                }

                var imageUploadResult = await _imageAccessor.AddPhoto(request.File);
                var image = new Image
                {
                    Id = imageUploadResult.PublicId,
                    Url = imageUploadResult.Url.ToString()
                };
                user.Avatar = image;
                user.AvatarId = image.Id;

                var result = await _dataContext.SaveChangesAsync() > 0;

                if (result) return Result<Image>.Success(image);

                return Result<Image>.Failure("Problem adding new avatar.");
            }
        }
    }
}