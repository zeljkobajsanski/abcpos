using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AbcPos.Kasa.Forms
{
    public partial class Kasa : DevExpress.XtraEditors.XtraForm
    {
        public Kasa()
        {
            InitializeComponent();
            barButtonItem1.ItemClick += (s, e) =>
            {
                var active = documentManager1.View.ActiveDocument;
                if (active != null)
                {
                    var racun = (Racun)active.Control;
                    racun.NoviRacun(true, true);
                }
            };
            barButtonItem2.ItemClick += (s, e) => documentManager1.View.Controller.AddDocument(new Racun(){Text = "Račun"});
        }

        private void LoadDocument(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Document.ControlName == "Racun")
            {
                e.Control = new Racun();
            }
        }

        private void RacunClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e)
        {
            var racun = e.Document.Control as Racun;
            racun.ViewModel.VratiZalihe();
        }
    }
}
