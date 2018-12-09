using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Inova.Farm.SistemaInterfaceWeb.Models
{

    [Table("Irrigation")]
    public partial class Irrigation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Irrigation()
        {
            SoilConditions = new HashSet<SoilCondition>();
        }

        public int Id { get; set; }

        public double Amount { get; set; }

        public int CurrentPhaseId { get; set; }

        public DateTime Date { get; set; }

        public virtual CurrentProduction CurrentProduction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoilCondition> SoilConditions { get; set; }
    }
}
