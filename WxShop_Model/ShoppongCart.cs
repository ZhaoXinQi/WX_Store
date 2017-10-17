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

        public Guid? Cid { get; set; }

        [StringLength(8)]
        public string Pcode { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal Totale { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual Customar Customar { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
