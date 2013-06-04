using System;
using System.Windows.Forms;
using AbcPos.BackOffice.Win.Messages;
using AbcPos.BackOffice.Win.Properties;
using AbcPos.BackOffice.Win.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using View = AbcPos.BackOffice.Win.Views.View;

namespace AbcPos.BackOffice.Win
{
    public partial class Main : XtraForm
    {
        public Main()
        {
            InitializeComponent();
            AddContextMenu();
        }

        private void AddContextMenu()
        {
            var novi = new DelegateAction(OmoguciNoviUnos, NoviUnos);
            novi.Caption = "Novi unos";
            //logout.Image = Resources.user;
            novi.Type = ActionType.Context;
            novi.Edge = ActionEdge.Left;
            novi.Behavior = ActionBehavior.HideBarOnClick;
            windowsUIView1.ContentContainerActions.Add(novi);
            var refresh = new DelegateAction(OmoguciOsvezi, Osvezi);
            refresh.Caption = "Osveži";
            //logout.Image = Resources.user;
            refresh.Type = ActionType.Context;
            refresh.Edge = ActionEdge.Left;
            refresh.Behavior = ActionBehavior.HideBarOnClick;
            windowsUIView1.ContentContainerActions.Add(refresh);
            var sacuvaj = new DelegateAction(OmoguciSacuvaj, Sacuvaj);
            sacuvaj.Caption = "Sačuvaj";
            //logout.Image = Resources.user;
            sacuvaj.Type = ActionType.Context;
            sacuvaj.Edge = ActionEdge.Left;
            sacuvaj.Behavior = ActionBehavior.HideBarOnClick;
            windowsUIView1.ContentContainerActions.Add(sacuvaj);
        }

        private void NoviUnos()
        {
            if (AktivniView != null)
            {
                AktivniView.NoviUnos();
            }
        }

        private bool OmoguciNoviUnos()
        {
            return AktivniView != null && AktivniView.ImplementiranNoviUnos;
        }

        private void Sacuvaj()
        {
            if (AktivniView != null)
            {
                AktivniView.Sacuvaj();
            }
        }

        private bool OmoguciSacuvaj()
        {
            return AktivniView != null && AktivniView.ImplementiranoSacuvaj;
        }

        private void Osvezi()
        {
            if (AktivniView != null)
            {
                AktivniView.Osvezi();
            }
        }

        private bool OmoguciOsvezi()
        {
            return AktivniView != null && AktivniView.ImplementiranoOsvezanjvanje;
        }

        private void windowsUIView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            switch (e.Document.ControlTypeName)
            {
                case "AbcPos.BackOffice.Win.Views.Artikli":
                    e.Control = new Artikli();
                    break;
            }
            var view = e.Control as View;
            view.SendMessage += ViewOnSendMessage;
        }

        private void ViewOnSendMessage(object sender, SendMessageEventArgs e)
        {
            switch (e.Message.MessageType)
            {
                    case MessageType.Info:
                        alertControl1.Show(this, "Info", e.Message.MessageText, Resources.info_32x32);
                        break;
                    case MessageType.Wraning:
                        alertControl1.Show(this, "Upozorenje", e.Message.MessageText, Resources.warning_32x32);
                        break;
                    case MessageType.Error:
                        alertControl1.Show(this, "Greška", e.Message.MessageText, Resources.error_32x32);
                        break;
                    case MessageType.Question:
                        e.Confirmed = XtraMessageBox.Show(this, e.Message.MessageText, "Upit", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                        break;
            }
        }

        private View AktivniView
        {
            get {
                if (documentManager1.View.ActiveDocument != null)
                {
                    return documentManager1.View.ActiveDocument.Control as View;
                }
                return null;
            }
        }
    }
}
