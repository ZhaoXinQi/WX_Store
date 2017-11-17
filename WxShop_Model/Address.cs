namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string cid { get; set; }

        [Required]
        [StringLength(20)]
        public string tel { get; set; }

        [Column("address")]
        [Required]
        [StringLength(100)]
        public string address1 { get; set; }

        public bool IsDefault { get; set; }
    }
}
