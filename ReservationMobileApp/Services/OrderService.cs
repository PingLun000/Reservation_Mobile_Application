using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ReservationMobileApp.Model;
using ReservationMobileApp.Views;
 
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReservationMobileApp.Services
{
    public class OrderService
    {
        FirebaseClient client;

        public string OrderId { get; set; }

        public decimal TotalCost { get; set; }

        public List<CartItem> Data { get; set; }

        public OrderService()
        {
            client = new FirebaseClient("https://serviceprovideddata.firebaseio.com/");

            OrderId = Guid.NewGuid().ToString();
            //get the cart item from the table 
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            //add the table into data 
            Data = cn.Table<CartItem>().ToList();
            TotalCost = Data.Sum(d => d.Quantity * d.Price);
        }

        public async Task ProcessReservation()
        {
            int count = 1;
            if (count == 1)
            {
                await ProcessOrderAsync();
                RemoveItemsFromCart();
                await Application.Current.MainPage.Navigation.PushModalAsync(
                    new OrdersView(OrderId));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error While Placing the Reservation", "OK");
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }

        }

        public async Task ProcessOrderAsync()
        {
            //get the username as preference from the place we set it 
            var uname = Preferences.Get("Username", "Guest");

            //posst it up to the firebase
            foreach (var item in Data)
            {
                OrderDetails od = new OrderDetails()
                {
                    OrderId = OrderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductID = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    SelectedDate = item.SelectedDate,
                    SelectedTime=item.SelectedTime
                 

                };
                await client.Child("OrderDetails").PostAsync(od);
            }

            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderId = OrderId,
                    Username = uname,
                    TotalCost = TotalCost,


                });

            foreach (var item in Data)
            {
                ReservationOrderDetails rod = new ReservationOrderDetails()
                {
                    OrderId = OrderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductID = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Username = uname,
                    TotalCost = TotalCost,
                    SelectedDate=item.SelectedDate,
                    SelectedTime = item.SelectedTime

                };
                await client.Child("ReservationOrderDetails").PostAsync(rod);
            }
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
        }

        public async Task PlaceOrderAsync()
        {
            await ProcessReservation();
        }
    }
}
