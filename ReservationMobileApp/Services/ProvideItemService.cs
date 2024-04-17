using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using ReservationMobileApp.Model;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace ReservationMobileApp.Services
{
    //a method which will return as the latest Service   
    public class ProvideItemService
    {
        FirebaseClient client;
        public ProvideItemService()
        {
            client = new FirebaseClient("https://newapp2-df63e.firebaseio.com/");
        }

        //get the services uploaded and used it as in the home page 
        public async Task<List<ProvideItem>> GeServicesItemsAsync()
        {
            var products = (await client.Child("ProvideItems").OnceAsync<ProvideItem>()).Select(f => new ProvideItem
                 {
                     CategoryID = f.Object.CategoryID,
                     Description = f.Object.Description,
                     HomeSelected = f.Object.HomeSelected,
                     ImageUrl = f.Object.ImageUrl,
                     Name = f.Object.Name,
                     Price=f.Object.Price,
                     ProductID = f.Object.ProductID,
                     Rating = f.Object.Rating,
                     RatingDetail = f.Object.RatingDetail
                 }).ToList();       //this will return the entire list of the service 
            return products;
        }

        //define a method to return a list of provided service based on the category
        public async Task<ObservableCollection<ProvideItem>> GetServicestemsByCategoryAsync(int categoryID)
        {
            var ServicestemsByCategory = new ObservableCollection<ProvideItem>();
            var items = (await GeServicesItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                ServicestemsByCategory.Add(item);
            }
            return ServicestemsByCategory;
        }
        //define a method that which actually required for our products view model
        public async Task<ObservableCollection<ProvideItem>> GetLatestServicesItemsAsync()
        { //define an instance to maintain the collection of latest provided service
            var latestServicesItems = new ObservableCollection<ProvideItem>();
            var items = (await GeServicesItemsAsync()).OrderByDescending(f => f.ProductID).Take(10);
            foreach (var item in items)
            {
                latestServicesItems.Add(item);
            }
            return latestServicesItems;
        }

        //used by search bar on the home page 
        public async Task<ObservableCollection<ProvideItem>> GetServicesItemsByQueryAsync(string searchText)
        {
            var ServicesItemsByQuery = new ObservableCollection<ProvideItem>();
            var items = (await GeServicesItemsAsync()).Where(p => p.Name.Contains(searchText)).ToList();
            foreach (var item in items)
            {
                ServicesItemsByQuery.Add(item);
            }
            return ServicesItemsByQuery;
        }
    }
}
