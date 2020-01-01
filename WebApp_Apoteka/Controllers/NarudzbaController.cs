using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    public class NarudzbaController : Controller
    {
        private MojDbContext db;

        public NarudzbaController(MojDbContext _db)
        {
            db = _db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajLijekNarudzbu(int lijekID)
        {
            AddDetaljiOnlineNarudzbeViewM model = new AddDetaljiOnlineNarudzbeViewM();
            model.lijekID = lijekID;
            //model.onlineNarudzbaID
            return View();
        }
        public IActionResult DodajNarudzbu(int idNarudzbe)
        {
            AddOnlineNarudzbaViewM model = new AddOnlineNarudzbaViewM
            {
                opstine = db.Opstina.Select(o => new SelectListItem {

                    Value = o.ID.ToString(), Text = o.Naziv
                }).ToList()
            };


            return View();
        }
        public IActionResult DodajUKosaricu(int id, int kosaricaID)
        {
            
            if (kosaricaID != 0)
            {
                var model = db.kosarica.Find(id);
                model.LijekID = id;
                model.KorisnikID = 1; //treba getat logiranog ili traziti registraciju
            }
            else
            {
                AddKosaricaViewM model = new AddKosaricaViewM();
                model.KosaricaID = kosaricaID;
                model.LijekID = id;
                model.KorisnikID = 1; //treba getat logiranog ili traziti registraciju
            }


            return View();
        }
        public IActionResult PrikaziKosaricu()
        {
            return View();
        }

    }
}
