using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNewsMVC.Models.MetaData
{
    public class SubCategoryeMetadata
    {
        [Key]
        public int SubCategoryID { get; set; }

        [DisplayName("نام دسته")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int CategoryID { get; set; }

        [DisplayName("نام زیر دسته")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "مقدار ورودی نباید بیشتر از {1} باشد")]
        public string SubCategoryName { get; set; }
    }
}