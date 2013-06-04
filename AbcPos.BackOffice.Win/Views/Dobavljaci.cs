using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AbcPos.BackOffice.Win.Dialogs;
using AbcPos.BackOffice.Win.Messages;
using AbcPos.BackOffice.Win.Models.Entities;
using AbcPos.BackOffice.Win.Models.Mappings;
using AbcPos.BackOffice.Win.Services.BackendService;

namespace AbcPos.BackOffice.Win.Views
{
    public partial class Dobavljaci : View
    {

        private Models.Entities.Dobavljac m_Dobavljac;

        public Dobavljaci()
        {
            InitializeComponent();
            dobavljacBindingSource1.CurrentChanged += (s, e) =>
            {
                if (m_Dobavljac != null)
                {
                    m_Dobavljac.PropertyChanged -= OnDobavljacPropertyChanged;
                }
                m_Dobavljac = dobavljacBindingSource1.Current as Models.Entities.Dobavljac;
                if (m_Dobavljac != null)
                {
                    m_Dobavljac.PropertyChanged += OnDobavljacPropertyChanged;
                }
            };
        }

        private void OnDobavljacPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            SacuvajDobavljaca();
        }

        private void SacuvajDobavljaca()
        {
            if (m_Dobavljac != null && m_Dobavljac.Validator.IsValid(m_Dobavljac))
            {
                using (var svc = new BackendServiceClient())
                {
                    svc.SacuvajDobavljacaCompleted += (s, e) => OnSendMessage(new MessageSaved());
                    svc.SacuvajDobavljacaAsync(Mapper.Map(m_Dobavljac));
                }
            }
        }

        public override bool ImplementiranoOsvezanjvanje
        {
            get { return true; }
        }

        public override void Osvezi()
        {
            using (var svc = new BackendServiceClient())
            {
                IsBusy = true;
                svc.VratiDobavljaceCompleted += (s, e) =>
                {
                    dobavljacBindingSource1.DataSource = e.Result.Select(Mapper.Map);
                    IsBusy = false;
                };
                svc.VratiDobavljaceAsync();
            }
        }

        public override bool ImplementiranoSacuvaj
        {
            get
            {
                return true;
            }
        }

        public override void Sacuvaj()
        {
            SacuvajDobavljaca();
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
            using (var d = new UnosDobavljaca())
            {
                d.ShowDialog(this);
                if (d.Dobavljac.Id != 0)
                {
                    OnSendMessage(new MessageSaved());
                    dobavljacBindingSource1.Add(d.Dobavljac);
                    var ix = dobavljacBindingSource1.IndexOf(d.Dobavljac);
                    dobavljacBindingSource1.Position = ix;
                }
            }
        }
    }
}
