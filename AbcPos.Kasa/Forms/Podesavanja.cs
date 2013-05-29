using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using DevExpress.XtraEditors;
using Ninject;

namespace AbcPos.Kasa.Forms
{
    public partial class Podesavanja : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILocalRepository m_Repository;

        private KonfiguracijaKase m_Konfig;

        public Podesavanja()
        {
            InitializeComponent();
            simpleButton1.Click += (s, e) => Sacuvaj();
        }

        [Inject]
        public Podesavanja(ILocalRepository repository) : this()
        {
            m_Repository = repository;
        }

        protected override void OnLoad(EventArgs e)
        {
            m_Konfig = m_Repository.VratiKonfiguracijuKase();
            konfiguracijaKaseBindingSource.DataSource = m_Konfig;
        }

        private void Sacuvaj()
        {
            m_Repository.Submit();
            Shell.ShowInfo("Podaci su uspešno sačuvani");
        }
    }
}
