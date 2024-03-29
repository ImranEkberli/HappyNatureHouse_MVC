﻿
using Azure.Core;
using System.ComponentModel.DataAnnotations;

namespace HappyNatureHouse_MVC.Areas.Admin.ViewModels.CottageVMs
{
    public class CottageAddViewModel
    {
        [Display(Name = "Kotecin Adı :")]
        [Required(ErrorMessage = "Kotecin Adı boş olmamalıdır.")]
        [MinLength(2, ErrorMessage = "Kotecin Adı ən azı 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Kotecin Adı ən çox 50 karakter olmalıdır.")]
        public string Name { get; set; } = null!;


        [Display(Name = "Qısa Məzmun :")]
        [Required(ErrorMessage = "Qısa Məzmun boş olmamalıdır.")]
        [MinLength(2, ErrorMessage = "Kotecin Adı ən azı 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Kotecin Adı ən çox 50 karakter olmalıdır.")]
        public string Title { get; set; } = null!;



        [Display(Name = "Məzmunu :")]
        [Required(ErrorMessage = "Məzmunu boş olmamalıdır.")]
        [MaxLength(4000, ErrorMessage = "Kotecin Adı ən çox 4000 karakter ola bilər.")]
        [StringLength(int.MaxValue)]
        public string Description { get; set; } = null!;


        [Display(Name = "Qiyməti :")]
        [Required(ErrorMessage = "Qiyməti boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Yalnız qiymət daxil edə bilərsiz.")]
        [Range(0.01, 10000.00,ErrorMessage ="Qiymət 0.01 ilə 10000.00 arası ola bilər.")]
     
        public decimal Price { get; set; }


        [Display(Name = "Endirimli qiymət :")]
        [Range(0.01, 10000.00, ErrorMessage = "Endirimli qiymət 0.01 ilə 10000.00 arası ola bilər.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Yalnız qiymət daxil edə bilərsiz.")]
        public decimal? DiscountPrice { get; set; }


        [Display(Name = "Şəkil :")]
        [Required(ErrorMessage = "Şəkil boş olmamalıdır.")]
        [DataType(DataType.Upload,ErrorMessage ="Yalnız fayl yükləmək olar.")]
        public IFormFile Image { get; set; } = null!;


        [Display(Name = "Otaq sayı :")]
        [Required(ErrorMessage = "Otaq sayı doldurulmalıdır.")]
        [Range(1, 5, ErrorMessage = "Otaq sayı 1 ilə 5 arası ola bilər.")]
        public int RoomCount { get; set; }


        [Display(Name = "Qonaq sayı :")]
        [Required(ErrorMessage = "Qonaq sayı doldurulmalıdır.")]
        [Range(1, 10, ErrorMessage = "Qonaq sayı 1 ilə 10 arası ola bilər.")]
        public int GuestCount { get; set; }


        [Display(Name = "Teknəfərlik çarpayı :")]
        [Range(1, 6, ErrorMessage = "Teknəfərlik çarpayı 1 ilə 6 arası ola bilər.")]
        public int? SingleBed { get; set; }


        [Display(Name = "İkili çarpayı :")]
        [Range(1, 4, ErrorMessage = "İkili çarpayı 1 ilə 4 arası ola bilər.")]
        public int? DoubleBed { get; set; } 


        [Display(Name = "Statusu :")]
        public bool Status { get; set; }

    }
}
