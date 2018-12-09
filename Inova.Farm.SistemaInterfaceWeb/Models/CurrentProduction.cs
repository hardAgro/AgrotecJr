using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Inova.Farm.SistemaInterfaceWeb.Models
{
    [Table("CurrentProduction")]
    public partial class CurrentProduction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurrentProduction()
        {
            Irrigations = new HashSet<Irrigation>();
        }

        public int Id { get; set; }

        public int FruitId { get; set; }

        public int CurrentPhaseId { get; set; }

        public int UserId { get; set; }

        public virtual Fruit Fruit { get; set; }

        public virtual ProductionPhase ProductionPhase { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Irrigation> Irrigations { get; set; }
    }
}
