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
        public IActionResult DodajLijek()
        {
            return View();
        }
        public IActionResult PohraniLijek(string NNaziv, string NGeneric, string Nkvan, string NFarm, string NDozir, int NRok, string NProizv, DateTime NDp)
        {
            MojDbContext db = new MojDbContext();
            Lijek l = new Lijek
            {
                NazivLijeka = NNaziv,
                InternacionalniGenerickiNaziv = NGeneric,
                KvalitativniIKvantitativniSastav = Nkvan,
                FarmaceutskiOblik = NFarm,
                NacinPrimjene = NDozir,
                RokTrajanjaMjeseci = NRok,
                NazivProizvodjaca = NProizv,
                DatumProizvodnje = NDp

            };
            db.Lijek.Add(l);
            db.SaveChanges();
            db.Dispose();
            return View();
        }
        public IActionResult Uredi(int id)
        {
            MojDbContext db = new MojDbContext();
            List<Lijek> lijek = db.Lijek.ToList();
            for (int i = 0; i < lijek.Count; i++)
                if(lijek[i].LijekID == id)
                {
                    TempData["kljucLijeka"] = i;
                    break;
                }
            db.Dispose();
            return View();
        }
        public IActionResult UredjivanjeLijeka(int id, string NNaziv, string NGeneric, string Nkvan, string NFarm, string NDozir, int NRok, string NProizv, DateTime NDp)
        {
            MojDbContext db = new MojDbContext();
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
            MojDbContext db = new MojDbContext();
            List<Lijek> lijek = db.Lijek.ToList();
            ViewData["LijekKey"] = lijek;
            db.Dispose();

            return View();
        }
        public IActionResult Uklanjanje(int id)
        {
            MojDbContext db = new MojDbContext();
            Lijek lijek = db.Lijek.Find(id);
            TempData["keyUkloni"] = lijek.NazivLijeka;
            db.Lijek.Remove(lijek);
            db.SaveChanges();
            db.Dispose();
            return View();

        }
    }
}