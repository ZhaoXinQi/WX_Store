namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSecondSort")]
    public partial class ProductSecondSort
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(8)]
        public string Code { get; set; }
    }
}
