using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace TicTacToeMVVM
{
    class BindingBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if(BindingBase.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        public bool SetProperty<T> (ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if(BindingBase.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            onChanged?.Invoke();
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {

            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(PropertyChangedEventArgs propertyChangedEventArgs)
        {
            PropertyChanged?.Invoke(this, propertyChangedEventArgs); 
        }
    }
}
