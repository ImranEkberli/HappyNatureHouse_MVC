using System.ComponentModel.DataAnnotations;

namespace HappyNatureHouse_MVC.Areas.Admin.ViewModels.AuthVMs
{
    public class AdminLoginViewModel
    {
        [Display(Name = "E-mail addresi:")]
        [Required(ErrorMessage = "E-mail addresi doldurmaq vacibdir.")]
        [EmailAddress(ErrorMessage = "E-mail addresinizi düzgün formatda yazın.")]
        [MinLength(10, ErrorMessage = "E-mail addresi ən azı 10 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "E-mail addresi ən çox 50 karakter olmalıdır.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Şifrə :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifrəni doldurmaq vacibdir.")]
        [MinLength(8, ErrorMessage = "Şifrə ən azı 8 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Şifrə ən çox 50 karakter olmalıdır.")]
        public string Password { get; set; } = null!;
    }
}
