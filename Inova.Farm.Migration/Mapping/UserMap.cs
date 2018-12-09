using Inova.Farm.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inova.Farm.Migration.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(k => k.Id);
            Property(p => p.Name).IsRequired();
            Property(p => p.MainFruit).IsRequired();
            Property(p => p.FarmName).IsRequired();
            Property(p => p.UserNameLogin).IsRequired();
            Property(p => p.Password).IsRequired();
        }




    }
}
