using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ReservationMobileApp.Services;
using ReservationMobileApp.Model;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace ReservationMobileApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {   

        IZomato _rest = DependencyService.Get<IZomato>();
        public event PropertyChangedEventHandler PropertyChanged;


        private GeoCodeRestaurant geoCodeRestaurant;
        public GeoCodeRestaurant GeoCodeRestaurant
        {
            get { return geoCodeRestaurant; }
            set
            {
                geoCodeRestaurant = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GeoCodeRestaurant"));
            }
        }

        private Cates categorys;
        public Cates Categorys
        {
            get { return categorys; }
            set
            { categorys = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categorys"));
            }
        }


        public Command refreshCmd { get; set; }


        private bool isRefreshing;
            public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }


        public HomeViewModel()
        {
            IsRefreshing = new bool();
            refreshCmd = new Command(async sd => await refresh());
            refresh();
        }


        private async Task refresh()
        {
            await getResult();
            await Restaurant();
        }

        private async Task getResult()
        {
            var result = await _rest.GetCategorys();

            if (result != null)
            {
                Categorys = result;
            }
        }


        private async Task Restaurant()
        {
            var permission = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            var location = await Geolocation.GetLocationAsync();
            var result = await _rest.GetGeoCodeRestaurant(location.Latitude, location.Longitude);

            if (result != null)
            {
                GeoCodeRestaurant = result;
            }
        }
    }
}
