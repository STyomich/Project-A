using Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Images;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Application.Helpers
{
    public class ImageAccessor : IImageAccessor
    {
        private readonly Cloudinary _cloudinary;
        public ImageAccessor(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
        }
        public async Task<ImageUploadResult> AddPhoto(IFormFile file)
        {
            if (file.Length > 0)
            {
                await using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(600).Width(425).Crop("fill")
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }
                return new ImageUploadResult
                {
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl
                };
            }
            return null;
        }

        public async Task<string> DeletePhoto(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result.Result == "ok" ? result.Result : null;
        }
    }
}