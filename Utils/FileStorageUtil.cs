using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesManager.Utils
{
    public static class FileStorageUtil
    {
        public static async Task<string> CreateFile(string wwwRootPath, string imageName, IFormFile image)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageName) + DateTime.Now.ToString("yymmssfff");
            string extension = Path.GetExtension(imageName);
            fileName += extension;
            string path = Path.Combine(wwwRootPath + "/image/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public static void DeleteFile(string wwwRootPath, string filePath)
        {
            string imagePath = Path.Combine(wwwRootPath + filePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }
    }
}
