using Inova.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inova.Farm.Migration.Mapping
{
    public class CurrentProductionMap : EntityTypeConfiguration<CurrentProduction>
    {
        public CurrentProductionMap()        {
            HasKey(k => k.Id);
            Property(p => p.FruitName).IsRequired();

            HasRequired(p => p.CurrentPhase).WithMany().HasForeignKey(p => p.CurrentPhaseId);
            HasRequired(p => p.User).WithRequiredDependent().
        }
    }
}
