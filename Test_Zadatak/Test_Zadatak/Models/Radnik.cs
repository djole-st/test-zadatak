using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Test_Zadatak.Models
{
    public class Radnik
    {
        /*
         * ime, prezime, adresa, neto iznos plate
         */
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public int NetoPlata { get; set; }

        public double BrutoIznos { get; set; }
        public double UmanjenjePoreskeOsnovice { get; set; }

    }
}