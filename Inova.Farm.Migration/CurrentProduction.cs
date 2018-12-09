namespace Inova.Farm.Migration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrentProduction")]
    public partial class CurrentProduction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FruitName { get; set; }

        public int CurrentPhaseId { get; set; }

        public int UserId { get; set; }

        public virtual ProductionPhase ProductionPhase { get; set; }

        public virtual User User { get; set; }
    }
}
