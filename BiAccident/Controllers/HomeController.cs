using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BiAccident.Models;

namespace BiAccident.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["num_Acc"] = DataBase.TestConnexion();
            return View();
        }
        public ActionResult PageNbAccidentLieux()
        {
            ViewData["num_Acc"] = DataBase.TestConnexion();
            return View();
        }
    }
}