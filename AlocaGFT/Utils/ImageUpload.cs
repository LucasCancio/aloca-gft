using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AlocaGFT.Utils
{
    public class ImageUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageUpload(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;

            if (!Directory.Exists(GetUploadPath()))
            {
                Directory.CreateDirectory(GetUploadPath());
            }
        }

        public string GetUploadedFilePath(long id, string fileName)
        {
            var uploadedFileName = $"{id}_{fileName}";
            var uploadedPath = GetUploadPath().Split("wwwroot")[1];
            return Path.Combine(uploadedPath, uploadedFileName);
        }

        private string GetFullUploadedFilePath(long id, string fileName)
        {
            var uploadedFileName = $"{id}_{fileName}";
            return Path.Combine(GetUploadPath(), uploadedFileName);
        }

        public string GetUploadPath()
        {
            string uploadsPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            return uploadsPath;
        }

        public string UploadFile(IFormFile Image, long id)
        {
            string filePath = null;

            if (Image != null)
            {
                filePath = GetFullUploadedFilePath(id, Image.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                }
            }
            return filePath;
        }

    }
}