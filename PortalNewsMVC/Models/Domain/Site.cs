namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Site
    {
        public int SiteID { get; set; }

        [StringLength(150)]
        [Display(Name = "نام سایت")]
        public string SiteName { get; set; }

        [StringLength(250)]
        [Display(Name = "توضیحات سایت")]
        public string SiteDescription { get; set; }
        [Display(Name = "درباره ما")]
        public string SiteAbout { get; set; }
    }
}
