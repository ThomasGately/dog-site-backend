using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace WebApi.Helpers
{
    public class ImageManager
    {
        public String SaveImageToDogImages(IFormFile image)
        {
            string path = Directory.GetCurrentDirectory() + "Resources\\DogImages";
            var guid = Guid.NewGuid();
            path += guid;
            if(image.Length > 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                return guid.ToString();
            }
            return null;
        }
    }
}