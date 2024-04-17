using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using ReservationMobileApp.Model;
using Xamarin.Essentials;

namespace ReservationMobileApp.Services
{
    public class UserOrderHistoryService
    {
        FirebaseClient client;
        List<UserOrdersHistory> UserOrders;

        public UserOrderHistoryService()
        {
            client = new FirebaseClient("https://newapp2-df63e.firebaseio.com/");
            UserOrders = new List<UserOrdersHistory>();
        }

        //use to get the user history from the ordered firebase 
        public async Task<List<UserOrdersHistory>> GetOrderDetailsAsync()
        {
            var uname = Preferences.Get("Username", "Guest");

            var orders = (await client.Child("Orders")
                .OnceAsync<Order>())
                .Where( o => o.Object.Username.Equals(uname))
                .Select(o => new Order
                {
                    OrderId = o.Object.OrderId,
                    ReceiptId = o.Object.ReceiptId,
                    TotalCost = o.Object.TotalCost,
                }).ToList();

            foreach (var order in orders)
            {
                UserOrdersHistory history = new UserOrdersHistory();
                history.OrderId = order.OrderId;
                history.ReceiptId = order.ReceiptId;
                history.TotalCost = order.TotalCost;

                var orderDetails = (await client.Child("OrderDetails")
                .OnceAsync<OrderDetails>())
                .Where(o => o.Object.OrderId.Equals(order.OrderId))
                .Select(o => new OrderDetails
                {
                    OrderId = o.Object.OrderId,
                    OrderDetailId= o.Object.OrderDetailId,
                    ProductID = o.Object.ProductID,
                    ProductName = o.Object.ProductName,
                    Quantity = o.Object.Quantity,
                    Price = o.Object.Price,
                    SelectedDate=o.Object.SelectedDate,
                    SelectedTime=o.Object.SelectedTime
                }).ToList();

                history.AddRange(orderDetails);

                UserOrders.Add(history);
            }

            return UserOrders;
        }
    }
}
