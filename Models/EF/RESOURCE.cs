namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESOURCES")]
    public partial class RESOURCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESOURCE()
        {
            IMPORTDETAILs = new HashSet<IMPORTDETAIL>();
        }

        [Key]
        public int ResourcesID { get; set; }

        [StringLength(250)]
        public string Resourcesname { get; set; }

        public int? Quantity { get; set; }

        public decimal? Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPORTDETAIL> IMPORTDETAILs { get; set; }
    }
}
