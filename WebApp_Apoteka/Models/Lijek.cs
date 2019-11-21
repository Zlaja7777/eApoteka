using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Lijek
    {
        public int LijekID { get; set; }
        public string NazivLijeka { get; set; }

        public string InternacionalniGenerickiNaziv { get; set; }

        public string KvalitativniIKvantitativniSastav { get; set; }

        public string FarmaceutskiOblik { get; set; }

        public string NacinPrimjene { get; set; }

        public int RokTrajanjaMjeseci { get; set; }

        public string NazivProizvodjaca { get; set; }

        public DateTime DatumProizvodnje { get; set; }

    }
}
