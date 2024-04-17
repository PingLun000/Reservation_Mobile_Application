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
    public class ServiceProviderReservationPageViewModel : BaseViewModel
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

        //Used to get the lateset reservation details but it is using difference model for this project i used the LatestReservationRequestorDetails to 
        //show the latest resquest by requestor

        public ObservableCollection<OrderDetails> LatestReservation { get; set; }
            public ObservableCollection<Order> LatestReservationRequestor { get; set; }
            public ObservableCollection<ReservationOrderDetails> LatestReservationRequestorDetails { get; set; }

        public Command LogoutCommand { get; set; }
        public Command SearchViewCommand { get; set; }
    public ServiceProviderReservationPageViewModel()
            {
                    // To save a value for a given key in preferences:
                var uname = Preferences.Get("Username", String.Empty);
                if (String.IsNullOrEmpty(uname))
                    UserName = "Guest";
                else
                    UserName = uname;

                LatestReservation = new ObservableCollection<OrderDetails>();
                LatestReservationRequestor = new ObservableCollection<Order>();
                LatestReservationRequestorDetails = new ObservableCollection<ReservationOrderDetails>();

    
            //it calling the code behind and await till the data has been fully downloaded and into the list and pass it bass to this method 

                GetLatestReservationRequestorDetails();
                GetLatestReservation();
                GetLatestReservationRequestor();
            }

      
 
        private async void GetLatestReservationRequestorDetails()
            {
                var data = await new ProvidedReservationService().GetFullOrderDetails();
                LatestReservationRequestorDetails.Clear();
                foreach (var item in data)
                {
                    LatestReservationRequestorDetails.Add(item);
                }
            }


            private async void GetLatestReservation()
            {
                var data = await new ProvidedReservationService().GetOrderDetails();
                LatestReservation.Clear();
                foreach (var item in data)
                {
                    LatestReservation.Add(item);
                }
            }
            private async void GetLatestReservationRequestor()
            {
                var data = await new ProvidedReservationService().GetOrders();
                LatestReservationRequestor.Clear();
                foreach (var item in data)
                {
                    LatestReservationRequestor.Add(item);
                }
            }

        }
    
}