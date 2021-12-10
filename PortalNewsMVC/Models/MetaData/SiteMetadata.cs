using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PortalNewsMVC.Models.MetaData
{
    public class SiteMetadata
    {
        [Key]
        public int SiteID { get; set; }
        [DisplayName("نام سایت")]
        public string SiteName { get; set; }
        [DisplayName("توضیحات سایت")]
        public string SiteDescription { get; set; }
        [DisplayName("درباره سایت")]
        public string SiteAbout { get; set; }

    }
}