using System;
namespace WebApp_Apoteka.ViewModels
{
    public class AddUslugaViewM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public string Napomena { get; set; }
        public int BrojPacijenata { get; set; }
    }
}
