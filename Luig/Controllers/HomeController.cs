using Luig.Data;
using Luig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Luig.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FrontPage frontpage = new FrontPage();
            frontpage.WorkInProgress = DataLuigContext.GetLatestWips();
            return View(frontpage);
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
    }
}