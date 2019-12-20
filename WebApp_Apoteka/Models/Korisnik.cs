using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApp_Apoteka.Models
{
    public class Korisnik
    {
        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public int OpstinaRodjenjaID { get; set; }
        public Opstina OpstinaRodjenja { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }



    }
}