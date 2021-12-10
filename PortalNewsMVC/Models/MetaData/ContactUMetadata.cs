﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PortalNewsMVC.Models.MetaData
{
    public class ContactUMetadata
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("نام ")]
        [Required(ErrorMessage = ("نام {0} را وارد کنید"))]

        public string FullName { get; set; }
        [DisplayName("ایمیل ")]
        [Required(ErrorMessage = ("نام {0} را وارد کنید"))]

        public string Email { get; set; }
        [DisplayName("توضیحات  ")]
        [Required(ErrorMessage = ("نام {0} را وارد کنید"))]

        public string Note { get; set; }
        [DisplayName("تاریخ  ")]

        public Nullable<System.DateTime> Date { get; set; }

    }
}