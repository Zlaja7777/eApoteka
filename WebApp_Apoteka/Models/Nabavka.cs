using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Nabavka
    {
        public int ID { get; set; }
        public int ApotekarID { get; set; }
        public Apotekar Apotekar { get; set; }
        public DateTime datum { get; set; }
        public double vrijednostNarudzbe { get; set; }

        public string statusNarudzbe { get; set; }
    }
}
