namespace PortalNewsMVC.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tag
    {
        public int TagID { get; set; }

        public int NewsID { get; set; }

        public DateTime Date { get; set; }

        public virtual News News { get; set; }
    }
}
