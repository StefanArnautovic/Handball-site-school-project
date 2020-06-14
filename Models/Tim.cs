namespace STEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tim")]
    public partial class Tim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tim()
        {
            Igrac = new HashSet<Igrac>();
        }

        public int TimID { get; set; }

        public int TakmicenjeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        public int BrojBodova { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Igrac> Igrac { get; set; }

        public virtual Takmicenje Takmicenje { get; set; }
    }
}
