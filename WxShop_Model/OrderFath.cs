namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderFath")]
    public partial class OrderFath
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Cid { get; set; }

        public Guid ChirldOrderId { get; set; }

        [Required]
        [StringLength(5)]
        public string state { get; set; }

        [Column(TypeName = "money")]
        public decimal ExpresPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [StringLength(50)]
        public string ReMark { get; set; }

        [Required]
        [StringLength(50)]
        public string Createtime { get; set; }

        [StringLength(50)]
        public string PayTime { get; set; }

        [StringLength(50)]
        public string PostTime { get; set; }

        [StringLength(50)]
        public string ReceTime { get; set; }
    }
}
