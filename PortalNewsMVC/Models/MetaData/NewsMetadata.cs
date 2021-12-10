using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PortalNewsMVC.Models.MetaData
{
    public class NewsMetadata
    {
        [Key]
        public int NewsID { get; set; }
        [DisplayName("دسته خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int NewsCategoryID { get; set; }
        [DisplayName("زیر دسته خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int SubCategoryID { get; set; }

        [DisplayName("موضوع خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(80, ErrorMessage = ("مقدار ورودی نباید بیشتر از {1} باشد"))]
        public string NewsTitle { get; set; }

        [DisplayName("متن خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [AllowHtml]
        public string NewsDescription { get; set; }

        [DisplayName("تاریخ درج خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public System.DateTime NewsDate { get; set; }

        [DisplayName("تصویر خبر")]
        public string NewsImage { get; set; }

        public int LogUser { get; set; }
        public System.DateTime LogDate { get; set; }

    }
}