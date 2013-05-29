using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AbcPos.Core.Models;

namespace AbcPos.Core.Repository
{
    public class LocalDataContext : DataContext
    {
        public LocalDataContext()
        {
        }

        public LocalDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Sinhronizacija> Sinhronizacija { get; set; }
        public DbSet<KonfiguracijaKase> KonfiguracijaKase { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            // Racuni
            var racuni = modelBuilder.Entity<Racun>();
            racuni.ToTable("Racuni");
            racuni.Ignore(x => x.StavkeRacuna);

            // Stavke racuna
            var stavkaRacuna = modelBuilder.Entity<StavkaRacuna>();
            stavkaRacuna.Ignore(x => x.Sifra);
            stavkaRacuna.Ignore(x => x.Rbr);

            // Artikli
            var artikli = modelBuilder.Entity<Artikal>();
            artikli.Ignore(x => x.Zaliha);
            artikli.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Komitenti
            var komitenti = modelBuilder.Entity<Komitent>();
            komitenti.Map<Dobavljac>(x => x.Requires("Tip").HasValue("D"));
            
            
            // Dokumenti
            var dokumenti = modelBuilder.Entity<Dokument>();
            dokumenti.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Radnja>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Pdv>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<JedinicaMere>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            // Sinhronizacija
            var sinhronizacija = modelBuilder.Entity<Sinhronizacija>();
            sinhronizacija.Ignore(x => x.BrojArtikala);
            sinhronizacija.Ignore(x => x.BrojRacuna);
            
            // Zalihe
            var zalihe = modelBuilder.Entity<Zaliha>();
            zalihe.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            zalihe.Ignore(x => x.MaximalnaZaliha);
            zalihe.Ignore(x => x.MinimalnaZaliha);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}