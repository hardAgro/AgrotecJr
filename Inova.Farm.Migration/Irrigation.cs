namespace Inova.Farm.Migration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Irrigation")]
    public partial class Irrigation
    {
        public int Id { get; set; }

        public double? Amount { get; set; }
    }
}
