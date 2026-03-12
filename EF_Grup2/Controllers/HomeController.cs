using System.Diagnostics;
using EF_Grup2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Grup2.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        { 
            var ProductList = c.Products_.ToList(); 

            return View(ProductList);
        }
       
        [HttpGet]
        public IActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UrunEkle(Product p)
        {
            c.Products_.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UrunSil(int id)
        {
            var p = c.Products_.Find(id);
            //var p1 = c.Products_.Where(y=> y.Id==id).FirstOrDefault();

            if (p != null)
            {
                c.Products_.Remove(p);
                c.SaveChanges();
            }

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Privacy()
        {
            return View();
        }
         
    }
}
