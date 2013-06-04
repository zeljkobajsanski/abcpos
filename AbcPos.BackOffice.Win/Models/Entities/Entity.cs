using System.ComponentModel;
using AbcPos.BackOffice.Win.Annotations;
using AbcPos.BackOffice.Win.Models.Validation;
using DevExpress.XtraEditors.DXErrorProvider;

namespace AbcPos.BackOffice.Win.Models.Entities
{
    public class Entity : INotifyPropertyChanged, IDXDataErrorInfo
    {
        [Browsable(false)]
        public IValidator Validator { get; set; }

        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (Validator != null)
            {
                info.ErrorText = Validator.GetFirstError(propertyName, this);
            }
        }

        public void GetError(ErrorInfo info)
        {
            if (Validator != null)
            {
                info.ErrorText = Validator.IsValid(this) ? null : "Ispravite podatke";
            }
        }
    }
}