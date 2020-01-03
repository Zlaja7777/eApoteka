using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Entity_Framework;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

namespace WebApp_Apoteka.Controllers
{
    public class AccountController : Controller
    {
        MojDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager, MojDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registracija()
        {
            RegistracijaVM model = new RegistracijaVM()
            {
                Opstine = _db.Opstina.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList(),
                TipKorisnika = _db.tipKorisnika.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList()
            };
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registracija(RegistracijaVM model)
        {
            if (ModelState.IsValid)
            {
                Korisnik k = new Korisnik()
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    DatumRodjenja = model.DatumRodjenja,
                    OpstinaRodjenjaID = model.OpstinaRodjenjaID,
                    Adresa = model.Adresa,
                    Telefon = model.Telefon,
                    TipKorisnikaID = model.TipKorisnikaID
                };
                _db.Add(k);
                var user = new AppUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    korisnik = k
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!_signInManager.IsSignedIn(User))
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                    }
                    //return RedirectToAction("DodijeliUlogu", "Administracija", new DodijeliUloguVM { nazivUloge = "Korisnik", korisnikID = user.Id });

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            model.Opstine = _db.Opstina.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList();
            model.TipKorisnika = _db.tipKorisnika.Select(o => new SelectListItem { Value = o.ID.ToString(), Text = o.Naziv }).ToList();
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid LoginAttempt");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}