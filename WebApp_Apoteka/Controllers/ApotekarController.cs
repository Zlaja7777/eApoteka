using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apoteka.Models;
using Apoteka.ViewModel;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApoteka_Services;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.ViewModels;

namespace Apoteka.Controllers
{
    public class ApotekarController : Controller
    {
        private readonly IApotekarServices _IApotekar;

        public ApotekarController(IApotekarServices IApotekar)
        {
            _IApotekar = IApotekar;
        }
        public ActionResult DodajForma(int ApotekarID)
        {
            Apotekar a;

            if (ApotekarID == 0)
            {
                a = new Apotekar();
                //ViewData["apotekarKey"] = a

            }
            else
            {
                //ViewData["apotekarKey"] = db.Apotekar.Find(ApotekarID);
                a = _IApotekar.GetByID(ApotekarID);
            }
            //AddApotekarVM model = new AddApotekarVM
            //{
            //    ID = a.ID,
            //    Ime = a.Ime,
            //    Prezime = a.Prezime,
            //    JMBG = a.JMBG,
            //    DatumRodjenja = a.DatumRodjenja,
            //    DatumZaposlenja = a.DatumZaposlenja,
            //    MjestoRodjenjaID = a.MjestoRodjenjaID,
            //    ListaOpstina = _IApotekar.GetAllOpstine().Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Naziv }).ToList()
            //};

            /*List<OpstinaView> opstine = db.Opstina.Select(o => new OpstinaView
            {
                Naziv = o.Naziv,
                ID=o.ID
            }).ToList();
            ViewData["opstinaKey"] = opstine;*/
            return View();
        }

        //public ActionResult SnimiForma(AddApotekarVM aA)
        //{
        //    Apotekar a;
        //    if (aA.ID != 0)
        //    {
        //        a = _IApotekar.GetByID(aA.ID);
        //    }
        //    else
        //    {
        //        a = new Apotekar();
        //    }
        //    a.Ime = aA.Ime;
        //    a.Prezime = aA.Prezime;
        //    a.JMBG = aA.JMBG;
        //    a.DatumRodjenja = aA.DatumRodjenja;
        //    a.MjestoRodjenjaID = aA.MjestoRodjenjaID; 
        //    a.DatumZaposlenja = aA.DatumZaposlenja;
        //    if (aA.ID != 0)
        //    {
        //        _IApotekar.SaveChanges();
        //    }
        //    else
        //    {
        //        _IApotekar.Add(a);
        //    }
        //    return Redirect("PorukaDodano");
        //}
        ////public ActionResult SnimiForma(int ApotekarID, string ImeA,string PrezimeA,string JMBGA,DateTime DatumRodjenjaA, string OpstinaID, DateTime DatumZaposlenjaA)
        ////{
        ////    MojDbContext db = new MojDbContext();
        ////    Apotekar a;
        ////    if(ApotekarID!=0)
        ////    {
        ////        a = db.Apotekar.Find(ApotekarID);
        ////    }
        ////    else
        ////    {
        ////        a = new Apotekar();
        ////        db.Add(a);
        ////    }
        ////    a.Ime = ImeA;
        ////    a.Prezime = PrezimeA;
        ////    a.JMBG = JMBGA;
        ////    a.DatumRodjenja = DatumRodjenjaA;
        ////    a.MjestoRodjenjaID = int.Parse(OpstinaID); //potrebno je unijeti opstine u bazu, ideja je jasna!
        ////    a.DatumZaposlenja = DatumZaposlenjaA;

        ////    db.SaveChanges();
        ////    return Redirect("PorukaDodano"); 
        ////}
        //public ActionResult PorukaDodano()
        //{
        //    return View();
        //}
        //public ActionResult PrikazForma()
        //{
        //    List<ApotekarView> model = _IApotekar.GetAll().Select(a => new ApotekarView
        //    {
        //        ID = a.ID,
        //        Ime = a.Ime,
        //        Prezime = a.Prezime,
        //        JMBG = a.JMBG,
        //        DatumRodjenja = a.DatumRodjenja,
        //        DatumZaposlenja = a.DatumZaposlenja,
        //        MjestoRodjenja = a.MjestoRodjenja.Naziv
        //    }).ToList();
        //    //ViewData["apotekariKey"] = apotekari;
        //    return View(model);
        //}
        //public ActionResult Obrisi(int ApotekarID)
        //{
        //    Apotekar a = _IApotekar.GetByID(ApotekarID);
        //    TempData["ApotekarNaziv"] = a.Ime + " " + a.Prezime;
        //    _IApotekar.ObrisiByID(ApotekarID);
        //    return Redirect("PorukaObrisano");
        //}

        //public ActionResult PorukaObrisano()
        //{
        //    return View();
        //}

        ///*public ActionResult Edit(int ApotekarID)
        //{
        //    MojDbContext db = new MojDbContext();
        //    Apotekar a = db.Apotekar.Find(ApotekarID);
        //    ViewData["apotekarKey"] = a;
        //    List<OpstinaView> opstine = db.Opstina.Select(o => new OpstinaView
        //    {
        //        Naziv = o.Naziv,
        //        ID = o.ID
        //    }).ToList();
        //    ViewData["opstinaKey"] = opstine;
        //    return View();
        //}*/
        ///*public ActionResult SnimiEdit(int ApotekarID, string ImeA,string PrezimeA,string JMBGA,DateTime DatumRodjenjaA,int OpstinaID,DateTime DatumZaposlenjaA)
        //{
        //    MojDbContext db = new MojDbContext();

        //    Apotekar a = db.Apotekar.Find(ApotekarID);
        //    a.Ime = ImeA;
        //    a.Prezime = PrezimeA;
        //    a.JMBG = JMBGA;
        //    a.DatumRodjenja = DatumRodjenjaA;
        //    a.MjestoRodjenjaID = OpstinaID;
        //    a.DatumZaposlenja = DatumZaposlenjaA;

        //    db.SaveChanges();
        //    return Redirect("PorukaEdit");
        //}*/

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