using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Zadatak.Models;

namespace Test_Zadatak.UI.Interfaces
{
    public interface IRadnikUI
    {
        List<Radnik> getAll();
        void insert(Radnik radnik);
    }
}
