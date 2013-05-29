using System.Data.Entity;

namespace AbcPos.Core.Repository
{
    public class DbInit : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            //const string cmd = "CREATE UNIQUE NONCLUSTERED INDEX [IX_SifraArtikla] ON [dbo].[Artikal]([Sifra] ASC)";
            //context.Database.ExecuteSqlCommand(cmd);
        }
    }
}