namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContactU
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [StringLength(50)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "متن نظر")]

        public string Note { get; set; }
        [Display(Name = "تاریخ ارسال")]

        public DateTime? Date { get; set; }
    }
}
