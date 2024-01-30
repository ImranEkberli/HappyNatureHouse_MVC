using HappyNatureHouse_MVC.Areas.Admin.ViewModels.AuthVMs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HappyNatureHouse_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminLoginViewModel request)
        {
            //if (true)
            //{
            //    var claims = new List<Claim>()
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            //        new Claim(ClaimTypes.Name, usuario.Nome),
            //        new Claim(ClaimTypes.GivenName, usuario.Login)
            //    };

            //    var identity = new ClaimsIdentity(claims, "CookieAuth");
            //    var principal = new ClaimsPrincipal(identity);


            //    await HttpContext.SignInAsync("Authtoken", principal);

            //    return RedirectToAction("Index", "Home");
            //}
            return View();
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


            return RedirectToAction("Login","Auth");
        }
    }
}
