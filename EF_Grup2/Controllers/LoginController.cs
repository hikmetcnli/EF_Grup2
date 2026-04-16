using System.Security.Claims;
using System.Threading.Tasks;
using EF_Grup2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EF_Grup2.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var puser = c.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            if (puser == null) //Hatalı kullanıcı adı veya şifre
            {
                ViewBag.HataMesaji = "Hatalı Kullanıcı adı veya şifre !";
                return View();
            }
            else
            {

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,puser.Username),
                    new Claim(ClaimTypes.Role,puser.Role)
                };

                var ClaimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var ClaimProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimIdentity), ClaimProperties);


                return RedirectToAction("Liste", "Satinalma");
            }


        }

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

    }
}
