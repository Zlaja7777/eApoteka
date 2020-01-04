using System;
using System.Collections.Generic;
using Apoteka.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Apoteka.Models;

namespace WebApp_Apoteka.ViewModels
{
    public class AddOnlineNarudzbaViewM
    {
        public int ID { get; set; }
        public string korisnikID { get; set; }
        public Korisnik korisnik { get; set; } 

        public DateTime datum { get; set; }
        public double vrijednostNarudzbe { get; set; }
        public double cijenaDostave { get; set; }
        public int gradDostaveID { get; set; }
        public List<SelectListItem> opstine { get; set; }
        public string adresaDostave { get; set; }
    }
}
