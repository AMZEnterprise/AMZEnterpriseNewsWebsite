using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNewsMVC.Models.MetaData
{
    public class CategoryeMetadata
    {
        [Key]
        public int CategoryID { get; set; }

        [DisplayName("نام دسته")]
        [Required(ErrorMessage = ("نام {0} را وارد کنید"))]
        [MaxLength(20, ErrorMessage = "مقدار ورودی نباید بیشتر از {1} باشد ")]
        public string CategoryTitle { get; set; }

       
    }
}