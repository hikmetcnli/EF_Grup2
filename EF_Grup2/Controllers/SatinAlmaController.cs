using EF_Grup2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EF_Grup2.Controllers
{
    public class SatinAlmaController : Controller
    {
        Context c = new Context();
        public IActionResult Liste()
        {
            int MusteriSayisi = c.musteris.ToList().Count;
            int AracSayisi = c.aracs.ToList().Count;

            ViewData["MusteriSayisi"] = MusteriSayisi;
            ViewData["AracSayisi"] = AracSayisi;


            var SatinAlmaListe = c.satinalmas.Include(x => x.musteri).Include(x => x.arac).ToList();

            return View(SatinAlmaListe);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {

            ViewBag.Musteriler = new SelectList(c.musteris, "Id", "Adi");
            ViewBag.Araclar = new SelectList(c.aracs, "Id", "Marka");

            if (id == 0)
            {
                return View();
            }
            else
            {
                return View(c.satinalmas.Find(id));
            }
        }

        [HttpPost]
        public IActionResult Create(SatinAlma satinAlma)
        {
            if (satinAlma.Id == 0)
                c.satinalmas.Add(satinAlma);
            else
                c.satinalmas.Update(satinAlma);

            c.SaveChanges();

            return RedirectToAction("Liste", "SatinAlma");

        }

    }
}
