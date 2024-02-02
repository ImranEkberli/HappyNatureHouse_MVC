using CryptoHelper;
using HappyNatureHouse_MVC.Areas.Admin.ViewModels.AuthVMs;
using HappyNatureHouse_MVC.Data;
using HappyNatureHouse_MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HappyNatureHouse_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly DataContext _db;

        public AuthController(DataContext db)
        {
            _db = db;
        }

        public async IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            AdminUser? admin = await _db.AdminUsers.FirstOrDefaultAsync(x => x.Email == request.Email && Crypto.VerifyHashedPassword(x.Password, request.Password));
            if (admin is null)
            {
                ModelState.AddModelError(string.Empty, "Istifadəçi adı və şifrə yanlışdır.");
                return View(request);
            }
            List<Claim> claims = new List<Claim>(){ };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync("Authtoken", principal);

            return RedirectToAction("Index", "Home");

        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Authtoken");
            return RedirectToAction("Login", "Auth");
        }
        public IActionResult Register()
        {
            string email = "imran.ekberli@gmail.com";
            string password = "imran____@@@@!!!!";


            return RedirectToAction("Login", "Auth");
        }
    }
}
