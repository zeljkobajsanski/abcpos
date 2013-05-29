using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Repository;
using AbcPos.Kasa.Properties;
using AbcPos.Kasa.SyncService;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using System.Linq;

namespace AbcPos.Kasa.Forms
{
    public partial class Shell : DevExpress.XtraEditors.XtraForm
    {
        public Shell()
        {
            InitializeComponent();
            Database.SetInitializer(new LocalDbInit());
            var logout = new DelegateAction(() => true, () => { });
            logout.Caption = "Odjavi me";
            logout.Image = Resources.user;
            logout.Type = ActionType.Navigation;
            logout.Edge = ActionEdge.Right;
            logout.Behavior = ActionBehavior.HideBarOnClick;
            windowsUIView1.ContentContainerActions.Add(logout);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(0x081A);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(0x081A);

            Init();
        }

        private void Init()
        {
            LocalDatabasePath.Init();
        }

        private void LoadControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            switch (e.Document.ControlName)
            {
                case "Sinhronizacija":
                    e.Control = IoC.Singleton().Get<Sinhronizacija>();
                    break;
                case "Kasa":
                    e.Control = new Kasa();
                    break;
                case "PregledProdaje":
                    e.Control = new PregledProdaje();
                    break;
                case "Podesavanja":
                    e.Control = IoC.Singleton().Get<Podesavanja>();
                    break;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            UpdateTiles();
        }

        public static void ShowError(string message)
        {
            XtraMessageBox.Show(message, "ABC Pos - Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message)
        {
            XtraMessageBox.Show(message, "ABC Pos - Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowInfo(string message)
        {
            XtraMessageBox.Show(message, "ABC Pos - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowQuestion(string question)
        {
            return DialogResult.Yes == 
                XtraMessageBox.Show(question, "ABC POS - Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
        }

        private void DocumentDeactivated(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            UpdateTiles();
        }

        private void UpdateTiles()
        {
            using (var repo = IoC.Singleton().Get<ILocalRepository>())
            {
                var sinhronizacija = repo.VratiSinhronizaciju(repo.VratiKonfiguracijuKase().ProdavnicaID);
                if (sinhronizacija != null)
                {
                    SinhronizacijaTile.Elements[1].Text = "<size=10><b>" + sinhronizacija.UspesnaSinhronizacija + "</b></br>" +
                                                          "Broj artikala: " + sinhronizacija.BrojArtikala + "</br>" +
                                                          "Broj računa: " + sinhronizacija.BrojRacuna + "</size>";
                }
                var racuni = repo.VratiDanasnjeRacune();
                var brojRacuna = racuni.Count();
                if (brojRacuna > 0)
                {
                    var ukupno = racuni.Sum(x => x.IznosRacuna);
                    var gotovina = racuni.Sum(x => x.Gotovina ?? 0);
                    var kartice = racuni.Sum(x => x.Kartica ?? 0);
                    var cek = racuni.Sum(x => x.Cek ?? 0);
                    KasaTile.Elements[1].Text = "<size=10>" +
                                                "Broj računa: " + brojRacuna + "</br>" +
                                                "Gotovina: " + gotovina.ToString("n2") + "</br>" +
                                                "Kartice: " + kartice.ToString("n2") + "</br>" +
                                                "Čekovi: " + cek.ToString("n2") + "</br>" +
                                                "<b>Ukupno: " + ukupno.ToString("n2") + "</b>" +
                                                "</size>";

                }
            }
        }

        
    }
}