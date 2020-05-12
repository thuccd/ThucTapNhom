namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            ORDERDETAILs = new HashSet<ORDERDETAIL>();
        }

        public int ProductID { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Rating { get; set; }

        public string ShowImage { get; set; }

        public int? ProductStock { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        public bool? ProductStatus { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(2)]
        public string Size { get; set; }

        public int CategoryID { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }
    }
}
