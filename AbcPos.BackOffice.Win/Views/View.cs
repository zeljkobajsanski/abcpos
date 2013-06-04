using System;
using System.Windows.Forms;
using AbcPos.BackOffice.Win.Messages;
using DevExpress.XtraEditors;
using Message = AbcPos.BackOffice.Win.Messages.Message;

namespace AbcPos.BackOffice.Win.Views
{
    public class View : XtraForm
    {
        private bool m_IsBusy;
        
        public virtual bool ImplementiranoOsvezanjvanje { get { return false; } }

        public virtual bool ImplementiranoSacuvaj { get { return false; } }
        
        public virtual bool ImplementiranNoviUnos { get { return false; } }

        public virtual void NoviUnos() { }

        public virtual void Osvezi() { }

        public virtual void Sacuvaj() {}

        protected bool IsBusy
        {
            get { return m_IsBusy; }
            set
            {
                m_IsBusy = value;
                Cursor = IsBusy ? Cursors.WaitCursor : Cursors.Default;
            }
        }

        public event EventHandler<SendMessageEventArgs> SendMessage;

        protected virtual void OnSendMessage(Message message)
        {
            var handler = SendMessage;
            if (handler != null)
            {
                handler(this, new SendMessageEventArgs(message));
            }
        }
    }
}