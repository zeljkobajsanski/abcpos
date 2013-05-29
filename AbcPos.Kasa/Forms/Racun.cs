using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using AbcPos.Kasa.Models;
using AbcPos.Kasa.ViewModels;
using DevExpress.XtraEditors;

namespace AbcPos.Kasa.Forms
{
    public partial class Racun : DevExpress.XtraEditors.XtraUserControl
    {
        private RacunViewModel fRacunViewModel;

        public Racun()
        {
            InitializeComponent();
            fRacunViewModel = IoC.Singleton().Get<RacunViewModel>();
            NoviRacun(false, false);
            textEdit1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(fRacunViewModel.Sifra))
                    {
                        PrikaziPretraguArtikala();
                    }
                    else
                    {
                        fRacunViewModel.PretraziArtikal();    
                    }
                }
            };
            textEdit1.ButtonClick += (s, e) => PrikaziPretraguArtikala();
            textEdit2.KeyDown += (s, e) =>
                                     {
                                         if (e.KeyCode == Keys.Enter)
                                         {
                                             try
                                             {
                                                 fRacunViewModel.PrihvatiKolicinu();
                                             }
                                             catch (Exception exc)
                                             {
                                                 Shell.ShowWarning(exc.Message);
                                             }
                                         }
                                     };
            gridView1.RowClick += (s, e) =>
                                      {
                                          var stavka = gridView1.GetFocusedRow() as StavkaRacuna;
                                          if (stavka != null)
                                          {
                                              fRacunViewModel.StavkaRacuna = stavka;
                                          }
                                      };
            btnUplati.Click += (s, e) =>
                                   {
                                       using (var dlg = new NacinPlacanja(fRacunViewModel.Racun))
                                       {
                                           var result = dlg.ShowDialog(this);
                                           if (DialogResult.OK == result)
                                           {
                                               var racun = fRacunViewModel.Sacuvaj();
                                               if (!worker.IsBusy)
                                               {
                                                   worker.RunWorkerAsync(racun);    
                                               }
                                               NoviRacun(false, false);
                                           }
                                       }
                                   };
            gridView1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete)
                {
                    var stavka = gridView1.GetFocusedRow() as StavkaRacuna;
                    fRacunViewModel.ObrisiStavku(stavka);
                }
            };
            worker.DoWork += (sender, args) =>
            {
                var racun = args.Argument as Core.Models.Racun;
                fRacunViewModel.SinhronizujRacun(racun);
                args.Result = racun;
            };
            worker.RunWorkerCompleted += (s, e) =>
            {
                if (e.Error == null)
                {
                    var racun = e.Result as Core.Models.Racun;
                    fRacunViewModel.OznaciSinhronizovanRacun(racun);
                }
            };
            var formatZaKolicinu = "n" + fRacunViewModel.KonfiguracijaKase.BrojDecimalaZaKolicinu;
            colKolicina.DisplayFormat.FormatString = formatZaKolicinu;
            textEdit2.DataBindings[0].FormatString = formatZaKolicinu;
        }

        protected override void OnLoad(EventArgs e)
        {
            textEdit1.Focus();
        }

        private void ViewModelChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Artikal":
                    if (fRacunViewModel.Artikal != null)
                    {
                        textEdit2.Focus();
                    }
                    else
                    {
                        textEdit1.Focus();
                    }
                    break;
            }
        }

        private void PrikaziPretraguArtikala()
        {
            using (var dlg = new PretragaArtikala())
            {
                dlg.ShowDialog(this);
                fRacunViewModel.Artikal = dlg.IzabraniArtikal;
            }
        }

        public void NoviRacun(bool question, bool vratiZalihe)
        {
            if (question)
            {
                if (!Shell.ShowQuestion("Da li želite da kreirate novi račun?")) return;
            }
            if (vratiZalihe)
            {
                fRacunViewModel.VratiZalihe();
            }
            fRacunViewModel = IoC.Singleton().Get<RacunViewModel>();
            fRacunViewModel.PropertyChanged += ViewModelChanged;
            racunViewModelBindingSource.DataSource = fRacunViewModel;
            racunBindingSource.DataSource = fRacunViewModel.Racun;
        }

        public RacunViewModel ViewModel
        {
            get { return fRacunViewModel; }
        }
    }
}
