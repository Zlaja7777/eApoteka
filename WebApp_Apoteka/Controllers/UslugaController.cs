using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> userManager;
        public UslugaController(MojDbContext _db, UserManager<AppUser> userManager)
        {
            db = _db;
            this.userManager = userManager;
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
        public async Task<IActionResult> RezervisiTermin(int uslugaID)

        { 
            //onemoguciti da broj rezervacija predje broj pacijenata!!
            RezervacijaTermina rz = new RezervacijaTermina();
            rz.UslugaID = uslugaID;

            var user = await userManager.GetUserAsync(HttpContext.User);
            rz.KorisnikID = user.Id;
       
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
                    ImePrezime = rz.korisnik.korisnik.Ime+ " " +rz.korisnik.korisnik.Prezime,
                    DatumRezervacije = rz.DatumVrijemeRezervacije,
                    UslugaID = rz.usluga.ID,
                    KorisnikID = rz.KorisnikID,

                }).ToList()
            };
            return View(rz); 
        }
        public async Task<IActionResult> ObrisiRezervaciju(int id)
        {

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = db.GetConnectionString();
            sql.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            var user = await userManager.GetUserAsync(HttpContext.User);
            string userID = user.Id;


            cmd.CommandText = "delete from rezervacijaTermina where UslugaID=" + id + " and KorisnikID= '" + userID + "'";

            cmd.ExecuteNonQuery();
            db.SaveChanges();
            return View();
        }
    }
}
