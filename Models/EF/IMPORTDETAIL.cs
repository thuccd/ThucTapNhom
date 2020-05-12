namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMPORTDETAIL")]
    public partial class IMPORTDETAIL
    {
        [Key]
        public int DetailID { get; set; }

        public int? Quantity { get; set; }

        public int? ResourcesID { get; set; }

        public int? PersonID { get; set; }

        public virtual PERSON PERSON { get; set; }

        public virtual RESOURCE RESOURCE { get; set; }
    }
}
