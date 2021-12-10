using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalNewsMVC.Models.Domain;

namespace PortalNewsMVC.Models.Repository
{
    
    public class SiteRepository
    {
        private BloggingContext db =new BloggingContext();
        public string GetAboutSite()
        {
            var aboutSite = (from x in this.db.Sites select x.SiteAbout).SingleOrDefault();
            return aboutSite;
        }
    }
}