using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
namespace WebApp_Apoteka.Controllers
{
    public class LijekController : Controller
    {
        private MojDbContext db;

        public LijekController(MojDbContext _db)
        {
            db = _db;
        }
        public IActionResult DodajLijek()
        {
            return View();
        }
        public IActionResult PohraniLijek(string NNaziv, string NGeneric, string Nkvan, string NFarm, string NDozir, int NRok, string NProizv, DateTime NDp)
        {
            Lijek l = new Lijek
            {
                NazivLijeka = NNaziv,
                InternacionalniGenerickiNaziv = NGeneric,
                KvalitativniIKvantitativniSastav = Nkvan,
                FarmaceutskiOblik = NFarm,
                NacinPrimjene = NDozir,
                RokTrajanjaMjeseci = NRok,
                NazivProizvodjaca = NProizv,
                DatumProizvodnje = NDp,
                KategorijaID = 1

            };
            db.Lijek.Add(l);
            db.SaveChanges();
            db.Dispose();
            return View();
        }
        public IActionResult Uredi(int id)
        {
            List<Lijek> lijek = db.Lijek.ToList();
            for (int i = 0; i < lijek.Count; i++)
                if (lijek[i].LijekID == id)
                {
                    TempData["kljucLijeka"] = lijek[i];
                    break;
                }
            db.Dispose();
            return View();
        }
        public IActionResult UredjivanjeLijeka(int id, string NNaziv, string NGeneric, string Nkvan, string NFarm, string NDozir, int NRok, string NProizv, DateTime NDp)
        {
            Lijek lijek = db.Lijek.Find(id);
            lijek.NazivLijeka = NNaziv;
            lijek.InternacionalniGenerickiNaziv = NGeneric;
            lijek.KvalitativniIKvantitativniSastav = Nkvan;
            lijek.FarmaceutskiOblik = NFarm;
            lijek.NacinPrimjene = NDozir;
            lijek.RokTrajanjaMjeseci = NRok;
            lijek.NazivProizvodjaca = NProizv;
            lijek.DatumProizvodnje = NDp;

            db.SaveChanges();
            db.Dispose();


            return View("PohranaUredjenogLijeka");
        }
        public IActionResult PrikaziLijekove()
        {
            List<Lijek> lijek = db.Lijek.ToList();
            ViewData["LijekKey"] = lijek;
            db.Dispose();

            return View();
        }
        public IActionResult Uklanjanje(int id)
        {
            Lijek lijek = db.Lijek.Find(id);
            TempData["keyUkloni"] = lijek.NazivLijeka;
            db.Lijek.Remove(lijek);
            db.SaveChanges();
            db.Dispose();
            return View();

        }
    }
}