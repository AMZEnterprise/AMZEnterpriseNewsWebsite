using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PortalNewsMVC.Models.Domain;

namespace PortalNewsMVC.Areas.Administrator.Controllers
{
    
    public class DashboardController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: Administrator/Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Partial_DashboardCol8()
        {
            var result = this.db.News.ToList();
            return PartialView("Partial_DashboardCol8", result);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}