using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Zadatak.Models;

namespace Test_Zadatak.BL.Interfaces
{
    public interface IRadnikBL
    {
        List<Radnik> getAll();
        void insert(Radnik radnik);
    }
}
