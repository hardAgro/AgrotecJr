using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Inova.Farm.SistemaInterfaceWeb.Models
{
    [Table("SoilCondition")]
    public partial class SoilCondition
    {
        public int Id { get; set; }

        public double MeasuredHumidity { get; set; }

        public int IrrigationId { get; set; }

        public virtual Irrigation Irrigation { get; set; }
    }
}
