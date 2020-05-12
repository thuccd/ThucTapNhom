namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CafeDbContext : DbContext
    {
        public CafeDbContext()
            : base("name=CafeDbContext1")
        {
        }

        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<IMPORT> IMPORTs { get; set; }
        public virtual DbSet<IMPORTDETAIL> IMPORTDETAILs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDERDETAIL> ORDERDETAILs { get; set; }
        public virtual DbSet<PERSON> People { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<RESOURCE> RESOURCES { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.PRODUCTs)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.ProductPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);
        }
    }
}
