namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            Galleryes = new HashSet<Gallerye>();
            Tags = new HashSet<Tag>();
        }

        public int NewsID { get; set; }

        public int? NewsCategoryID { get; set; }

        public int? SubCategoryID { get; set; }

        [Required]
        [Display(Name = "عنوان خبر")]
        public string NewsTitle { get; set; }

        [Required]
        [Display(Name = "متن خبر")]
        public string NewsDescription { get; set; }
        [Display(Name = "تاریخ انتشار")]
        public DateTime NewsDate { get; set; }

        [StringLength(150)]
        [Display(Name = "تصاویر خبری")]
        public string NewsImage { get; set; }

        public int? LogUser { get; set; }

        public DateTime? LogDate { get; set; }

        public virtual Categorye Categorye { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gallerye> Galleryes { get; set; }

        public virtual SubCategorye SubCategorye { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
