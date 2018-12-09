using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Inova.Farm.SistemaInterfaceWeb.Models;

namespace Inova.Farm.SistemaInterfaceWeb { 

    public partial class InovaFarmDB : DbContext
    {
        public InovaFarmDB()
            : base("name=InovaFarmDB")
        {
        }

        public virtual DbSet<CurrentProduction> CurrentProductions { get; set; }
        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<Irrigation> Irrigations { get; set; }
        public virtual DbSet<ProductionPhase> ProductionPhases { get; set; }
        public virtual DbSet<SoilCondition> SoilConditions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrentProduction>()
                .HasMany(e => e.Irrigations)
                .WithRequired(e => e.CurrentProduction)
                .HasForeignKey(e => e.CurrentPhaseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fruit>()
                .HasMany(e => e.CurrentProductions)
                .WithRequired(e => e.Fruit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fruit>()
                .HasMany(e => e.ProductionPhases)
                .WithRequired(e => e.Fruit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Irrigation>()
                .HasMany(e => e.SoilConditions)
                .WithRequired(e => e.Irrigation)
                .WillCascadeOnDelete(false);

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
