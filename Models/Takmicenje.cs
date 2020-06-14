namespace STEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Takmicenje")]
    public partial class Takmicenje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Takmicenje()
        {
            Tim = new HashSet<Tim>();
        }

        public int TakmicenjeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(50)]
        public string Grupa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tim> Tim { get; set; }
    }
}
