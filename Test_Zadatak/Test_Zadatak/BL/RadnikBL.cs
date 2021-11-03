using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Zadatak.BL.Interfaces;
using Test_Zadatak.DAL.Interfaces;
using Test_Zadatak.Models;

namespace Test_Zadatak.BL
{
    public class RadnikBL : IRadnikBL
    {
        readonly IRadnikDAL iradnikDAL;

        public RadnikBL(IRadnikDAL iradnikDAL)
        {
            this.iradnikDAL = iradnikDAL;
        }
        public List<Radnik> getAll()
        {
            return iradnikDAL.getAll();
        }

        public void insert(Radnik radnik)
        {
            iradnikDAL.insert(radnik);
        }
    }
}