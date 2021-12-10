using PortalNewsMVC.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalNewsMVC.Controllers
{
    public class HomeController : Controller
    {
        private BloggingContext db = new BloggingContext();
        // GET: Home
        public ActionResult Index()
        {

            return View(db.News.Where(p => p.NewsCategoryID == 2).Take(4).ToList());
        }

        #region پارشیال های صفحه اصلی
        public ActionResult Header()
        {
            var category = this.db.Categoryes.ToList();
            return PartialView("_Header", category);
        }

        public ActionResult Srartup()
        {
            var news = (from x in this.db.News
                        where x.NewsCategoryID == 3
                        orderby x.NewsDate descending
                        select x).Take(4).ToList();
            return PartialView("_Srartup", news);
        }

        public ActionResult NewsLetter()
        {
            return PartialView("_NewsLatter");
        }

        [HttpPost]
        public ActionResult NewsLetter(NewsLatter newslatter)
        {
            if (ModelState.IsValid)
            {
                newslatter.Date = DateTime.Now;

                db.NewsLatters.Add(newslatter);
                db.SaveChanges();

            }
            return View("index");
        }
        public ActionResult Banner()
        {
            return PartialView("_Banner");
        }

        public ActionResult Footer()
        {
            var result = this.db.News.ToList();
            return PartialView("_Footer",result);
        }

        public ActionResult Saidbar()
        {
            return PartialView("_Saidbar");
        }

        public ActionResult LastArticels()
        {
            var result = (from x in this.db.News
                          orderby x.NewsDate descending
                          select x).Take(3).ToList();
            return PartialView("_LastArticels", result);
        }
        public ActionResult PostMahboob()
        {
            var result = (from x in this.db.News orderby x.NewsDate ascending select x).Take(4).ToList();
            return PartialView("_PostMahboob", result);
        }
        public ActionResult TopNews()
        {
            var result = (from x in this.db.News orderby x.NewsDate descending select x).Take(3).ToList();
            return PartialView("_TopNews", result);
        }

       
        public ActionResult SinglePage(int id)
        {
            var news = this.db.News.FirstOrDefault(x => x.NewsID == id);
            return View(news);
        }

        public ActionResult Sport()
        {
            var result = (from x in this.db.News
                          where x.NewsCategoryID == 1
                          orderby x.NewsDate descending
                          select x).Take(3).ToList();
            return PartialView("_Sport", result);

        }


        #endregion
    }
}