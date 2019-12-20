using Apoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Apoteka.Models
{
    public class Clanak
    {
        public int ClanakID { get; set; }
        public int ApotekarID { get; set; }
        public Apotekar Apotekar { get; set; }
    }
}
