using System;
using System.Linq;
using System.Threading.Tasks;
using ReservationMobileApp.Model;
using ReservationMobileApp.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using ReservationMobileApp.Services;
using ReservationMobileApp.Pages;

namespace ReservationMobileApp.ViewModels
{
    public class ReservationDetailsViewModel : BaseViewModel
    {
        private ReservationOrderDetails _SelectedReservation;
        public ReservationOrderDetails SelectedReservation
        {
            set
            {
                _SelectedReservation = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedReservation;
            }
        }

        private int _TotalQuantity;
        public int TotalQuantity
        {       // check the totalQuantity 
            set
            {
                this._TotalQuantity = value;
                if (this._TotalQuantity < 0)
                    this._TotalQuantity = 0;
                if (this._TotalQuantity > 10)
                    this._TotalQuantity -= 1;
                OnPropertyChanged();
            }

            get
            {
                return _TotalQuantity;
            }
        }

        //instant command call by clikcking the button in the view page
        public Command ConfirmReservationCommand { get; set; }

        public Command DeniedReservationCommand { get; set; }
        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }

        public ReservationDetailsViewModel(ReservationOrderDetails reservation)
        {
            SelectedReservation = reservation;
            TotalQuantity = 0;

            //used await to wait those value uploaded and back 
            ConfirmReservationCommand = new Command(async () => await ConfirmReservationOrderAsync());
            DeniedReservationCommand = new Command(async () => await DeniedReservationOrderAsync());
            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await GotoHomeAsync());
        }

        //show on the reservationDetailViewModel it is either user wish to select the denied or confirm button 
        public async Task DeniedReservationOrderAsync()
        {
            int denied = 0;
            var deniedService = new HandleReservationService();
            await deniedService.ReservationRequestAsync(SelectedReservation, denied);
        }
        private async Task ConfirmReservationOrderAsync()
        {
            int confirm = 1;
            var ConfirmedService = new HandleReservationService();
            //used to pass the data to confirmedReservationService
            await ConfirmedService.ReservationRequestAsync(SelectedReservation,confirm);
        }
        private async Task GotoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new TabbedReservationPages());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private void AddToCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem ci = new CartItem()
                {
                    ProductId = SelectedReservation.ProductID,
                    ProductName = SelectedReservation.ProductName,
                    Price = SelectedReservation.Price,
                    Quantity = TotalQuantity
                };
                var item = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductId == SelectedReservation.ProductID);
                if (item == null)
                    cn.Insert(ci);
                else
                {
                    item.Quantity += TotalQuantity;
                    cn.Update(item);
                }
                cn.Commit();
                cn.Close();
                Application.Current.MainPage.DisplayAlert("Cart", "Selected Item Added to Cart",
                    "OK");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                cn.Close();
            }
        }

        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
    }
}
