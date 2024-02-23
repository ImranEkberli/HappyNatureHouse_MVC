using HappyNatureHouse_MVC.Areas.Admin.ViewModels;
using HappyNatureHouse_MVC.Areas.Admin.ViewModels.CottageVMs;
using HappyNatureHouse_MVC.Areas.Admin.ViewModels.ImageVMs;
using HappyNatureHouse_MVC.Data;
using HappyNatureHouse_MVC.Extensions;
using HappyNatureHouse_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

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
                List<CottageViewModel> cottages = _db.Cottages.Include(x => x.CottageImages).Select(x => new CottageViewModel
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
                    Status = x.Status,
                    CottageImages = x.CottageImages != null ? x.CottageImages.Select(z => new PictureViewModel { Id = z.Id, Image = z.Image }).ToList() : new List<PictureViewModel>()
                    //CottagePicture = x.CottageImages !=  null ?
                    //x.CottageImages.Select(y => new CottagePictureViewModel
                    //{
                    //    CottageImages = y.Cottage.CottageImages!.Select(z => new PictureViewModel { Id = z.Id, Image = z.Image }).ToList(),
                    //    CottageId = y.CottageId
                    //}
                    //).First() : new CottagePictureViewModel()

                }).ToList();
                return View(cottages);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
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

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                if (!ImageFileEx.ImageSize(ModelState, request.Image))
                {
                    return View(request);
                }
                string filename = ImageUploadEx.Upload(request.Image);

                _db.Cottages.Add(new Cottage()
                {
                    Name = request.Name,
                    Description = request.Description,
                    RoomCount = request.RoomCount,
                    CreateDate = DateTime.Now,
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
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }

            TempData["SuccessMessage"] = "Yeni Kotec uğurla əlavə olundu.";
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                CottageEditViewModel? cottage = await _db.Cottages.Select(x => new CottageEditViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    Picture = x.Image,
                    SingleBed = x.SingleBed,
                    DoubleBed = x.DoubleBed,
                    GuestCount = x.GuestCount,
                    RoomCount = x.RoomCount,
                    Status = x.Status

                }).FirstOrDefaultAsync(x => x.Id == id);
                if (cottage is null)
                {
                    TempData["FailedOperation"] = "Düzgün əməliyyat yerinə yetirilmədi.";
                    return RedirectToAction("List");
                }
                return View(cottage);
            }
            catch (Exception)
            {

                return new StatusCodeResult(500);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CottageEditViewModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                if (request.Id != id)
                {
                    TempData["FailedOperation"] = "Düzgün əməliyyat yerinə yetirilmədi.";
                    return RedirectToAction("List");
                }
                Cottage? cottage = await _db.Cottages.FirstOrDefaultAsync(x => x.Id == id);

                if (cottage is null)
                {
                    TempData["FailedOperation"] = "Düzgün əməliyyat yerinə yetirilmədi.";
                    return RedirectToAction("List");
                }

                string[] uploads = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\wwwroot\\uploads\\");
                int index = Array.IndexOf(uploads, request.Picture);
                if (request.Image == null && index < 0)
                {
                    TempData["FailedOperation"] = "Xəta var.Şəkil əlavə edin.";
                    return View(request);
                }
                if (request.Image != null)
                {
                    if (!ImageFileEx.ImageSize(ModelState, request.Image))
                    {
                        return View(request);
                    }

                    string filename = ImageUploadEx.Upload(request.Image);
                    cottage.Image = filename;
                }
                cottage.Name = request.Name;
                cottage.Title = request.Title;
                cottage.Description = request.Description;
                cottage.Price = request.Price;
                cottage.DiscountPrice = request.DiscountPrice;
                cottage.ModifierDate = DateTime.Now;
                cottage.Status = request.Status;
                cottage.DoubleBed = request.DoubleBed;
                cottage.SingleBed = request.SingleBed;
                cottage.RoomCount = request.RoomCount;
                cottage.GuestCount = request.GuestCount;
                _db.Cottages.Update(cottage);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Kotec uğurla əlavə olundu.";
                return View();
            }
            catch (Exception)
            {

                return new StatusCodeResult(500);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Cottage? cottage = await _db.Cottages.FirstOrDefaultAsync(x => x.Id == id);
               
                if (cottage is null)
                {
                    TempData["FailedOperation"] = "Düzgün əməliyyat yerinə yetirilmədi.";
                    return RedirectToAction("List");
                }
                List<CottageImage> cottageImages = await _db.CottageImages.Where(x => x.CottageId == id).ToListAsync();
                if (cottageImages.Count() > 0)
                {
                    _db.CottageImages.RemoveRange(cottageImages);
                }
                _db.Cottages.Remove(cottage);
                await _db.SaveChangesAsync();

                ImageUploadEx.DeleteImage(new List<string> { cottage.Image},cottageImages.Select(x=>x.Image).ToList());
                
                TempData["SuccessMessage"] = "Kotec və şəkilləri uğurla silinidi.";
                return RedirectToAction("List");
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }

        }
        [HttpGet("admin/cottage/{cottageid}/pictures")]
        public IActionResult CottagePictures(int cottageid)
        {

            List<CottagePictureViewModel> images = _db.CottageImages.Where(x => x.CottageId == cottageid).Select(z => new CottagePictureViewModel
            {
                CottageId = z.CottageId,
                CottageImages = z != null ? z.Cottage.CottageImages!.Select(x=> new PictureViewModel() { Id = x.Id,Image = x.Image}).ToList() : new List<PictureViewModel>()
            }).ToList();
            return View(images);
        }
        [HttpGet("/admin/cottage/{cottageid}/pictureadd")]
        public IActionResult PictureAdd(int cottageid)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PictureAdd(int cottageid, PictureAddViewModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                if (!ImageFileEx.ImageSize(ModelState, request.Image))
                {
                    return View(request);
                }
                if (!_db.Cottages.Any(x=>x.Id == cottageid))
                {
                    TempData["FailedOperation"] = "Düzgün əməliyyat yerinə yetirilmədi.";
                    return RedirectToAction("List");
                }
                string filename = ImageUploadEx.Upload(request.Image);
                _db.CottageImages.Add(new CottageImage
                {
                    Image = filename,
                    CottageId = cottageid               
                });
                return View();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PictureDelete(int id,int cottageid)
        {
            try
            {
                CottageImage? image = await _db.CottageImages.FirstOrDefaultAsync(x=>x.Id == id && x.CottageId == cottageid);
                if (image is null)
                {
                    TempData["FailedOperation"] = "Düzgün əməliyyat yerinə yetirilmədi.";
                    return RedirectToAction("List");
                }
                ImageUploadEx.DeleteImage(new List<string> { image.Image });
                _db.CottageImages.Remove(image);
                await _db.SaveChangesAsync();

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            TempData["SuccessMessage"] = "Şəkil uğurla silinidi.";
            // return Redirect($"admin/cottage/{cottageid}/pictures");
            return RedirectToAction("cottagepictures","cottage",cottageid);
        }

    }
}
