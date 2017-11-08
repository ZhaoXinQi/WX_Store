namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppongCart")]
    public partial class ShoppongCart
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Cid { get; set; }

        [Required]
        [StringLength(12)]
        public string Pcode { get; set; }

        public int num { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal Totale { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
