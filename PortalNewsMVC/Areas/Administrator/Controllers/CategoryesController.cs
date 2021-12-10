using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNewsMVC.Models.Domain;
using static PortalNewsMVC.Classes.Enums;

namespace PortalNewsMVC.Areas.Administrator.Controllers
{
    public class CategoryesController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: Administrator/Categoryes
        public ActionResult Index()
        {
           
            return View(db.Categoryes.ToList());
        }

        // GET: Administrator/Categoryes/Details/5


        // GET: Administrator/Categoryes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Categoryes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryTitle")] Categorye categorye)
        {
            if (ModelState.IsValid)
            {
                db.Categoryes.Add(categorye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorye);
        }

        // GET: Administrator/Categoryes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorye categorye = db.Categoryes.Find(id);
            if (categorye == null)
            {
                return HttpNotFound();
            }
            return View(categorye);
        }

        // POST: Administrator/Categoryes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryTitle")] Categorye categorye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorye);
        }

        // GET: Administrator/Categoryes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorye categorye = db.Categoryes.Find(id);
            if (categorye == null)
            {
                return HttpNotFound();
            }
            return View(categorye);
        }

        // POST: Administrator/Categoryes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorye categorye = db.Categoryes.Find(id);
            var result = (from x in this.db.SubCategoryes
                          where x.CategoryID == id
                          select x).Any();
            if (result)
            {
                var subcategory = (from x in this.db.SubCategoryes where x.CategoryID == id select x).ToList();
                foreach (var item in subcategory)
                {
                    item.CategoryID = (int)costconstant.constant;

                }
                db.SaveChanges();

            }

            db.Categoryes.Remove(categorye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
