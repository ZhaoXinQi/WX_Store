namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string img { get; set; }

        [StringLength(12)]
        public string P_Code { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
