using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    public class NabavkaController : Controller
    {
        private readonly UserManager<AppUser> userManager;
   
        private MojDbContext db;

        public NabavkaController(MojDbContext _db, UserManager<AppUser> userManager)
        {
            db = _db;
            this.userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult NabavkaHome()
        {
            return View();
        }
        public IActionResult OpcijeNarucivanja()
        {

            return View();
        }
        public async Task<IActionResult> ZapocniNabavku(int lijekID)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            AddNabavkaViewM ad = new AddNabavkaViewM();
            ad.nazivLijeka = db.Lijek.Where(w => w.LijekID == lijekID).FirstOrDefault().NazivLijeka;
            ad.nabavnaCijena = db.Lijek.Where(w => w.LijekID == lijekID).FirstOrDefault().NabavnaCijena;

            return View( ad);
        }
        public async Task<IActionResult>  PrikaziStanje()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            LijekKolicinaView lk = new LijekKolicinaView
            {
                podaci = db.Lijek.Select(s => new LijekKolicinaView.Podaci
                {
                    lijekID = s.LijekID,
                    nabavnaCijenaLijeka = s.NabavnaCijena,
                    nazivLijeka = s.NazivLijeka,
                    kolicina = s.Kolicina
                }).ToList()
            };

            int stanjeKosarice = db.kosarica.Where(w => w.KorisnikID == user.Id).ToList().Count();
            ViewData["stanjeKosarice"] = stanjeKosarice;

            return View(lk);
        }
        public async Task<IActionResult> NabavnaKosarica(int lijekID, int kolicina)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Kosarica k = new Kosarica();
            k.LijekID = lijekID;
            k.kolicina = kolicina;
            k.KorisnikID = user.Id;

            db.Add(k);
            db.SaveChanges();
           
            return PartialView("PrikaziStanje");
        }
        public IActionResult PrikaziLijek(int lijekID)
        {
            LijekKolicinaView lk = db.Lijek.Select(s => new LijekKolicinaView
            {
                lijekID = s.LijekID,
             
                nabavnaCijenaLijeka = s.NabavnaCijena,
                nazivLijeka = s.NazivLijeka
                
            }).FirstOrDefault();
            
            return PartialView("AjaxPrikazLijeka", lk);
        }

    
        public async Task<IActionResult> DodajKosaricu(LijekKolicinaView lw)
         {


                if (ModelState.IsValid )
                {
                    Kosarica ad = new Kosarica();
                    var user = await userManager.GetUserAsync(HttpContext.User);
                    ad.KorisnikID = user.Id;
                    ad.LijekID = lw.lijekID;
                    ad.kolicina = lw.kolicina;
                    db.kosarica.Add(ad);
                    db.SaveChanges();
                    return Redirect("PrikaziStanje");
                }
                else
                {
                    LijekKolicinaView lw2 = db.Lijek.Where(w=>w.LijekID == lw.lijekID).Select(s => new LijekKolicinaView
                    {
                       lijekID = s.LijekID,
                       nazivLijeka = s.NazivLijeka,
                       nabavnaCijenaLijeka = s.NabavnaCijena,
                       pronadjenError = true

                    }).FirstOrDefault();
                    return View("AjaxPrikazLijeka", lw2);
                }

            
        }
      


    }
}
