using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PortalNewsMVC.Models.MetaData
{
    public class LoginViewModel
    {


        public int UserID { get; set; }
        
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }
        [DisplayName("کلمه عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }
        [DisplayName("مرا به خاظر بسپار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
       
        public bool Remamber { get; set; }

    }
}