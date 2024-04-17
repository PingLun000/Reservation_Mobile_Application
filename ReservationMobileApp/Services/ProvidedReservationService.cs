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
    public class ProvidedReservationService
    {
        FirebaseClient client;
        public ProvidedReservationService()
        {
            client = new FirebaseClient("https://serviceprovideddata.firebaseio.com/");
        }

        //get the data from firebase
        public async Task<List<OrderDetails>> GetOrderDetails()
        {
            return (await client
              .Child("OrderDetails")
              .OnceAsync<OrderDetails>()).Select(item => new OrderDetails
              {
                  OrderId = item.Object.OrderId,
                  OrderDetailId = Guid.NewGuid().ToString(),
                  ProductID = item.Object.ProductID,
                  ProductName = item.Object.ProductName,
                  Price = item.Object.Price,
                  Quantity = item.Object.Quantity,
                  SelectedTime = item.Object.SelectedTime,
                  SelectedDate = item.Object.SelectedDate
              }).ToList();
            
        }

       //public async void GetFullOrderDetails()
       public async Task<List<ReservationOrderDetails>> GetFullOrderDetails()
        {

            var orderdetails = ((await client
              .Child("ReservationOrderDetails")
              .OnceAsync<ReservationOrderDetails>()).Select(item => new ReservationOrderDetails
              {
                  OrderId = item.Object.OrderId,
                  OrderDetailId = Guid.NewGuid().ToString(),
                  ProductID = item.Object.ProductID,
                  ProductName = item.Object.ProductName,
                  Price = item.Object.Price,
                  Quantity = item.Object.Quantity,
                  Username = item.Object.Username,
                  TotalCost = item.Object.TotalCost,
                  SelectedTime = item.Object.SelectedTime,
                  SelectedDate = item.Object.SelectedDate
                  //Username = (client.Child("Orders").OnceAsync<Order>()).Select(Item => item.Object.Username,
                  //Username = (client.Child("Orders").OnceAsync<Order>()).Select(item.Object.Username => new ReservationOrderDetails.Username),

              }).ToList());

         
            return orderdetails;

        }

        // add the latest order into it
        public async Task<ObservableCollection<OrderDetails>> GetLatestOrderDetails()
        {
            var latestDetails = new ObservableCollection<OrderDetails>();
            var items = (await GetOrderDetails()).OrderByDescending(f => f.ProductID).Take(3);
            foreach (var item in items)
            {
                latestDetails.Add(item);
            }
            return latestDetails;
        }

        public async  Task<List<Order>> GetOrders()
        {
           return (await client
              .Child("Orders")
              .OnceAsync<Order>()).Select(item => new Order
              {
                  OrderId = item.Object.OrderId,
                  Username = item.Object.Username,
                  TotalCost = item.Object.TotalCost,
              }).ToList();

        }
    }
}
