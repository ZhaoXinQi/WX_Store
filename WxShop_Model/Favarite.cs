namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favarite")]
    public partial class Favarite
    {
        public int Id { get; set; }

        [StringLength(12)]
        public string Pcode { get; set; }

        [StringLength(100)]
        public string Cid { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTime Createtime { get; set; }

        public virtual Customar Customar { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
