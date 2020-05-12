namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSON")]
    public partial class PERSON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSON()
        {
            IMPORTs = new HashSet<IMPORT>();
            IMPORTDETAILs = new HashSet<IMPORTDETAIL>();
            ORDERs = new HashSet<ORDER>();
        }

        public int PersonID { get; set; }

        [Required]
        [StringLength(250)]
        public string Personusername { get; set; }

        [Required]
        [StringLength(250)]
        public string PersonPassword { get; set; }

        [StringLength(250)]
        public string PersonEmail { get; set; }

        [Required]
        [StringLength(250)]
        public string PersonName { get; set; }

        [StringLength(20)]
        public string PersonPhone { get; set; }

        [StringLength(250)]
        public string PersonAdress { get; set; }

        public DateTime? CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPORT> IMPORTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPORTDETAIL> IMPORTDETAILs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERs { get; set; }
    }
}
