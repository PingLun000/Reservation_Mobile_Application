using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReservationMobileApp.ViewModels
{// create a baseviewmodel with the implementation of inotify property change 
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
