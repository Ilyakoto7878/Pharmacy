using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pharmacy.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<ClientEntity> client { get; set; }
        public virtual DbSet<Pharmacy> pharmacy { get; set; }
        public virtual DbSet<PositionEntity> role { get; set; }
        public virtual DbSet<UserEntity> user { get; set; }
        public virtual DbSet<ProductEntity> uslugi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionEntity>()
                .HasMany(e => e.user)
                .WithRequired(e => e.role)
                .HasForeignKey(e => e.idrole)
                .WillCascadeOnDelete(false);
        }
    }
}