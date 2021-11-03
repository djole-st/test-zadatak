using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Zadatak.BL.Interfaces;
using Test_Zadatak.Models;
using Test_Zadatak.UI.Interfaces;

namespace Test_Zadatak.UI
{
    public class RadnikUI : IRadnikUI
    {
        readonly IRadnikBL iradnikBL;

        public RadnikUI(IRadnikBL iradnikBL)
        {
            this.iradnikBL = iradnikBL;
        }
        public List<Radnik> getAll()
        {
            return iradnikBL.getAll();
        }

        public void insert(Radnik radnik)
        {
            iradnikBL.insert(radnik);
        }
    }
}