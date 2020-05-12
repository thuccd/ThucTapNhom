namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMPORT")]
    public partial class IMPORT
    {
        public int ImportID { get; set; }

        public DateTime? ImportDate { get; set; }

        public decimal? Total { get; set; }

        public int? PERSONID { get; set; }

        public virtual PERSON PERSON { get; set; }
    }
}
