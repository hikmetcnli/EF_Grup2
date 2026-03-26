using EF_Grup2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Grup2.Controllers
{
    public class SatinAlmaController : Controller
    {
        Context c = new Context();
        public IActionResult Liste()
        {
            var SatinAlmaListe = c.satinalmas.Include(x => x.musteri).Include(x => x.arac).ToList();

            return View(SatinAlmaListe);
        }
    }
}
