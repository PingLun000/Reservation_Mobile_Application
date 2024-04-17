using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReservationMobileApp.Model;

namespace ReservationMobileApp.Services
{
    public interface IZomato
    {
        Task<Cates> GetCategorys();

        //used to get the lattude and longtitude from the user gps 
        Task<GeoCodeRestaurant> GetGeoCodeRestaurant(double lat, double lon);
    }
}
