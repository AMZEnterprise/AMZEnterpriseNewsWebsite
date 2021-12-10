using PortalNewsMVC.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalNewsMVC.Controllers
{
    public class ContactController : Controller
    {
        private BloggingContext db = new BloggingContext();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactU contact)
        {
            contact.Date = DateTime.Now;
            db.ContactUs.Add(contact);
            db.SaveChanges();
            TempData["Success"] = "درخواست شما با موفقیت ارسال شد";

            return RedirectToAction("Contact");
        }
    }
}