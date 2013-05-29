using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AbcPos.Core.Models;
using AbcPos.Kasa.ViewModels;
using DevExpress.XtraEditors;

namespace AbcPos.Kasa.Forms
{
    public partial class PretragaArtikala : DevExpress.XtraEditors.XtraForm
    {
        private readonly PretragaArtikalaViewModel m_Model;

        public PretragaArtikala()
        {
            InitializeComponent();
            m_Model = IoC.Singleton().Get<PretragaArtikalaViewModel>();
            pretragaArtikalaViewModelBindingSource.DataSource = m_Model;
            btnPretrazi.Click += (s, e) => Pretrazi();
            btnPonisti.Click += (s, e) => Ponisti();
            worker.DoWork += (s, e) =>
            {
                ShowProgress(true);
                m_Model.Pretrazi();
                e.Result = m_Model.Zalihe;
            };
            worker.RunWorkerCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    Shell.ShowError(e.Error.Message);
                }
                artikliBindingSource.DataSource = e.Result;
                gridView1.Focus();
                ShowProgress(false);
            };
            KeyDown += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (gridControl1.Focused)
                        {
                            IzaberiArtikal();
                        }
                        else
                        {
                            Pretrazi();    
                        }
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                }
            };
            gridView1.DoubleClick += (s, e) => IzaberiArtikal();
            colZaliha.DisplayFormat.FormatString = "n" + m_Model.KonfiguracijaKase.BrojDecimalaZaKolicinu;
        }

        private void IzaberiArtikal()
        {
            IzabraniArtikal = ((Zaliha)gridView1.GetFocusedRow()).Artikal;
            Close();
        }

        public void Pretrazi()
        {
            worker.RunWorkerAsync(null);
        }

        public void Ponisti()
        {
            m_Model.Zalihe.Clear();
            m_Model.Naziv = null;
            m_Model.Sifra = null;
        }

        public Artikal IzabraniArtikal
        {
            get { return m_Model.IzabraniArtikal; }
            set { m_Model.IzabraniArtikal = value; }
        }

        private void ShowProgress(bool showOrHide)
        {
            progressPanel1.Invoke(new Action(() => progressPanel1.Visible = showOrHide));
        }
    }
}
