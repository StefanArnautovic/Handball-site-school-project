namespace STEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Igrac")]
    public partial class Igrac
    {
        public int IgracID { get; set; }

        public int TimID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(10)]
        public string GodinaRodjenja { get; set; }

        [Required]
        [StringLength(50)]
        public string Pozicija { get; set; }

        public virtual Tim Tim { get; set; }
    }
}
