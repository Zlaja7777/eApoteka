using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class RegistracijaVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password must be the same")]
        public string ConfirmPassword { get; set; }

        [Required]

        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        [Display(Name = "Mjesto rodjenja")]
        public int OpstinaRodjenjaID { get; set; }

        public List<SelectListItem> Opstine { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        [Required]
        [Display(Name = "Tip korisnika")]
        public int TipKorisnikaID { get; set; }
        public List<SelectListItem> TipKorisnika { get; set; }

        public int Bonovi { get; set; }
    }
}
