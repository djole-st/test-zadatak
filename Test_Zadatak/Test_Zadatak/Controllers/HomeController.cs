using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Zadatak.Helpers;
using Test_Zadatak.Models;
using Test_Zadatak.UI.Interfaces;

namespace Test_Zadatak.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        readonly IRadnikUI iRadnikUI;

        public HomeController(IRadnikUI iRadnikUI)
        {
            this.iRadnikUI = iRadnikUI;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Radnik radnik)
        {
            return View(radnik);
        }

        public ActionResult ListAll()
        {
            List<Radnik> radnici = iRadnikUI.getAll();
            RadniciViewModel radniciViewModel = new RadniciViewModel("Spisak Radnika", radnici, Constants.KOEFICIJENT_PRERACUNA);
            return View(radniciViewModel);
        }

        public ActionResult AddNew(Radnik radnik)
        {
            iRadnikUI.insert(radnik);
            return RedirectToAction("ListAll");
        }

        [HttpPost]
        public ActionResult Insert(Radnik radnik)
        {    
            return RedirectToAction("Details",radnik);
        }
    }
}