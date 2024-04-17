using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReservationMobileApp.Model;
using ReservationMobileApp.Services;
using ReservationMobileApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReservationMobileApp.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private string _UserName;
        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }

            get
            {
                return _UserName;
            }
        }

        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }

            get
            {
                return _UserCartItemsCount;
            }
        }

        private string _SearchText;
        public string SearchText
        {
            set
            {
                _SearchText = value;
                OnPropertyChanged();
            }

            get
            {
                return _SearchText;
            }
        }
        //define a property to maintain data of the categories
        public ObservableCollection<Category> Categories { get; set; }
        // define a collection of property to maintain the list of latest item
        public ObservableCollection<ProvideItem> LatestItems { get; set; }

        //define  the commands which  are required for the products view model
        public Command ViewCartCommand { get; set; }
        public Command LogoutCommand { get; set; }
        public Command ViewOrdersHistoryCommand { get; set; }
        public Command SearchViewCommand { get; set; }


        //set the default value within the construtor name 
        public ProductsViewModel()
        {
            var uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
                UserName = "Guest";
            else
                UserName = uname;
            //define the object 
            UserCartItemsCount = new CartItemService().GetUserCartCount();

            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<ProvideItem>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());
            ViewOrdersHistoryCommand = new Command(async () => await ViewOrderHistoryAsync());
            SearchViewCommand = new Command(async () => await SearchViewAsync());

            //invoke the method
            GetCategories();
            GetLatestItems();
        }

        private async Task SearchViewAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(
                new SearchResultsView(SearchText));
        }

        private async Task ViewOrderHistoryAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersHistoryView());
        }

        private async Task ViewCartAsync()
        {  //when ever userCartCommand is invoked, then have to navigate to the usercart contentpage  CartView in view folder
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutAsync()
        {//when user invoked logout command , navigate to logout page   LogoutView in View folder
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async void GetCategories()
        { //add new categories 
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }

        private async void GetLatestItems()
        {
            var data = await new ProvideItemService().GetLatestServicesItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }
    }
}
