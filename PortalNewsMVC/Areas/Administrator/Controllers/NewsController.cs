using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalNewsMVC.Models.Domain;
using System.IO;
using InsertShowImage;
namespace PortalNewsMVC.Areas.Administrator.Controllers
{
    public class NewsController : Controller
    {
        private BloggingContext db = new BloggingContext();

        // GET: Administrator/News
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Categorye).Include(n => n.SubCategorye).Include(n => n.User);
            return View(news.ToList());

        }

        // GET: Administrator/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Administrator/News/Create
        public ActionResult Create()
        {
            ViewBag.NewsCategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle");
            ViewBag.SubCategoryID = new SelectList(db.SubCategoryes, "SubCategoryID", "SubCategoryName");
            ViewBag.LogUser = new SelectList(db.Users, "UserID", "Username");
            return View();
        }

        // POST: Administrator/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(News news, HttpPostedFileBase NewsImage,HttpPostedFileBase galleryImage)
        {

            if (ModelState.IsValid)
            {
                int userid = int.Parse(User.Identity.Name);
                string imageName = "no-photo.jpg";
                if (NewsImage != null)
                {
                    imageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(NewsImage.FileName);
                    NewsImage.SaveAs(Server.MapPath("/Upload/Images/Image/" + imageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Upload/Images/Image/" + imageName),
                        Server.MapPath("/Upload/Images/Thumb/" + imageName));
                }

                news.NewsImage = imageName;
                news.LogDate = DateTime.Now;
                news.LogUser = userid;
                news.NewsDate = DateTime.Now;
                db.News.Add(news);
                db.SaveChanges();
                if(galleryImage != null)
                {
                    this.UploadImageMethod(news.NewsID);
                }
                
                return RedirectToAction("Index");
            }

            ViewBag.NewsCategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle", news.NewsCategoryID);
            ViewBag.SubCategoryID = new SelectList(db.SubCategoryes, "SubCategoryID", "SubCategoryName", news.SubCategoryID);
            ViewBag.LogUser = new SelectList(db.Users, "UserID", "Username", news.LogUser);
            return View(news);
        }

        // GET: Administrator/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsCategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle", news.NewsCategoryID);
            ViewBag.SubCategoryID = new SelectList(db.SubCategoryes, "SubCategoryID", "SubCategoryName", news.SubCategoryID);
            ViewBag.LogUser = new SelectList(db.Users, "UserID", "Username", news.LogUser);
            return View(news);
        }

        // POST: Administrator/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(News news, HttpPostedFileBase ProductImage)
        {

            if (ModelState.IsValid)
            {
                string ImageName = news.NewsImage;
                if (ProductImage != null)
                {
                    if (ImageName == "no-photo.jpg")
                    {
                        news.NewsImage = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(ProductImage.FileName);
                    }
                    ProductImage.SaveAs(Server.MapPath("/Upload/Images/Image/" + ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Upload/Images/Image/" + ImageName),
                        Server.MapPath("/Upload/Images/Thumb/" + ImageName));
                }

                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewsCategoryID = new SelectList(db.Categoryes, "CategoryID", "CategoryTitle", news.NewsCategoryID);
            ViewBag.SubCategoryID = new SelectList(db.SubCategoryes, "SubCategoryID", "SubCategoryName", news.SubCategoryID);
            ViewBag.LogUser = new SelectList(db.Users, "UserID", "Username", news.LogUser);
            return View(news);
        }

        // GET: Administrator/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Administrator/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            if (news.NewsImage != null)
            {
                if (news.NewsImage != "no-photo.jpg")
                {
                    System.IO.File.Delete(Server.MapPath("/Upload/Images/Image/" + news.NewsImage));
                    System.IO.File.Delete(Server.MapPath("/Upload/Images/Thumb/" + news.NewsImage));
                }

                var gallery = (from x in this.db.Galleryes where x.NewsID == news.NewsID select x).ToList();
                foreach(var item in gallery)
                {
                    if(item.Image!="" || item.Image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Upload/Gallery/Image/" + item.Image));
                       
                        
                    }
                    db.Galleryes.Remove(item);
                }
              
            }
       
            db.News.Remove(news);
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

        public JsonResult SelectSubCategory(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<SubCategorye> states = db.SubCategoryes.Where(stat => stat.CategoryID == id);
            return Json(states);
        }

        [HttpPost]
        public ActionResult UploadImageMethod(int? newsID)
        {
            if (newsID.HasValue)
            {
                if (Request.Files.Count != 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        int fileSize = file.ContentLength;
                        string fileName = file.FileName;
                        file.SaveAs(Server.MapPath("~/Upload/Gallery/Image/" + fileName));
                        ImageResizer img = new ImageResizer();
                        img.Resize(Server.MapPath("/Upload/Gallery/Image/" + fileName),
                            Server.MapPath("/Upload/Gallery/Thumb/" + fileName));

                        Gallerye imageGallery = new Gallerye();
                        imageGallery.NewsID = newsID.Value;
                        imageGallery.Image = fileName;

                        db.Galleryes.Add(imageGallery);
                        db.SaveChanges();
                    }
                    return Content("Success");
                }
                return Content("failed");
            }
            return null;
         
        }
    }
}
