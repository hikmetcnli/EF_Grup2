using System.Diagnostics;
using EF_Grup2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult UrunEkle(int Id)
        {
            if (Id == 0) { //Yeni Ürün Ekle
                return View();
            }
            else //Ürün Güncelleme
            {
                Product p1 = c.Products_.Find(Id);
                return View(p1);
            }


        }
        [HttpPost]
        public IActionResult UrunEkle(Product p)
        {
            if (p.Id == 0) //Yeni Ürün Ekle
            {
                c.Products_.Add(p);
                c.SaveChanges();
            }
            else
            {
                var guncellenecekurun = c.Products_.Find(p.Id);
                guncellenecekurun.Name= p.Name;
                guncellenecekurun.Description= "...";
                //guncellenecekurun.Price= p.Price;

                c.SaveChanges() ;
            }

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

        public IActionResult DepartmanList()
        {
            var liste = new List<SelectListItem>();

            foreach(var item in c.DepartmanList_.ToList())
            {
                liste.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),Text=item.Name
                });
            }

            ViewBag.DepartmanListe = liste;

            ViewBag.AAA = "DOÐAN UÐUR";
            ViewBag.BBB = "HÝKMET CANLI";
            ViewBag.CCC = c.DepartmanList_.ToList();

            return View();
        }

    }
}
