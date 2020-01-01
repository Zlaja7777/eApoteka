using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Apoteka.ViewModels
{
    public class AddLijekViewM
    {
        public int LijekID { get; set; }

        [Required(ErrorMessage = "Naziv lijeka nije unesen!")]
        public string NazivLijeka { get; set; }

        public string InternacionalniGenerickiNaziv { get; set; }

        public string KvalitativniIKvantitativniSastav { get; set; }

        public string FarmaceutskiOblik { get; set; }

        public string NacinPrimjene { get; set; }

        public double NabavnaCijena { get; set; }
        public double ProdajnaCijena { get; set; }
        public int RokTrajanjaMjeseci { get; set; }

        public string NazivProizvodjaca { get; set; }

        public string SlikaLijeka { get; set; }

        public int KategorijeID { get; set; }
        public List<SelectListItem> ListaKategorija { get; set; }
        public DateTime DatumProizvodnje { get; set; }
    }
}
