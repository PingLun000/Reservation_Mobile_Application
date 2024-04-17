using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ReservationMobileApp.Model;
using ReservationMobileApp.Pages;
using ReservationMobileApp.Views;
using Xamarin.Forms;

namespace ReservationMobileApp.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private ProvideItem _SelectedService;
        public ProvideItem SelectedService
        {
            set
            {
                _SelectedService = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedService;
            }
        }

        private int _TotalQuantity;
        public int TotalQuantity
        {
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


        private String _SelectedDate;
        public String SelectedDates
        {
            set
            {
                this._SelectedDate = value;
                
                OnPropertyChanged();
            }

            get
            {
                return _SelectedDate;
            }
        }

        private string _SelectedTime;
        public string SelectedTimes
        {
            set
            {
               
                    this._SelectedTime = value;
                    OnPropertyChanged();
                
            }

            get
            {
               
                return _SelectedTime;
            }
        }
        // new code
/*        public class time
        {
            public string Time { get; set; }
        }


        public List<time> TimeList { get; set; }
      
        private time _selectedTimeRange { get; set; }
        public time SelectedTimeRange
        {
            get { return _selectedTimeRange; }
            set
            {
                if (_selectedTimeRange != value)
                {
                    _selectedTimeRange = value;
                    MyTimeRange = "Selected time range " + _selectedTimeRange.Time;
                   
                }
            }
        }

        

        private string _myTimeRange;
        public string MyTimeRange
        {
            get { return _myTimeRange; }
            set
            {
                if (_myTimeRange != value)
                {
                    _myTimeRange = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<time> GetTimeList()
        {
            var timeRange = new List<time>()
            {
                new time(){Time="10:00 A.M."},
                new time(){Time="11:00 A.M."}, 
                new time(){Time="12:00 P.M."},
                new time(){Time="1:00 P.M."},
                new time(){Time="2:00 P.M."},
                new time(){Time="3:00 P.M."},
                new time(){Time="4:00 P.M."},
                new time(){Time="5:00 P.M."},
                new time(){Time="6:00 P.M."},
                new time(){Time="7:00 P.M."},
                new time(){Time="8:00 P.M."},
                new time(){Time="9:00 P.M."},
                new time(){Time="10:00 P.M."},


            };
            return timeRange;
        }
*/
        // new code end 
        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }

        public ProductDetailsViewModel(ProvideItem foodItem,DatePicker date ,TimePicker timeSelect)
        {
            SelectedService = foodItem;
            TotalQuantity = 0;
            //used to set the date into string 
            SelectedDates = date.ToString();
           // TimeList = GetTimeList().ToList();
            
            //used to set the timepicker into storable datatype  and pass it to thw selectedTime for futher info 
            SelectedTimes = timeSelect.Time.ToString();
            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await GotoHomeAsync());
           
            
        }

      
        private async Task GotoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new TabbedPages());
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
                // used to add the data that get from about and stored it into the cartItem Property and add to table 
                CartItem ci = new CartItem()
                {
                    ProductId = SelectedService.ProductID,
                    ProductName = SelectedService.Name,
                    Price = SelectedService.Price,
                    Quantity = TotalQuantity,
                    SelectedDate = SelectedDates,
                    SelectedTime = SelectedTimes
                };
                var item = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductId == SelectedService.ProductID);
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
