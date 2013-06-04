using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AbcPos.BackOffice.Win.Models.Mappings;
using AbcPos.BackOffice.Win.Services.BackendService;
using Dobavljac = AbcPos.BackOffice.Win.Models.Entities.Dobavljac;

namespace AbcPos.BackOffice.Win.Dialogs
{
    public partial class UnosDobavljaca : DijalogUnosa
    {
        public UnosDobavljaca()
        {
            InitializeComponent();
            Dobavljac = new Dobavljac();
            dobavljacBindingSource.DataSource = Dobavljac;
        }

        public Dobavljac Dobavljac { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            SifraTextEdit.Focus();
        }

        protected override void Sacuvaj()
        {
            if (Dobavljac.Validator.IsValid(Dobavljac))
            {
                using (var svc = new BackendServiceClient())
                {
                    svc.SacuvajDobavljacaCompleted += (s, e) =>
                    {
                        Dobavljac.Id = e.Result;
                        Close();
                    };
                    svc.SacuvajDobavljacaAsync(Mapper.Map(Dobavljac));
                }
            }
        }
    }
}
