namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Specification")]
    public partial class Specification
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [StringLength(20)]
        public string Style { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string ProCode { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
