using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    public class UslugaController: Controller
    {
        private MojDbContext db;

        public UslugaController(MojDbContext _db)
        {
            db = _db;
        }
        
        public IActionResult DodajUsluga()
        {
            return View();
        }

        public IActionResult PohraniUslugu(string NNaziv, DateTime NDatumVrijeme, string NNapomena, int NBrojPacijenata)
        {
            Usluga u = new Usluga
            {
                Naziv = NNaziv,
                DatumVrijeme = NDatumVrijeme,
                Napomena = NNapomena,
                BrojPacijenata = NBrojPacijenata

            };
            db.usluga.Add(u);
            db.SaveChanges();
            db.Dispose();
            return View();
        }
        public IActionResult PrikazUsluga()
        {
            List<Usluga> usluga = db.usluga.ToList();
            ViewData["PrikazUslugaKey"] = usluga;
            db.Dispose();

            return View();
        }
        public IActionResult Uklanjanje(int id)
        {
            Usluga usluga = db.usluga.Find(id);
            TempData["keyUkloniUslugu"] = usluga.Naziv;
            db.usluga.Remove(usluga);
            db.SaveChanges();
            db.Dispose();
            return View();

        }
        public IActionResult UredjivanjeUsluge(int id, string NNaziv, DateTime NDatumVrijeme, string NNapomena, int NBrojPacijenata)
        {
            Usluga usluga = db.usluga.Find(id);
            usluga.Naziv = NNaziv;
            usluga.DatumVrijeme = NDatumVrijeme;
            usluga.Napomena = NNapomena;
            usluga.BrojPacijenata = NBrojPacijenata;
            db.SaveChanges();
            db.Dispose();
            return View("PohranaUredjeneUsluge");
        }
       
        public IActionResult Uredi(int id)
        {
            var usluga = db.usluga.ToList();
            for (int i = 0; i < usluga.Count; i++)
                if (usluga[i].ID == id)
                {
                    TempData["kljucUsluge"] = usluga[i];

                    break;
                }
            db.Dispose();
            return View();
        }
        public IActionResult UslugaHome()
        {
            return View();
        }
    }
}
