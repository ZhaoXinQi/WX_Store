namespace WxShop_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductInfo")]
    public partial class ProductInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductInfo()
        {
            Banner = new HashSet<Banner>();
            Favarite = new HashSet<Favarite>();
            ProductReview = new HashSet<ProductReview>();
            ProImage = new HashSet<ProImage>();
            Stock = new HashSet<Stock>();
            Specification = new HashSet<Specification>();
        }

        [Key]
        [StringLength(12)]
        public string Code { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Describe { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Content { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(8)]
        public string ProductSortCode { get; set; }

        public int? SpecificationId { get; set; }

        public bool IsHot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Banner> Banner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favarite> Favarite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductReview> ProductReview { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProImage> ProImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specification> Specification { get; set; }
    }
}
