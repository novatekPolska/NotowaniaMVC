using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotowaniaMVC.Domain.DomainEntities
{
    public class Waluta
    {
        private int Id_waluta { get; set; }
        private string Skrot { get; set; }
        private string waluta { get; set; }
        private string Bilon { get; set; }
        private int Krotnosc { get; set; }
        private bool Walutapodstawowa { get; set; }
        private string Symbol { get; set; }
        private string Wydruk { get; set; }
    }
}
