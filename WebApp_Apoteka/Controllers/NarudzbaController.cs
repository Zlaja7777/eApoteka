using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
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
        public IActionResult DodajUKosaricu()
        {
            AddKosaricaViewM ad = new AddKosaricaViewM();
            
            
            return View();
        }
        public IActionResult PrikaziLijek(int id)
        {
            
            Lijek l = db.Lijek.Find(id);
            return View(l);
        }

    }
}
