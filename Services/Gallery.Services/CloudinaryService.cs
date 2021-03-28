using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Gallery.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinaryUtility;

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public async Task<string> UploadEntityIllustrationAsync(IFormFile illustration, string illustrationName)
        {
            byte[] destinationData;

            using (MemoryStream ms = new MemoryStream())
            {
                await illustration.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (MemoryStream ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = "NG_ItemImages",
                    File = new FileDescription(illustrationName, ms)
                };

                uploadResult = cloudinaryUtility.Upload(uploadParams);
            }

            return uploadResult?.SecureUrl.AbsoluteUri;
        }
    }
}
