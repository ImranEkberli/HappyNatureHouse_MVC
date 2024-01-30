using System.ComponentModel.DataAnnotations;

namespace HappyNatureHouse_MVC.Areas.Admin.ViewModels.ImageVMs
{
    public class PictureAddViewModel
    {
        [Display(Name = "Şəkil :")]
        [Required(ErrorMessage = "Şəkil boş olmamalıdır.")]
        [DataType(DataType.Upload, ErrorMessage = "Yalnız fayl yükləmək olar.")]
        public IFormFile Image { get; set; } = null!;
    }
}
