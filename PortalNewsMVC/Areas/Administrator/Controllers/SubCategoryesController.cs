using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNewsMVC.Models.Domain;

namespace PortalNewsMVC.Areas.Administrator.Controllers
{
    public class SubCategoryesController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: Administrator/SubCategoryes
        public ActionResult Index()
        {
            var subCategoryes = db.SubCategoryes.Include(s => s.Categorye);
            return View(subCategoryes.ToList());
        }


        // GET: Administrator/SubCategoryes/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle");
            return View();
        }

        // POST: Administrator/SubCategoryes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryID,CategoryID,SubCategoryName")] SubCategorye subCategorye)
        {
            if (ModelState.IsValid)
            {
                db.SubCategoryes.Add(subCategorye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle", subCategorye.CategoryID);
            return View(subCategorye);
        }

        // GET: Administrator/SubCategoryes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategorye subCategorye = db.SubCategoryes.Find(id);
            if (subCategorye == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle", subCategorye.CategoryID);
            return View(subCategorye);
        }

        // POST: Administrator/SubCategoryes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryID,CategoryID,SubCategoryName")] SubCategorye subCategorye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategorye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle", subCategorye.CategoryID);
            return View(subCategorye);
        }

        // GET: Administrator/SubCategoryes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategorye subCategorye = db.SubCategoryes.Find(id);
            if (subCategorye == null)
            {
                return HttpNotFound();
            }
            return View(subCategorye);
        }

        // POST: Administrator/SubCategoryes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategorye subCategorye = db.SubCategoryes.Find(id);
            db.SubCategoryes.Remove(subCategorye);
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
