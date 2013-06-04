using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AbcPos.BackOffice.Win.Models.Entities;
using AbcPos.BackOffice.Win.Models.Mappings;
using AbcPos.BackOffice.Win.Services.BackendService;
using DevExpress.XtraEditors;
using Artikal = AbcPos.BackOffice.Win.Models.Entities.Artikal;

namespace AbcPos.BackOffice.Win.Dialogs
{
    public partial class UnosArtikla : XtraForm
    {
        private readonly Artikal m_Artikal = new Artikal(); 
        
        public UnosArtikla()
        {
            InitializeComponent();
            artikalBindingSource.DataSource = m_Artikal;
            btnSacuvaj.Click += (s, e) => Sacuvaj();
        }

        public UnosArtikla(object jediniceMera, object pdv) : this()
        {
            jedinicaMereBindingSource.DataSource = jediniceMera;
            pdvBindingSource.DataSource = pdv;
        }

        private void Sacuvaj()
        {
            if (m_Artikal.Validator.IsValid(m_Artikal))
            {
                var a = Mapper.Map(m_Artikal);
                using (var svc = new BackendServiceClient())
                {
                    svc.SacuvajArtikalCompleted += (s, e) =>
                    {
                        m_Artikal.Id = e.Result;
                        Close();
                    };
                    svc.SacuvajArtikalAsync(a);
                }    
            }
        }

        public Artikal Artikal { get { return m_Artikal; } }
    }
}