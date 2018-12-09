namespace Inova.Farm.Migration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            CurrentProductions = new HashSet<CurrentProduction>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FarmName { get; set; }

        [Required]
        [StringLength(50)]
        public string MainFruit { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrentProduction> CurrentProductions { get; set; }
    }
}
