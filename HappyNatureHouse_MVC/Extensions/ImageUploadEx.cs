
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
 
        public static void DeleteImage(params List<string>[] filenames)
        {
            foreach (var filename in filenames)
            {
                foreach (var item in filename)
                {
                    if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", item)))
                    {
                        Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", item));
                    }
                }

            }
        }
    }
}
