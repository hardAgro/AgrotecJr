namespace Inova.Farm.Migration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductionPhase")]
    public partial class ProductionPhase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductionPhase()
        {
            CurrentProductions = new HashSet<CurrentProduction>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FaseFenologica { get; set; }

        public int? KCNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrentProduction> CurrentProductions { get; set; }
    }
}
