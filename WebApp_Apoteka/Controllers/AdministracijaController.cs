using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

namespace WebApp_Apoteka.Controllers
{
    public class AdministracijaController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdministracijaController(RoleManager<IdentityRole> role,
                                        UserManager<AppUser> userManager)
        {
            roleManager = role;
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("RolePrikaz", "Administracija");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public async Task<AppUser> GetCurrentUser()
        {
            //var user = await userManager.GetUserAsync(HttpContext.User);
            var user= await userManager.GetUserAsync(HttpContext.User);
            return user;
        }

        public IActionResult RolePrikaz()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }


        [HttpGet]
        public async Task<IActionResult> UrediUlogu(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID = {id} nije pronadjenja!";
                return View("NotFound");
            }
            var model = new EditRoleVM
            {
                ID = role.Id,
                RoleName = role.Name,


            };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UrediUlogu(EditRoleVM model)
        {
            var role = await roleManager.FindByIdAsync(model.ID);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID = {model.ID} nije pronadjenja!";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("roleprikaz");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddRemoveKorisnikaUlogu(string UlogaID)
        {
            ViewBag.UlogaID = UlogaID;
            var Uloga = await roleManager.FindByIdAsync(UlogaID);
            if (Uloga == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID = {UlogaID} nije pronadjena!";
                return View("NotFound");
            }
            ViewBag.NazivUloge = Uloga.Name;
            var model = new List<KorisnikUlogaVM>();
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, Uloga.Name))
                {

                    var korisnikUlogaVM = new KorisnikUlogaVM
                    {
                        UserID = user.Id,
                        UserName = user.UserName
                    };
                    model.Add(korisnikUlogaVM);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> DodijeliUlogu(DodijeliUloguVM model)
        {
            var role = await roleManager.FindByNameAsync(model.nazivUloge);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa nazivom = {model.nazivUloge} nije pronadjena!";
                return View("NotFound");
            }
            var user = await userManager.FindByIdAsync(model.korisnikID);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Korisnik sa ID = {model.korisnikID} nije pronadjen!";
                return View("NotFound");
            }
            var result = await userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction("AddRemoveKorisnikaUlogu", "Administracija", new { UlogaID = role.Id }); ;
            }
            ViewBag.ErrorMessage = $"Korisnik sa ID = {model.korisnikID} nije pronadjen!";
            return View("NotFound");

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}