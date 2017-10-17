namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SeachProduct")]
    public partial class SeachProduct
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string SeachContent { get; set; }

        public Guid? Cid { get; set; }

        public virtual Customar Customar { get; set; }
    }
}
