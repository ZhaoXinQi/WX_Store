namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customar")]
    public partial class Customar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customar()
        {
            Favarite = new HashSet<Favarite>();
            OrderChild = new HashSet<OrderChild>();
            OrderFath = new HashSet<OrderFath>();
            ProductReview = new HashSet<ProductReview>();
            SeachProduct = new HashSet<SeachProduct>();
            ShoppongCart = new HashSet<ShoppongCart>();
        }

        public Guid id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string OpenId { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public DateTime CreateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favarite> Favarite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderChild> OrderChild { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderFath> OrderFath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductReview> ProductReview { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeachProduct> SeachProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppongCart> ShoppongCart { get; set; }
    }
}
