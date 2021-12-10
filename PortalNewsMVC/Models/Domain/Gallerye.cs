namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gallerye
    {
        [Key]
        public int GalleryID { get; set; }

        public int NewsID { get; set; }

        [Required]
        [StringLength(150)]
        public string Image { get; set; }

        public virtual News News { get; set; }
    }
}
