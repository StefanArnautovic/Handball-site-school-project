namespace STEF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=rukomet")
        {
        }

        public virtual DbSet<Igrac> Igrac { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Poruka> Poruka { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Takmicenje> Takmicenje { get; set; }
        public virtual DbSet<Tim> Tim { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Poruka)
                .WithRequired(e => e.Korisnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Takmicenje>()
                .HasMany(e => e.Tim)
                .WithRequired(e => e.Takmicenje)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tim>()
                .HasMany(e => e.Igrac)
                .WithRequired(e => e.Tim)
                .WillCascadeOnDelete(false);
        }
    }
}
