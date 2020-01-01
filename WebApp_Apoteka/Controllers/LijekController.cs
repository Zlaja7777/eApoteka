using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;
namespace WebApp_Apoteka.Controllers
{
    public class LijekController : Controller
    {
        private MojDbContext db;

        public LijekController(MojDbContext _db)
        {
            db = _db;
        }
        public IActionResult DodajLijek(int id)
        {
            AddLijekViewM model = new AddLijekViewM
            {
                ListaKategorija = db.kategorija.Select(k => new SelectListItem { Value = k.KategorijaID.ToString(), Text = k.NazivKategorije }).ToList()
            };
            if(id != 0)
            {
                Lijek l = db.Lijek.Find(id);
                model.LijekID = l.LijekID;
                model.NazivLijeka = l.NazivLijeka ;
                model.InternacionalniGenerickiNaziv = l.InternacionalniGenerickiNaziv;
                model.KvalitativniIKvantitativniSastav = l.KvalitativniIKvantitativniSastav;
                model.FarmaceutskiOblik = l.FarmaceutskiOblik;
                model.NacinPrimjene = l.NacinPrimjene;
                model.RokTrajanjaMjeseci = l.RokTrajanjaMjeseci;
                model.NazivProizvodjaca = l.NazivProizvodjaca;
                model.DatumProizvodnje = l.DatumProizvodnje;
                model.KategorijeID = l.KategorijaID;
                model.NabavnaCijena = l.NabavnaCijena;
                model.ProdajnaCijena = l.ProdajnaCijena;
            }
            return View(model);
        }
        public IActionResult PohraniLijek(AddLijekViewM m)
        {
            if (m.LijekID == 0)
            {
                Lijek lijek = new Lijek
                {
                    LijekID = m.LijekID,
                    NazivLijeka = m.NazivLijeka,
                    InternacionalniGenerickiNaziv = m.InternacionalniGenerickiNaziv,
                    KvalitativniIKvantitativniSastav = m.KvalitativniIKvantitativniSastav,
                    FarmaceutskiOblik = m.FarmaceutskiOblik,
                    NacinPrimjene = m.NacinPrimjene,
                    RokTrajanjaMjeseci = m.RokTrajanjaMjeseci,
                    NazivProizvodjaca = m.NazivProizvodjaca,
                    DatumProizvodnje = m.DatumProizvodnje,
                    KategorijaID = m.KategorijeID,
                    NabavnaCijena = m.NabavnaCijena,
                    ProdajnaCijena = m.ProdajnaCijena,
                };
                db.Lijek.Add(lijek);
            }
            else
            {
                Lijek l = db.Lijek.Find(m.LijekID);
      
                l.NazivLijeka = m.NazivLijeka;
                l.InternacionalniGenerickiNaziv = m.InternacionalniGenerickiNaziv;
                l.KvalitativniIKvantitativniSastav = m.KvalitativniIKvantitativniSastav;
                l.FarmaceutskiOblik = m.FarmaceutskiOblik;
                l.NacinPrimjene = m.NacinPrimjene;
                l.RokTrajanjaMjeseci = m.RokTrajanjaMjeseci;
                l.NazivProizvodjaca = m.NazivProizvodjaca;
                l.DatumProizvodnje = m.DatumProizvodnje;
                l.KategorijaID = m.KategorijeID;
                l.NabavnaCijena = m.NabavnaCijena;
                l.ProdajnaCijena = m.ProdajnaCijena;
                db.SaveChanges();
                return View("PohranaUredjenogLijeka");
            }
           
            db.SaveChanges();
           
            return View();
        }
        
       
        public IActionResult PrikaziLijekove()
        {

            LijekView model = new LijekView
            {
                podaci = db.Lijek.Select(m => new LijekView.Podaci
                {
                    LijekID = m.LijekID,
                    NazivLijeka = m.NazivLijeka,
                    InternacionalniGenerickiNaziv = m.InternacionalniGenerickiNaziv,
                    KvalitativniIKvantitativniSastav = m.KvalitativniIKvantitativniSastav,
                    FarmaceutskiOblik = m.FarmaceutskiOblik,
                    NacinPrimjene = m.NacinPrimjene,
                    RokTrajanjaMjeseci = m.RokTrajanjaMjeseci,
                    NazivProizvodjaca = m.NazivProizvodjaca,
                    DatumProizvodnje = m.DatumProizvodnje,
                    NazivKategorije = m.Kategorija.NazivKategorije,
                    NabavnaCijena = m.NabavnaCijena,
                    ProdajnaCijena = m.ProdajnaCijena,
                }).ToList()
            };
          

            List<KosaricaView> kosarica = db.kosarica.Select(s => new KosaricaView
            {
                KosaricaID = s.KosaricaID,
     
            }).ToList();

            ViewData["kosaricaKey"] = kosarica;
            return View(model);
        }
        public IActionResult Uklanjanje(int id)
        {
            Lijek lijek = db.Lijek.Find(id);
            TempData["keyUkloni"] = lijek.NazivLijeka;
            db.Lijek.Remove(lijek);
            db.SaveChanges();
            return View();

        }
    }
}