using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class KonkursPraksa
    {
        public int ID { get; set; }

        public string KorisnikID { get; set; }

        public AppUser appUser { get; set; }

        //public Korisnik Korisnik { get; set; }
        public string ZavrsenaSkola { get; set; }
        public int GodinaZavrsetka { get; set; }
        public bool ImaRadnoIskustvo { get; set; }
        public string RadnoIskustvo { get; set; }
        public bool Prihvacena { get; set; }
        public string Obrazlozenje { get; set; }




    }
}
