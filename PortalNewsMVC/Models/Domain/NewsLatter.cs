namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsLatter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsLaterID { get; set; }

        [StringLength(50)]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [StringLength(50)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "تاریخ عضویت")]
        public DateTime? Date { get; set; }
    }
}
