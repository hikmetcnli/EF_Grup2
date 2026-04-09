using EF_Grup2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Grup2.Controllers
{
    public class MusteriController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View(c.musteris.ToList());
        }


        [HttpGet]
        public IActionResult MusteriEkle(int id)
        {
            if (id == 0)
                return View();
            else
                return View(c.musteris.Find(id));
             
        }

        [HttpPost]
        public IActionResult MusteriEkle(Musteri musteri)
        {
            if (musteri.Id == 0)
               c.musteris.Add(musteri);
            else
                c.musteris.Update(musteri);

            c.SaveChanges();

           return RedirectToAction("Index","Musteri");

        }


        public IActionResult MusteriSil(int id)
        {
            var silinecekmusteri = c.musteris.Find(id);
            c.musteris.Remove(silinecekmusteri);
            c.SaveChanges( );
            return RedirectToAction("Index", "Musteri");
        }



    }
}
