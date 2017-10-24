namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductReview")]
    public partial class ProductReview
    {
        public int id { get; set; }

        [StringLength(12)]
        public string Pcode { get; set; }

        public Guid? Cid { get; set; }

        public int Start { get; set; }

        public DateTime CreatTime { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public virtual Customar Customar { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
