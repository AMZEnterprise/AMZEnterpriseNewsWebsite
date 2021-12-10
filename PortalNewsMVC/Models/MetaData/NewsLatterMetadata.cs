using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNewsMVC.Models.MetaData
{
    public class NewsLatterMetadata
    {
        [Key]
        public int NewsLaterID { get; set; }
        [DisplayName("نام")]
        public string FullName { get; set; }
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [DisplayName("تاریخ ایجاد")]
        public Nullable<System.DateTime> Date { get; set; }
    }
}