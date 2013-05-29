using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AbcPos.Kasa.ViewModels;
using DevExpress.XtraEditors;

namespace AbcPos.Kasa.Forms
{
    public partial class PregledProdaje : DevExpress.XtraEditors.XtraForm
    {
        private readonly PregledProdajeViewModel fViewModel;
        
        public PregledProdaje()
        {
            InitializeComponent();
            fViewModel = IoC.Singleton().Get<PregledProdajeViewModel>();
            pregledProdajeViewModelBindingSource.DataSource = fViewModel;

            simpleButton1.Click += (s, e) => fViewModel.Prikazi();
            colKolicina.DisplayFormat.FormatString = "n" + fViewModel.Konfiguracija.BrojDecimalaZaKolicinu;
        }
    }
}
