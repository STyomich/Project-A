using Application.Interfaces;
using Core.Domain;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ImageService
{
    public class AddAnimePicture
    {
        public class Command : IRequest<Result<Image>>
        {
            public IFormFile File { get; set; }
            public Guid AnimeId { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Image>>
        {
            private readonly DataContext _dataContext;
            private readonly IImageAccessor _imageAccessor;
            public Handler(DataContext dataContext, IImageAccessor imageAccessor)
            {
                _dataContext = dataContext;
                _imageAccessor = imageAccessor;
            }
            public async Task<Result<Image>> Handle(Command request, CancellationToken cancellationToken)
            {
                var anime = await _dataContext.Animes.Include(a => a.Picture).FirstOrDefaultAsync(a => a.Id == request.AnimeId);
                if (anime == null) return null;

                if (anime.PictureId != null)
                {
                    var resultDeleting = _imageAccessor.DeletePhoto(anime.PictureId);
                    if (resultDeleting == null) return Result<Image>.Failure("Problem deleting existing picture of anime.");
                    var picture = await _dataContext.Images.FindAsync(anime.PictureId);
                    if (picture != null) _dataContext.Images.Remove(picture);
                    anime.PictureId = null;
                }

                var imageUploadResult = await _imageAccessor.AddPhoto(request.File);
                var image = new Image
                {
                    Id = imageUploadResult.PublicId,
                    Url = imageUploadResult.Url.ToString()
                };
                anime.Picture = image;
                anime.PictureId = image.Id;

                var result = await _dataContext.SaveChangesAsync() > 0;

                if (result) return Result<Image>.Success(image);

                return Result<Image>.Failure("Problem adding new picture for anime.");
            }
        }
    }
}