namespace Gallery.Services.Contracts
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface ICloudinaryService
    {
        Task<string> UploadEntityIllustrationAsync
            (IFormFile illustration, string illustrationName);
    }
}
