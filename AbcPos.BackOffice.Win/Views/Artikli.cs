using System;
using System.ComponentModel;
using AbcPos.BackOffice.Win.Dialogs;
using AbcPos.BackOffice.Win.Messages;
using AbcPos.BackOffice.Win.Models.Mappings;
using AbcPos.BackOffice.Win.Models.Validation;
using AbcPos.BackOffice.Win.Services.BackendService;
using Artikal = AbcPos.BackOffice.Win.Models.Entities.Artikal;
using System.Linq;

namespace AbcPos.BackOffice.Win.Views
{
    public partial class Artikli : View
    {
        private BindingList<Artikal> m_Artikli;

        private Artikal m_TrenutniArtikal;

        public Artikli()
        {
            InitializeComponent();
            m_Artikli = new BindingList<Artikal>();
            artikalBindingSource.DataSource = m_Artikli;
            artikalBindingSource.CurrentChanged += ArtikalBindingSourceOnCurrentItemChanged;
        }

        private void ArtikalBindingSourceOnCurrentItemChanged(object sender, EventArgs eventArgs)
        {
            if (m_TrenutniArtikal != null)
            {
                m_TrenutniArtikal.PropertyChanged -= TrenutniArtikalPropertyChanged;
            }
            m_TrenutniArtikal = artikalBindingSource.Current as Artikal;
            if (m_TrenutniArtikal != null)
            {
                m_TrenutniArtikal.PropertyChanged += TrenutniArtikalPropertyChanged;
            }
        }

        private void TrenutniArtikalPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SacuvajArtikal(m_TrenutniArtikal);
        }

        private void SacuvajArtikal(Artikal artikal)
        {
            if (artikal != null && artikal.Validator.IsValid(artikal))
            {
                var a = Mapper.Map(artikal);
                using (var svc = new BackendServiceClient())
                {
                    svc.SacuvajArtikalCompleted += (s, e) => OnSendMessage(new MessageSaved());
                    svc.SacuvajArtikalAsync(a);
                }    
            }
            
        }

        public override bool ImplementiranoOsvezanjvanje
        {
            get { return true; }
        }

        public override void Osvezi()
        {
            IsBusy = true;
            m_Artikli.Clear();
            using (var svc = new BackendServiceClient())
            {
                svc.VratiArtikleCompleted += (s, e) =>
                {
                    var artikli = e.Result.Select(Mapper.Map).ToList();
                    m_Artikli = new BindingList<Artikal>(artikli);
                    artikalBindingSource.DataSource = m_Artikli;
                    IsBusy = false;
                };
                svc.VratiJediniceMeraCompleted += (s, e) =>
                {
                    jedinicaMereBindingSource.DataSource = e.Result.Select(Mapper.Map);
                };
                svc.VratiPdvCompleted += (s, e) =>
                {
                    pdvBindingSource.DataSource = e.Result.Select(Mapper.MapPdv);
                };
                svc.VratiJediniceMeraAsync();
                svc.VratiPdvAsync();
                svc.VratiArtikleAsync();
            }
        }

        public override bool ImplementiranoSacuvaj
        {
            get { return true; }
        }

        public override void Sacuvaj()
        {
            var artikal = gridView1.GetFocusedRow() as Artikal;
            SacuvajArtikal(artikal);
        }

        public override bool ImplementiranNoviUnos
        {
            get
            {
                return true;
            }
        }

        public override void NoviUnos()
        {
            using (var d = new UnosArtikla(jedinicaMereBindingSource.DataSource, pdvBindingSource.DataSource))
            {
                d.ShowDialog(this);
                if (d.Artikal.Id != 0)
                {
                    m_Artikli.Add(d.Artikal);
                    var ix = artikalBindingSource.IndexOf(d.Artikal);
                    artikalBindingSource.Position = ix;
                    OnSendMessage(new MessageSaved());
                }
            }
        }
    }
}