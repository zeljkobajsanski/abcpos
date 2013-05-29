using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using AbcPos.Core.Models;

namespace AbcPos.Core.Repository
{
    public class DataContext : DbContext
    {
        public DataContext() : this("Abc")
        {
        }

        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Radnja> Radnje { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Zaliha> Zalihe { get; set; }
        public DbSet<Pdv> Pdv { get; set; }
        public DbSet<JedinicaMere> JediniceMere { get; set; }
        public DbSet<Komitent> Komitenti { get; set; }
        public DbSet<Dokument> Dokumenti { get; set; }
        public DbSet<StavkaDokumenta> StavkeDokumenta { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var dokumenti = modelBuilder.Entity<Dokument>();
            //dokumenti.Ignore(x => x.Sinhronizovan);
            var racuni = modelBuilder.Entity<Racun>();
            racuni.ToTable("Racuni");
            racuni.Ignore(x => x.StavkeRacuna);
            var stavkaRacuna = modelBuilder.Entity<StavkaRacuna>();
            stavkaRacuna.Ignore(x => x.Sifra);
            stavkaRacuna.Ignore(x => x.Rbr);
            var artikli = modelBuilder.Entity<Artikal>();
            artikli.Ignore(x => x.Zaliha);
            var komitenti = modelBuilder.Entity<Komitent>();
            komitenti.Map<Dobavljac>(x => x.Requires("Tip").HasValue("D"));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
    }
}