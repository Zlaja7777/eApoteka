﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class RezervacijaTermina
    {
        public int UslugaID { get; set; }
        public Usluga usluga { get; set; }

        public int KorisnikID { get; set; }
        public Korisnik korisnik { get; set; }
        public DateTime DatumVrijemeRezervacije { get; set; }


    }
}
