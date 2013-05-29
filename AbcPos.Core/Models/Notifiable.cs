using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbcPos.Core.Models
{
    [DataContract(IsReference = true)]
    public class Notifiable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}