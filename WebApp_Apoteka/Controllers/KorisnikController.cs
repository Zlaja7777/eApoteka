using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apoteka.Models;
using Apoteka.ViewModel;
using Microsoft.AspNetCore.Mvc;
using WebApp_Apoteka.Entity_Framework;

namespace Apoteka.Controllers
{
    public class KorisnikController : Controller
    {
        public ActionResult DodajForma()
        {
            MojDbContext db = new MojDbContext();
            List<OpstinaView> opstine = db.Opstina.Select(o => new OpstinaView
            {
                Naziv = o.Naziv,
                ID=o.ID
            }).ToList();
            ViewData["opstinaKey"] = opstine;
            return View();
        }
        public ActionResult SnimiForma(string ImeA,string PrezimeA,string JMBGA,DateTime DatumRodjenjaA, string OpstinaID, DateTime DatumZaposlenjaA)
        {
            MojDbContext db = new MojDbContext();

            Apotekar a = new Apotekar();
            a.Ime = ImeA;
            a.Prezime = PrezimeA;
            a.JMBG = JMBGA;
            a.DatumRodjenja = DatumRodjenjaA;
            a.MjestoRodjenjaID = int.Parse(OpstinaID); //potrebno je unijeti opstine u bazu, ideja je jasna!
            a.DatumZaposlenja = DatumZaposlenjaA;

            db.Add(a);
            db.SaveChanges();
            return Redirect("PorukaDodano"); 
        }
        public ActionResult PorukaDodano()
        {
            return View();
        }
        public ActionResult PrikazForma()
        {
            MojDbContext db = new MojDbContext();
            List<ApotekarView> apotekari= db.Apotekar.Select(a => new ApotekarView
            {
                ID = a.ID,
                Ime=a.Ime,
                Prezime=a.Prezime,
                JMBG=a.JMBG,
                DatumRodjenja=a.DatumRodjenja,
                DatumZaposlenja=a.DatumZaposlenja,
                MjestoRodjenja=a.MjestoRodjenja.Naziv
            }).ToList();
            ViewData["apotekariKey"] = apotekari;
            return View();
        }
        public ActionResult Obrisi(int ApotekarID)
        {
            MojDbContext db = new MojDbContext();
            Apotekar a = db.Apotekar.Find(ApotekarID);
            db.Remove(a);
            TempData["ApotekarNaziv"] = a.Ime + " "+ a.Prezime;
            db.SaveChanges();
            db.Dispose();

            return Redirect("PorukaObrisano");
        }

        public ActionResult PorukaObrisano()
        {
            return View();
        }

        public ActionResult Edit(int ApotekarID)
        {
            MojDbContext db = new MojDbContext();
            Apotekar a = db.Apotekar.Find(ApotekarID);
            ViewData["apotekarKey"] = a;
            List<OpstinaView> opstine = db.Opstina.Select(o => new OpstinaView
            {
                Naziv = o.Naziv,
                ID = o.ID
            }).ToList();
            ViewData["opstinaKey"] = opstine;
            return View();
        }
        public ActionResult SnimiEdit(int ApotekarID, string ImeA,string PrezimeA,string JMBGA,DateTime DatumRodjenjaA,int OpstinaID,DateTime DatumZaposlenjaA)
        {
            MojDbContext db = new MojDbContext();

            Apotekar a = db.Apotekar.Find(ApotekarID);
            a.Ime = ImeA;
            a.Prezime = PrezimeA;
            a.JMBG = JMBGA;
            a.DatumRodjenja = DatumRodjenjaA;
            a.MjestoRodjenjaID = OpstinaID;
            a.DatumZaposlenja = DatumZaposlenjaA;

            db.SaveChanges();
            return Redirect("PorukaEdit");
        }

        public ActionResult PorukaEdit()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}