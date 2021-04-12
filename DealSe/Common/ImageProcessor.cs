using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace DealSe.Common
{
    public class ImageProcessor
    {
        public static void ResizeImage(string path, int height, int width)
        {
            using (Image<Rgba32> image = Image.Load(path))
            {
                image.Mutate(x => x.Resize(width, height));
                image.Save(path);
            }
        }

        //Method to create admin directory
        public static void CreateAdminDirectory(string path, string imageName, string existingImageName, int height, int width, IFormFile file1)
        {
            string targetDirectory = Path.Combine(path, "Upload/Admin");
            if (existingImageName != null && File.Exists(Path.Combine(targetDirectory, existingImageName)))
                File.Delete(Path.Combine(targetDirectory, existingImageName));
            if (!Directory.Exists(targetDirectory))
                Directory.CreateDirectory(targetDirectory);
            var logoPath = Path.Combine(targetDirectory, imageName);
            var fileStream = new FileStream(logoPath, FileMode.Create);
            using (fileStream)
                file1.CopyTo(fileStream);
            ResizeImage(logoPath, height, width);
        }

        // Method to delete image from folder
        public static void RemoveImageFromFolder(string imagePath, string imageName)
        {
            string targetDirectory = Path.Combine(imagePath, imageName);
            if (File.Exists(targetDirectory))
                File.Delete(targetDirectory);
        }
    }
}
