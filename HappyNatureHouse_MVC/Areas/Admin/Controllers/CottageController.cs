using HappyNatureHouse_MVC.Areas.Admin.ViewModels;
using HappyNatureHouse_MVC.Data;
using HappyNatureHouse_MVC.Models;
using Microsoft.AspNetCore.Http;
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
            return View();
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
            if (request.Image.Length > 5 * 1024 * 1024) 
            {
               //Hata
            }
            var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            if (!allowedTypes.Contains(request.Image.ContentType))
            {
                // Hata mesajı göster veya işlemi reddet
            }
            var filename = request.Name+DateTime.Now.ToString("yyyymmddhhnnssff") + Path.GetExtension(request.Image.FileName);
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

            return View();
        }
    }
}
