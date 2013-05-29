using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using AbcPos.Kasa.Models;
using AbcPos.Kasa.SyncService;
using System.Linq;
using NLog;
using Ninject;
using ISyncService = AbcPos.Kasa.Services.ISyncService;

namespace AbcPos.Kasa.Forms
{
    public partial class Sinhronizacija : DevExpress.XtraEditors.XtraForm
    {
        private Core.Models.Sinhronizacija fStanjeSinhronizacije;

        [Inject]
        public ILocalRepository Repository { get; set; }

        [Inject]
        public ISyncService SyncService { get; set; }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Sinhronizacija()
        {
            InitializeComponent();
            simpleButton1.Click += (s, e) => Sinhronizuj();
            progressPanel1.Visible = false;
            worker.DoWork += (sender, args) =>
            {
                Logger.Debug("Synchronizing...");
                simpleButton1.Invoke(new Action(() => simpleButton1.Enabled = false));
                progressPanel1.Invoke(new Action(() => progressPanel1.Visible = true));
                var idProdavnice = VratiIdProdavnice().ToString();
                var racuni = Repository.VratiNesinhronizovaneRacune();
                Logger.Debug("Remote service call...");
                SyncResult result = null;
                try
                {
                    result = SyncService.SinhronizujKasu(idProdavnice, racuni);
                    Logger.Debug("Remote service end...");
                }
                catch (Exception exc)
                {
                    Logger.ErrorException("Remote service error", exc);
                    throw;
                }
                args.Result = result;
                UpdateDatabase(result);
            };
            worker.RunWorkerCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    var sync = Repository.VratiSinhronizaciju(VratiIdProdavnice());
                    sync.PoslednjaSinhronizacija = DateTime.Now;
                    fStanjeSinhronizacije.PoslednjaSinhronizacija = sync.PoslednjaSinhronizacija;
                    Repository.Submit();
                    Logger.ErrorException("Sinhornizacija nije uspela", e.Error);
                    Shell.ShowError("Sinhonizacija nije uspela");
                }
                simpleButton1.Invoke(new Action(() => simpleButton1.Enabled = true));
                progressPanel1.Invoke(new Action(() => progressPanel1.Visible = false));
            };
        }

        

        private void Sinhronizuj()
        {
            worker.RunWorkerAsync();
        }

        private void UpdateDatabase(SyncResult result)
        {
            Logger.Debug("Updating database...");
            try
            {
                KonfiguracijaKase konfiguracija = null;
                using (var repo = IoC.Singleton().Get<ILocalRepository>())
                {
                    konfiguracija = repo.VratiKonfiguracijuKase();
                }
                using (var repo = LocalDatabasePath.GetLocalCopyRepostiory())
                {
                    repo.SetAutoDetectChangesEnabled(false);
                    repo.SetValidateOnSaveEnabled(false);
                    repo.DropAndCreateDatabase();
                    repo.InsertKonfiguracija(konfiguracija);
                    if (result.Radnja != null)
                    {
                        repo.Insert(result.Radnja);
                    }
                    foreach (var pdv in result.Pdv)
                    {
                        repo.Insert(pdv);
                    }
                    foreach (var jedinicaMere in result.JediniceMere)
                    {
                        repo.Insert(jedinicaMere);
                    }
                    foreach (var artikal in result.Artikli)
                    {
                        artikal.IzjednaciZalihu();
                        repo.Insert(artikal);
                    }
                    foreach (var racun in result.Racuni)
                    {
                        repo.SacuvajRacun(racun);
                    }

                    repo.Submit();
                    fStanjeSinhronizacije.ID = 0;
                    fStanjeSinhronizacije.PoslednjaSinhronizacija = DateTime.Now;
                    fStanjeSinhronizacije.UspesnaSinhronizacija = fStanjeSinhronizacije.PoslednjaSinhronizacija;
                    fStanjeSinhronizacije.BrojArtikala = result.Artikli.Length;
                    repo.SacuvajSinhronizaciju(fStanjeSinhronizacije);
                }

                LocalDatabasePath.SwapDatabases();
                Logger.Debug("Database updated.");
            }
            catch (Exception exc)
            {
                Logger.ErrorException("Update database error", exc);
                throw;
            }
            OsveziStatistiku();
            Shell.ShowInfo("Sinhronizacija je uspešno završena");
        }

        protected override void OnLoad(EventArgs e)
        {
            OsveziStatistiku();
        }

        private void OsveziStatistiku()
        {
            using (var repo = IoC.Singleton().Get<ILocalRepository>())
            {
                var idProdavnice = VratiIdProdavnice();
                fStanjeSinhronizacije = repo.VratiSinhronizaciju(idProdavnice);
                if (fStanjeSinhronizacije == null)
                {
                    fStanjeSinhronizacije = new Core.Models.Sinhronizacija{RadnjaID = idProdavnice};
                    repo.SacuvajSinhronizaciju(fStanjeSinhronizacije);
                }
            }
            stanjeSinhronizacijeBindingSource.DataSource = fStanjeSinhronizacije;
        }

        private int VratiIdProdavnice()
        {
            return Repository.VratiKonfiguracijuKase().ProdavnicaID;
        }
    }
}
