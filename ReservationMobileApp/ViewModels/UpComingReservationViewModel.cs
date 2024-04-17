using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReservationMobileApp.Model;
using ReservationMobileApp.Services;
using ReservationMobileApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReservationMobileApp.ViewModels
{
    public class UpComingReservationViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }

            get
            {
                return _UserName;
            }
        }
        private string _SearchText;
        public string SearchText
        {
            set
            {
                _SearchText = value;
                OnPropertyChanged();
            }

            get
            {
                return _SearchText;
            }
        }
        public ObservableCollection<ReservationOrderDetails> UpComingReservationDetails { get; set; }

    
        public UpComingReservationViewModel(){
            var uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
                UserName = "Guest";
            else
                UserName = uname;

            UpComingReservationDetails = new ObservableCollection<ReservationOrderDetails>();

         
            GetUpComingReservationDetails();
        }

        //it calling the code behind and await till the data has been fully downloaded and into the list and pass it bass to this method 

        private async void GetUpComingReservationDetails()
        {
            var data = await new ConfirmedUpComingReservationService().GetConfirmedUpComingReservation();
            UpComingReservationDetails.Clear();
            foreach( var item in data)
            {
                UpComingReservationDetails.Add(item);
            }

        }
    }
}
