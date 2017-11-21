namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderChild")]
    public partial class OrderChild
    {
        [Key]
        public int cid { get; set; }

        public Guid? order_id { get; set; }

        [Required]
        [StringLength(12)]
        public string Pcode { get; set; }

        public int Num { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public bool IsReview { get; set; }
    }
}
