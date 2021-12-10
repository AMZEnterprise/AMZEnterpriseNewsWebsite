using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNewsMVC.Models.Domain;

namespace PortalNewsMVC.Areas.Administrator.Controllers
{
    public class NewsLattersController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: Administrator/NewsLatters
        public async Task<ActionResult> Index()
        {
            return View(await db.NewsLatters.ToListAsync());
        }

        // GET: Administrator/NewsLatters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLatter newsLatter = await db.NewsLatters.FindAsync(id);
            if (newsLatter == null)
            {
                return HttpNotFound();
            }
            return View(newsLatter);
        }

        // GET: Administrator/NewsLatters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/NewsLatters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NewsLaterID,FullName,Email,Date")] NewsLatter newsLatter)
        {
            if (ModelState.IsValid)
            {
                db.NewsLatters.Add(newsLatter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(newsLatter);
        }

        // GET: Administrator/NewsLatters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLatter newsLatter = await db.NewsLatters.FindAsync(id);
            if (newsLatter == null)
            {
                return HttpNotFound();
            }
            return View(newsLatter);
        }

        // POST: Administrator/NewsLatters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NewsLaterID,FullName,Email,Date")] NewsLatter newsLatter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsLatter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newsLatter);
        }

        // GET: Administrator/NewsLatters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsLatter newsLatter = await db.NewsLatters.FindAsync(id);
            if (newsLatter == null)
            {
                return HttpNotFound();
            }
            return View(newsLatter);
        }

        // POST: Administrator/NewsLatters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NewsLatter newsLatter = await db.NewsLatters.FindAsync(id);
            db.NewsLatters.Remove(newsLatter);
            await db.SaveChangesAsync();
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
