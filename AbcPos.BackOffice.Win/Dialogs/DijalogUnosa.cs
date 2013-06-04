namespace AbcPos.BackOffice.Win.Dialogs
{
    public partial class DijalogUnosa : DevExpress.XtraEditors.XtraForm
    {
        public DijalogUnosa()
        {
            InitializeComponent();
            btnSacuvaj.Click += (s, e) => Sacuvaj();
        }

        protected virtual void Sacuvaj()
        {
            Close();
        }
    }
}