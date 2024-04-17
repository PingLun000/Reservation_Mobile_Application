using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReservationMobileApp.Model;
using ReservationMobileApp.Services;
using ReservationMobileApp.Views;
using Xamarin.Forms;

namespace ReservationMobileApp.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<UserCartItem> CartItems { get; set; }

        //use to check and set the property if the value is difference with the e.newValue then it will change
        private decimal _TotalCost;
        public decimal TotalCost
        {
            set
            {
                _TotalCost = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalCost;
            }
        }

        //calling the instance command 
        public Command PlaceOrdersCommand { get; set; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<UserCartItem>();
            //load the  cart items and wait the placeOrderAsync to get back the value 
            LoadItems();
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
        }

        private async Task PlaceOrdersAsync()
        {
            var orderService = new OrderService();
            await orderService.PlaceOrderAsync();
        }

        private void LoadItems()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<CartItem>().ToList();
            CartItems.Clear();
            foreach (var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Cost = item.Price * item.Quantity,
                    SelectedDate=item.SelectedDate,
                    SelectedTime=item.SelectedTime
                });
                TotalCost += (item.Price * item.Quantity);
            }
        }
    }
}
