using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ReservationMobileApp.Model;
using ReservationMobileApp.Services;

namespace ReservationMobileApp.Services
{
    public class Zomato : IZomato
    {
        public async Task<Cates> GetCategorys()
        {
            //use to call API
            HttpClient client = new HttpClient();
            //pass header parameter
            client.DefaultRequestHeaders.Add("user-key", "db549dbc9e9a1fb45446f2a323911ffd");

            //passing url
            var respon = await client.GetAsync("https://developers.zomato.com/api/v2.1/categories");

             if (respon.IsSuccessStatusCode)
            {   // if true, read the content as string 
                var content = await respon.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Cates>(content);

                return result;
            }

            return null;
        }

        public async Task<GeoCodeRestaurant> GetGeoCodeRestaurant(double lat, double lon)
        {
            //use to call API
            HttpClient client = new HttpClient();
            //pass header parameter
            client.DefaultRequestHeaders.Add("user-key", "db549dbc9e9a1fb45446f2a323911ffd");

            //passing url
            var respon = await client.GetAsync($"https://developers.zomato.com/api/v2.1/geocode?lat={lat}&lon={lon}");

            if (respon.IsSuccessStatusCode)
            {   // if true, read the content as string 
                var content = await respon.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GeoCodeRestaurant>(content);

                return result;
            }

            return null; 
        }

    }
}
