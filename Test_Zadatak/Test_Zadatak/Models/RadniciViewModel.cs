using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Zadatak.Models
{
    public class RadniciViewModel
    {
        public string title;
        public List<Radnik> radnici;
        public double koeficijentPreracuna;

        public RadniciViewModel(string title, List<Radnik> radnici, double koeficijentPreracuna)
        {
            this.title = title;
            this.radnici = radnici;
            this.koeficijentPreracuna = koeficijentPreracuna;
        }
    }
}