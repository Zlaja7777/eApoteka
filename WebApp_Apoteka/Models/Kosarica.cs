using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Kosarica
    {
        public int KosaricaID { get; set; }

        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int LijekID { get; set; }
        public Lijek Lijek { get; set; }

    }
}
