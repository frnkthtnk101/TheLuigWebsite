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
            var ContactInfo = new ContactInfo()
            {
                Title = "Contact Me!"
            };
            return View(ContactInfo);
        }
        [HttpPost]
        public ActionResult Submit(string aLuigMessage)
        {
            Console.WriteLine(aLuigMessage);
            var ContactInfo = new ContactInfo()
            {
                Title = "Thanks for contacting Me!"
            };
            return View("Contact", ContactInfo);
        }
    }
}