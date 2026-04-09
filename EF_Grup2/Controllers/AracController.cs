using EF_Grup2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Grup2.Controllers
{
    public class AracController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View(c.aracs.ToList());
        }


        [HttpGet]
        public IActionResult AracEkle(int id)
        {
            if (id == 0)
                return View();
            else
                return View(c.aracs.Find(id));

        }

        [HttpPost]
        public IActionResult AracEkle(Arac arac, IFormFile ResimYolu)
        {
            if (ResimYolu!=null && ResimYolu.Length > 0)
            {
                //var dosyaadi = Path.GetFileName(ResimYolu.FileName);
                var dosyaAdi = Path.GetFileNameWithoutExtension(ResimYolu.FileName) + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + Path.GetExtension(ResimYolu.FileName);

                var dosyayolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AracResimleri", dosyaAdi);

                using (var filestream = new FileStream(dosyayolu,FileMode.Create))
                {
                    ResimYolu.CopyTo(filestream);
                }

                arac.ResimYolu ="/AracResimleri/" + dosyaAdi;

            }



            if (arac.Id == 0)
                c.aracs.Add(arac);
            else
                c.aracs.Update(arac);

            c.SaveChanges();

            return RedirectToAction("Index", "Arac");

        }


        public IActionResult AracSil(int id)
        {
            var silinecekarac = c.aracs.Find(id);
            c.aracs.Remove(silinecekarac);
            c.SaveChanges();
            return RedirectToAction("Index", "Arac");
        }
    }
}
