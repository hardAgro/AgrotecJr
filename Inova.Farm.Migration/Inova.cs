namespace Inova.Farm.Migration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Inova : DbContext
    {
        public Inova()
            : base("name=inovaFarmConnection")
        {
        }

        public virtual DbSet<CurrentProduction> CurrentProductions { get; set; }
        public virtual DbSet<Irrigation> Irrigations { get; set; }
        public virtual DbSet<ProductionPhase> ProductionPhases { get; set; }
        public virtual DbSet<SoilCondition> SoilConditions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionPhase>()
                .HasMany(e => e.CurrentProductions)
                .WithRequired(e => e.ProductionPhase)
                .HasForeignKey(e => e.CurrentPhaseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.CurrentProductions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
