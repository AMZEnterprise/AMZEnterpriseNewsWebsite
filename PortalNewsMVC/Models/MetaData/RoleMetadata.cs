using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNewsMVC.Models.MetaData
{
    public class RoleMetadata
    {
        [Key]
        [DisplayName("کد سطح دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int RoleID { get; set; }

        [DisplayName("نام نمایش سطح دسترسی")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(20,ErrorMessage ="مقدار ورودی نباید بیشتر از {0} باشد ")]
        public string RoleTitle { get; set; }

        [DisplayName("سطح دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "مقدار ورودی نباید بیشتر از {0} باشد ")]

        public string RoleName { get; set; }
    }
}