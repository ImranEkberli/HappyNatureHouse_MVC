using HappyNatureHouse_MVC.Areas.Admin.ViewModels.ImageVMs;

namespace HappyNatureHouse_MVC.Areas.Admin.ViewModels.CottageVMs
{
    public class CottagePictureViewModel
    {    
        public int CottageId { get; set; }
        public List<PictureViewModel>? CottageImages { get; set; }   

    }
}
