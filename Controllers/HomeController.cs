using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STEF.Models;

namespace STEF.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Ekipa()
        {
            var tim = db.Tim.Include(t => t.Takmicenje);
            return View(tim.ToList());
        }
       
        
    }
}