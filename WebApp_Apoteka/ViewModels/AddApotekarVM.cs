using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.ViewModels
{
    public class AddApotekarVM
    {
        public int ID { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public int MjestoRodjenjaID { get; set; }
        public List<SelectListItem> ListaOpstina { get; set; }
    }
}
