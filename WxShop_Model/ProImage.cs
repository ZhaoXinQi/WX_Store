namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProImage")]
    public partial class ProImage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string Pcode { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public virtual ProductInfo ProductInfo { get; set; }
    }
}
