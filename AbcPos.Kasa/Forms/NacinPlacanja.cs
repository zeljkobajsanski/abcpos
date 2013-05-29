using System.Windows.Forms;
using AbcPos.Kasa.ViewModels;

namespace AbcPos.Kasa.Forms
{
    public partial class NacinPlacanja : DevExpress.XtraEditors.XtraForm
    {
        private readonly NacinPlacanjaViewModel fViewModel;

        public NacinPlacanja()
        {
            InitializeComponent();
            
            btnUplati.Click += (s, e) =>
            {
                fViewModel.Validiraj();
                Close();
            };
        }

        public NacinPlacanja(Core.Models.Racun racun) : this()
        {
            fViewModel = IoC.Singleton().Get<NacinPlacanjaViewModel>();
            fViewModel.Racun = racun;
            nacinPlacanjaViewModelBindingSource.DataSource = fViewModel;
            txtGotovina.SelectAll();
            txtGotovina.Focus();
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.F1:
                    fViewModel.UplatiGotovinom();
                    btnUplati.Focus();
                    break;
                case Keys.F2:
                    fViewModel.UplatiKarticom();
                    btnUplati.Focus();
                    break;
                case Keys.F3:
                    fViewModel.UplatiCekom();
                    btnUplati.Focus();
                    break;
            }
        }
    }
}