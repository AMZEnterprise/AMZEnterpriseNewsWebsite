namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubCategorye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubCategorye()
        {
            News = new HashSet<News>();
        }

        [Key]
        public int SubCategoryID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "نام زیردسته")]
        public string SubCategoryName { get; set; }

        public virtual Categorye Categorye { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
    }
}
