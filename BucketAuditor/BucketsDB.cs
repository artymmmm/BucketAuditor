namespace BucketAuditor
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BucketsDB : DbContext
    {
        public BucketsDB()
            : base("name=BucketsDB")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Bucket> Buckets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Admins_FIO)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Buckets)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);
        }
    }
}
