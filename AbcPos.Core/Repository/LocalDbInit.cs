using System.Data.Entity;
using AbcPos.Core.Models;
using System.Linq;

namespace AbcPos.Core.Repository
{
    public class LocalDbInit : IDatabaseInitializer<LocalDataContext>
    {
        public void InitializeDatabase(LocalDataContext context)
        {
            context.Database.CreateIfNotExists();
            if (!context.KonfiguracijaKase.Any())
            {
                context.KonfiguracijaKase.Add(new KonfiguracijaKase()
                {
                    ProdavnicaID = 1,
                    BrojDecimalaZaKolicinu = 2,
                    DozvoljeneNegativneZalihe = false,
                    Web = "http://localhost:53723/SyncService.svc/http"
                });
                context.SaveChanges();    
            }
            
        }
    }
}