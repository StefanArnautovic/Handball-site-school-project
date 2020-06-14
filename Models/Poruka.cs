namespace STEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Poruka")]
    public partial class Poruka
    {
        public int PorukaID { get; set; }

        public int KorisnikID { get; set; }

        [Required]
        [StringLength(500)]
        public string Sadrzaj { get; set; }

        public DateTime? Datum { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
