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
using PortalNewsMVC;

namespace PortalNewsMVC.Areas.Administrator.Controllers
{
    public class ContactUsController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: Administrator/ContactUs
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactUs.ToListAsync());
        }

        // GET: Administrator/ContactUs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = await db.ContactUs.FindAsync(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // GET: Administrator/ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,Email,Note,Date")] ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactU);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactU);
        }

        // GET: Administrator/ContactUs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = await db.ContactUs.FindAsync(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // POST: Administrator/ContactUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,Email,Note,Date")] ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactU).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactU);
        }

        // GET: Administrator/ContactUs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactU contactU = await db.ContactUs.FindAsync(id);
            if (contactU == null)
            {
                return HttpNotFound();
            }
            return View(contactU);
        }

        // POST: Administrator/ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactU contactU = await db.ContactUs.FindAsync(id);
            db.ContactUs.Remove(contactU);
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
