using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;
using WebApp_Apoteka.WebApoteka_Interfaces;

namespace WebApp_Apoteka.Controllers
{
    public class RegistracijaController : Controller
    {
        private IKorisnikServices _IKorisnik;

        public RegistracijaController(IKorisnikServices IKorisnik)
        {
            _IKorisnik = IKorisnik;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajKorisnika() {
            AddKorisnikVM model = new AddKorisnikVM()
            {
                Opstine = _IKorisnik.GetAllOpstine().Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Naziv }).ToList(),
                TipoviKorisnika = _IKorisnik.GetAllTipKorisnika().Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Naziv }).ToList()
        };
            return View(model);
        }
        public IActionResult SnimiKorisnika(AddKorisnikVM kVM)
        {
            Korisnik k = new Korisnik()
            {
                Ime = kVM.Ime,
                Prezime= kVM.Prezime,
                DatumRodjenja = kVM.DatumRodjenja,
                OpstinaRodjenjaID = kVM.OpstinaRodjenjaID,
                Adresa = kVM.Adresa,
                TipKorisnikaID = kVM.TipKorisnikaID,
                Email = kVM.Email,
                Password=kVM.Password,
                Bonovi=0
            };
            _IKorisnik.Add(k);

            return Redirect("PrikazKorisnika");
        }
        public IActionResult PrikazKorisnika()
        {
            List<KorisnikView> model = _IKorisnik.GetAll().Select(s => new KorisnikView {
                ID=s.ID,
                Ime=s.Ime,
                Prezime=s.Prezime,
                DatumRodjenja=s.DatumRodjenja,
                OpstinaRodjenja=s.OpstinaRodjenja.Naziv,
                Adresa=s.Adresa,
                TipKorisnika=s.TipKorisnika.Naziv,
                Email=s.Email,
                Bonovi=s.Bonovi
            }).ToList();
            return View(model);
        }
    }
}