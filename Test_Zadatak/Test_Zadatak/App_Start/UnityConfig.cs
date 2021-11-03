using System.Web.Mvc;
using Test_Zadatak.DAL;
using Test_Zadatak.DAL.Interfaces;
using Test_Zadatak.BL;
using Test_Zadatak.BL.Interfaces;
using Test_Zadatak.UI;
using Test_Zadatak.UI.Interfaces;
using Unity;
using Unity.Mvc5;


namespace Test_Zadatak
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRadnikDAL, RadnikDAL>();
            container.RegisterType<IRadnikBL, RadnikBL>();
            container.RegisterType<IRadnikUI, RadnikUI>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}