
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HappyNatureHouse_MVC.Extensions
{
    public static class ImageFileEx
    {
        public static bool ImageSize(this ModelStateDictionary modelstate, IFormFile imagefile)
        {
            if (imagefile.Length > 5 * 1024 * 1024)
            {
                modelstate.AddModelError(string.Empty, "Şəkil ölçüsü 5mb-dan çox olmamalıdır.");
                return false;
            }
            var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            if (!allowedTypes.Contains(imagefile.ContentType))
            {
                modelstate.AddModelError(string.Empty, "Şəkil tipi yalnız .jpeg,.png,.gif formatlarında olmalıdır.");
                return false;
            }
            return true;
        }
    }
}
