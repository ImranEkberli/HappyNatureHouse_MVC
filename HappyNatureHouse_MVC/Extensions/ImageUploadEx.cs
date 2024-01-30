
using HappyNatureHouse_MVC.Models;

namespace HappyNatureHouse_MVC.Extensions
{
    public class ImageUploadEx
    {
        public static string Upload(IFormFile image)
        {
            string filename = DateTime.Now.ToString("yyyymmddhhnnssff") + Path.GetExtension(image.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return filename;
        }
        public static void DeleteImage(string imagefile,List<string> filenames)
        {
            List<string> strings = new List<string>();  
            strings.AddRange(filenames);
            strings.Add(imagefile);
            foreach (var filename in strings)
            {
                if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filename)))
                {
                    Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filename));
                }
            }
          

        }
        public static void DeleteImage(List<string> filenames)
        {
            foreach (var filename in filenames)
            {
                if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filename)))
                {
                    Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filename));
                }
            }
        }
    }
}
