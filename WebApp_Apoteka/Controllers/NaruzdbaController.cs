using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    public class NarudzbaController : Controller
    {
        private readonly UserManager<AppUser> userManager;
   
        private MojDbContext db;

        public NarudzbaController(MojDbContext _db, UserManager<AppUser> userManager)
        {
            db = _db;
            this.userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        private bool ProvjeriKošaricu(int lijekID, string loggedUser)
        {
            if (db.kosarica.Where(w=>w.LijekID == lijekID && loggedUser == w.KorisnikID).Any())
            {
                return true;
            }
            return false;
        }
        public async Task<IActionResult> DodajUKosaricu(LijekView lw)
        {
           

            if (ModelState.IsValid && lw.OdabranaKolicina <= lw.Kolicina)
            {
                Kosarica ad = new Kosarica();
                var user = await userManager.GetUserAsync(HttpContext.User);
                ad.KorisnikID = user.Id;
                ad.LijekID = lw.LijekID;
                ad.kolicina = lw.OdabranaKolicina;
                db.kosarica.Add(ad);
                db.SaveChanges();
                return Redirect("/Lijek/PrikaziLijekove");
            }
            else
            {
                return RedirectToAction("PrikaziLijek", new { id = lw.LijekID, odabranaKolicina = lw.OdabranaKolicina});
            }
        }
        
        public async Task<IActionResult> PregledKosarice()
        {
        
            var user = await userManager.GetUserAsync(HttpContext.User);
            KosaricaView kw = new KosaricaView
            {

                podaci = db.kosarica.Where(s => s.KorisnikID == user.Id).Select(k => new KosaricaView.Podaci
                {

                    KosaricaID = k.KosaricaID,
                    NazivLijeka = k.Lijek.NazivLijeka,
                    Kolicina = k.kolicina,
                    Cijena = k.Lijek.ProdajnaCijena

                }).ToList()
             };
            int stanjeKosarice = db.kosarica.Where(w => w.KorisnikID == user.Id).ToList().Count();
            ViewData["stanjeKosarice"] = stanjeKosarice;

            return View(kw);
            
           
        }
        public async Task<IActionResult> ZapocniNarudzbu()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            AddOnlineNarudzbaViewM md = new AddOnlineNarudzbaViewM
            {
                opstine = db.Opstina.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.Naziv }).ToList(),
              
                
            };
            Korisnik k = db.korisnik.Where(s => user.KorisnikID == s.ID).Select(s => new Korisnik { Ime = s.Ime, Prezime = s.Prezime, Telefon = s.Telefon }).FirstOrDefault();
          
            
            KosaricaView kw = new KosaricaView
            {
                podaci = db.kosarica.Where(s => s.KorisnikID == user.Id).Select(k => new KosaricaView.Podaci
                {

                    KosaricaID = k.KosaricaID,
                    NazivLijeka = k.Lijek.NazivLijeka,
                    Kolicina = k.kolicina,
                    Cijena = k.Lijek.ProdajnaCijena

                }).ToList()
            };
            
            ViewData["korisnik"] = k;
            ViewData["podaci"] = kw;


            return View(md);
            
        }
        public async Task<IActionResult> ObrisiKosaricu(int id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Kosarica k = db.kosarica.Find(id);

            db.Remove(k);
            db.SaveChanges();
            if (db.kosarica.Where(w=>w.KorisnikID == user.Id).ToList().Count() == 0)
            {
                return Redirect("/Lijek/PrikaziLijekove");
            }
            return Redirect("/Narudzba/PregledKosarice");
        }
        public async Task<IActionResult> DodajNarudzbu(AddOnlineNarudzbaViewM md)
        {
            List<Kosarica> podaci = db.kosarica.ToList(); 
            var user = await userManager.GetUserAsync(HttpContext.User);
            
            OnlineNarudzba n = new OnlineNarudzba();
            n.ID = md.ID;
            n.korisnikID = user.Id;
            n.gradDostaveID = md.gradDostaveID;
            n.adresaDostave = md.adresaDostave;
            n.cijenaDostave = md.cijenaDostave;
            n.vrijednostNarudzbe = md.vrijednostNarudzbe;
            n.datum = DateTime.Now;
            db.onlineNarudzba.Add(n);
            db.SaveChanges();


            DetaljiOnlineNarudzbe dn = new DetaljiOnlineNarudzbe();
            dn.onlineNarudzbaID = n.ID;
            foreach (var l in podaci)
            {
                if (user.Id == l.KorisnikID)
                {
                    dn.lijekID = l.LijekID;
                    dn.kolicina = l.kolicina;
                    dn.cijenaLijeka = db.Lijek.Where(w=>w.LijekID == l.LijekID).FirstOrDefault().ProdajnaCijena;
                    dn.ukupnaCijenaStavke = dn.cijenaLijeka * dn.kolicina;
                    db.detaljiOnlineNarudzbe.Add(dn);
                    Lijek lijek = db.Lijek.Find(l.LijekID);
                    lijek.Kolicina -= dn.kolicina;
                    db.Update(lijek);
                    db.SaveChanges();
                }
            }

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = db.GetConnectionString();
            sql.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.CommandText = "delete from kosarica where KorisnikID= '" + user.Id + "'";

            cmd.ExecuteNonQuery();
            db.SaveChanges();
            return View();
        }
        public async Task<IActionResult> PrikaziLijek(int id, int odabranaKolicina)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (ProvjeriKošaricu(id, user.Id))
            {
                bool pronadjen = true;
               
                return RedirectToAction("PrikaziLijekove", "Lijek", new { pronadjen1 = pronadjen });
            }
            LijekView model = new LijekView
            {
                podaci = db.Lijek.Where(s=> s.LijekID == id).Select(m => new LijekView.Podaci
                {
                    LijekID = m.LijekID,
                    NazivLijeka = m.NazivLijeka,
                   
                    KvalitativniIKvantitativniSastav = m.KvalitativniIKvantitativniSastav,
                    FarmaceutskiOblik = m.FarmaceutskiOblik,
                    NacinPrimjene = m.NacinPrimjene,
                    RokTrajanjaMjeseci = m.RokTrajanjaMjeseci,
                    NazivProizvodjaca = m.NazivProizvodjaca,
                    DatumProizvodnje = m.DatumDodavanjaUPromet,
                    NazivKategorije = m.Kategorija.NazivKategorije,
                    NabavnaCijena = m.NabavnaCijena,
                    ProdajnaCijena = m.ProdajnaCijena,
                   
                }).ToList(), Kolicina = db.Lijek.Where(w=>w.LijekID == id).FirstOrDefault().Kolicina, LijekID = db.Lijek.Where(w => w.LijekID == id).FirstOrDefault().LijekID

            };
            
            model.OdabranaKolicina = odabranaKolicina;
         
            return View(model);
        }


    }
}
