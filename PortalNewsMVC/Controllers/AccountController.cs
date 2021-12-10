using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalNewsMVC.Models.Domain;
using PortalNewsMVC.Models.MetaData;
using System.Security;
using System.Web.Security;
namespace PortalNewsMVC.Controllers
{

    public class AccountController : Controller
    {
        private BloggingContext db = new BloggingContext();
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User users)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(e => e.Email == users.Email.ToLower().Trim()))
                {
                    users.Date = DateTime.Now;
                    users.RoleID = (int)PortalNewsMVC.Classes.Enums.Role.User;
                    db.Users.Add(users);
                    db.SaveChanges();
                    TempData["Success"] = "ثبت نام با موفقیت انجام شد!";
                    //return RedirectToAction("actionname", "controllername");
                }
                else
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                    TempData["Error"] = "ایمیل وارد شده تکراری است!";
                }
            }
            return View(users);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (this.ModelState.IsValid)
            {
                var user = (from x in this.db.Users where x.Username == login.Username && x.Password == login.Password select x).SingleOrDefault();
                if (user != null)
                {
                    int geetUserID = login.UserID = user.UserID;
                    if (user.RoleID == (int)PortalNewsMVC.Classes.Enums.Role.Admin)
                    {
                        FormsAuthentication.RedirectFromLoginPage(geetUserID.ToString(), login.Remamber);
                        Response.Redirect("/Administrator/Dashboard/Dashboard");
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(geetUserID.ToString(), login.Remamber);
                    }
                }

                else
                {
                    TempData["Error"] = "اطلاعات کاربری وارد شده یافت نشد!";
                }
            }

            return View(login);

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}