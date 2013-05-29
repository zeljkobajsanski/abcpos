using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using System.Linq;
using AbcPos.Core.Utils;

namespace AbcPos.Core.Repository
{
    public partial class Repository : IRepository
    {
        protected DataContext DataContext;

        public Repository()
        {
            DataContext = new DataContext();
        }

        public Repository(string connectionStringOrName)
        {
            DataContext = new DataContext(connectionStringOrName);
        }

        public Repository(DataContext context)
        {
            DataContext = context;
        }

        public void InitDb()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            Database.SetInitializer(new CreateDatabase());
        }

        public Radnja[] Radnje()
        {
            return DataContext.Radnje.ToArray();
        }

        public Pdv[] Pdv()
        {
            return DataContext.Pdv.ToArray();
        }

        public int DefaultPdv()
        {
            var pdv = DataContext.Pdv.FirstOrDefault(x => x.Default);
            return pdv != null ? pdv.ID : 0;
        }

        public JedinicaMere[] JediniceMere()
        {
            return DataContext.JediniceMere.ToArray();
        }

        public int DefaultJedinicaMere()
        {
            var jm = DataContext.JediniceMere.FirstOrDefault(x => x.Default);
            return jm != null ? jm.ID : 0;
        }

        public void Submit()
        {
            DataContext.SaveChanges();
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }

        public void DropAndCreateDatabase()
        {
            DataContext.Database.Delete();
            DataContext.Database.CreateIfNotExists();
        }

        public void RecycleContext()
        {
            DataContext = new DataContext(DataContext.Database.Connection.ConnectionString);
        }

        public Radnja VratiRadnju(int idRadnje)
        {
            return DataContext.Radnje.SingleOrDefault(x => x.ID == idRadnje);
        }

        public void SacuvajRadnju(Radnja radnja)
        {
            if (radnja.ID == 0)
            {
                DataContext.Radnje.Add(radnja);
            }
            Submit();
        }

        public void Insert(Pdv pdv)
        {
            DataContext.Pdv.Add(pdv);
        }

        public void Insert(JedinicaMere jedinicaMere)
        {
            DataContext.JediniceMere.Add(jedinicaMere);
        }

        public void Insert(Radnja radnja)
        {
            DataContext.Radnje.Add(radnja);
        }

        public void SetAutoDetectChangesEnabled(bool enable)
        {
            DataContext.Configuration.AutoDetectChangesEnabled = enable;
        }

        public void SetValidateOnSaveEnabled(bool enable)
        {
            DataContext.Configuration.ValidateOnSaveEnabled = enable;
        }
    }
}