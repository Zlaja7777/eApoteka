using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp_Apoteka.Controllers
{
    public class NabavkaController : Controller
    {
        private readonly UserManager<AppUser> userManager;
   
        private MojDbContext db;

        public NabavkaController(MojDbContext _db, UserManager<AppUser> userManager)
        {
            db = _db;
            this.userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult NabavkaHome()
        {
            return View();
        }
        public IActionResult OpcijeNarucivanja()
        {

            return View();
        }
        public async Task<IActionResult> ZapocniNabavku(int lijekID)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            AddNabavkaViewM ad = new AddNabavkaViewM();
            ad.nazivLijeka = db.Lijek.Where(w => w.LijekID == lijekID).FirstOrDefault().NazivLijeka;
            ad.nabavnaCijena = db.Lijek.Where(w => w.LijekID == lijekID).FirstOrDefault().NabavnaCijena;

            return View( ad);
        }
      

    }
}
