using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

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
        
        public IActionResult DodajUsluga(int id)
        {
            AddUslugaViewM model = new AddUslugaViewM();
            if(id != 0)
            {
                Usluga u = db.usluga.Find(id);
                model.ID = u.ID;
                model.BrojPacijenata = u.BrojPacijenata;
                model.Napomena = u.Napomena;
                model.Naziv = u.Naziv;
                model.DatumVrijeme = u.DatumVrijeme;
            }
            return View(model);
        }

        public IActionResult PohraniUslugu(AddUslugaViewM m)
        {

            if (m.ID == 0)
            {
                Usluga u = new Usluga
                {
                    //ID = m.ID,
                    Naziv = m.Naziv,
                    DatumVrijeme = m.DatumVrijeme,
                    Napomena = m.Napomena,
                    BrojPacijenata = m.BrojPacijenata

                };
                db.usluga.Add(u);
            }
            else
            {
                Usluga u = db.usluga.Find(m.ID);
                u.ID = m.ID;
                u.BrojPacijenata = m.BrojPacijenata;
                u.Napomena = m.Napomena;
                u.Naziv = m.Naziv;
                u.DatumVrijeme = m.DatumVrijeme;
                db.SaveChanges();
                return View("UrediUslugu");
            }
            db.SaveChanges();
           
            return View();
        }
        public IActionResult PrikaziUsluge()
        {
            UslugaView model = new UslugaView
            {
                podaci = db.usluga.Select(m => new UslugaView.Podaci
                {
                    ID = m.ID,
                    Naziv = m.Naziv,
                    DatumVrijeme = m.DatumVrijeme,
                    Napomena = m.Napomena,
                    BrojPacijenata = m.BrojPacijenata,
                }).ToList()
            };

            return View(model);
        }
        public IActionResult UrediUslugu()
        {
            return View();
        }
        public IActionResult Uklanjanje(int id)
        {
            Usluga usluga = db.usluga.Find(id);
            TempData["keyUkloniUslugu"] = usluga.Naziv;
            db.usluga.Remove(usluga);
            db.SaveChanges();
            
            return View();

        }
        public IActionResult UslugaHome()
        {
            return View();
        }
        public IActionResult RezervisiTermin(int uslugaID)

        { 
            //onemoguciti da broj rezervacija predje broj pacijenata!!
            RezervacijaTermina rz = new RezervacijaTermina();
            rz.UslugaID = uslugaID;
            //rz.KorisnikID = 1; // trebat ce getat logiranog, ovo je default vrijednost
            rz.DatumVrijemeRezervacije = DateTime.Now;
            db.rezervacijaTermina.Add(rz);

            db.SaveChanges();
            return View();
        }
        public IActionResult PrikazRezervisanihTermina()
        {

            RezervacijaTerminaView rz = new RezervacijaTerminaView
            {
                podaci = db.rezervacijaTermina.Select(rz => new RezervacijaTerminaView.Podaci
                {
                    NazivUsluge = rz.usluga.Naziv,
                    //ImePrezime = rz.korisnik.Ime + " " +rz.korisnik.Prezime,
                    DatumRezervacije = rz.DatumVrijemeRezervacije,
                    UslugaID = rz.usluga.ID,
                    //KorisnikID = rz.KorisnikID

                }).ToList()
            };
            return View(rz); 
        }
        public IActionResult ObrisiRezervaciju(int id, int id2)
        {

            SqlCommand command = new SqlCommand(
                "DELETE FROM rezervacijaTermina WHERE UslugaID == '@id' and"
                );
            
            db.SaveChanges();
            return View();
        }
    }
}
