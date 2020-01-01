using System;
using System.Collections.Generic;

namespace WebApp_Apoteka.ViewModels
{

    public class LijekView{

        public List<Podaci> podaci { get; set; }

        public class Podaci
        {
            public int LijekID { get; set; }


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

            public string NazivKategorije { get; set; }

            public DateTime DatumProizvodnje { get; set; }
            public int KategorijaID { get; internal set; }
        }
}
    
}
