using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_Apoteka.Entity_Framework;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    public class RezervacijaTerminaController : Controller
    {
        // GET: /<controller>/
        private MojDbContext db;

        public RezervacijaTerminaController(MojDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RezervisiTermin()
        {

            return View();
        }
    }
}
