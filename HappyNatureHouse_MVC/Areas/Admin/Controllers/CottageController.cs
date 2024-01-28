using HappyNatureHouse_MVC.Areas.Admin.ViewModels;
using HappyNatureHouse_MVC.Areas.Admin.ViewModels.CottageVMs;
using HappyNatureHouse_MVC.Data;
using HappyNatureHouse_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HappyNatureHouse_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CottageController : Controller
    {
        private readonly DataContext _db;

        public CottageController(DataContext db)
        {
            _db = db;
        }
        public IActionResult List()
        {
            try
            {
                var xxx = _db.Cottages.ToList();
                List<CottageViewModel> cottages = _db.Cottages.Select(x => new CottageViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Title = x.Title,
                    Description = x.Description,
                    CreateDate = x.CreateDate,
                    ModifierDate = x.ModifierDate,
                    Price = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    Image = x.Image,
                    DoubleBed = x.DoubleBed,
                    SingleBed = x.SingleBed,
                    RoomCount = x.RoomCount,
                    GuestCount = x.GuestCount,
                    Status = x.Status

                }).ToList();
                return View(cottages);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
     
       
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CottageAddViewModel request)
        {
            if (!ModelState.IsValid)
            {
                
                return View(request);
            }
            try
            {
                if (request.Image.Length > 5 * 1024 * 1024)
                {
                    //Hata
                }
                var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
                if (!allowedTypes.Contains(request.Image.ContentType))
                {
                    // Hata mesajı göster veya işlemi reddet
                }
                var filename = request.Name + DateTime.Now.ToString("yyyymmddhhnnssff") + Path.GetExtension(request.Image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    request.Image.CopyTo(stream);
                }



                _db.Cottages.Add(new Cottage()
                {
                    Name = request.Name,
                    Description = request.Description,
                    RoomCount = request.RoomCount,
                    Title = request.Title,
                    DiscountPrice = request.DiscountPrice,
                    GuestCount = request.GuestCount,
                    DoubleBed = request.DoubleBed,
                    Image = filename,
                    SingleBed = request.SingleBed,
                    Price = request.Price,
                    Status = request.Status
                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }


            return View();
        }
    }
}
