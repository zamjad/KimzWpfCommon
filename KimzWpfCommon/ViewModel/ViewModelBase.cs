using KimzWpfCommon.Utils;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace KimzWpfCommon.ViewModel
{
    public abstract class ViewModelBase : DisopsableObject, INotifyPropertyChanged
    {
        public event EventHandler RequestClose;

        protected ViewModelBase()
        {
            this.ExiCommand = new RelayCommand<object, object>(this.Close);
        }

        public ICommand ExiCommand
        { get; set; }

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Close()
        {
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
