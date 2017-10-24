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
        [Column(Order = 0)]
        public Guid Cid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string Pcode { get; set; }

        public int Num { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public bool IsReview { get; set; }

        public virtual Customar Customar { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
