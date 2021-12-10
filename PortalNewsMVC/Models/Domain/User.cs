namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            News = new HashSet<News>();
        }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        public DateTime Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }

        public virtual Role Role { get; set; }
    }
}
