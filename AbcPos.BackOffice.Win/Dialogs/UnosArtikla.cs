using System;
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

        protected override void OnLoad(EventArgs e)
        {
            SifraTextEdit.Focus();
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