using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BiAccident.Models;
using BiAccident.ViewModels;

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
            NbAccidentLieuxViewModels nbALV = new NbAccidentLieuxViewModels();
            nbALV.ListNbAccidentLieux.Add(DataBase.ReqNbAccidentLieux("2015"));
            nbALV.ListNbAccidentLieux.Add(DataBase.ReqNbAccidentLieux("2014"));
            nbALV.ListNbAccidentLieux.Add(DataBase.ReqNbAccidentLieux("2013"));
            nbALV.ListNbAccidentLieux.Add(DataBase.ReqNbAccidentLieux("2011"));
            nbALV.ListNbAccidentLieux.Add(DataBase.ReqNbAccidentLieux("2010"));
            return View(nbALV);
        }
    }
}