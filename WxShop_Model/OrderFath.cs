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
        public Guid Id { get; set; }

        public Guid? Cid { get; set; }

        [Required]
        [StringLength(5)]
        public string state { get; set; }

        [Column(TypeName = "money")]
        public decimal OrderPrie { get; set; }

        [Column(TypeName = "money")]
        public decimal ExpresPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public int? PayMthodid { get; set; }

        [StringLength(50)]
        public string ReMark { get; set; }

        [Required]
        [StringLength(20)]
        public string CheckUser { get; set; }

        public DateTime Createtime { get; set; }

        public DateTime? PayTime { get; set; }

        public DateTime? PostTime { get; set; }

        public DateTime? ReceTime { get; set; }

        public virtual PayMethod PayMethod { get; set; }
    }
}
