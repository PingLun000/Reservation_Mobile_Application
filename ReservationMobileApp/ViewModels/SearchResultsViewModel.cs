using System;
using System.Collections.ObjectModel;
using ReservationMobileApp.Model;
using ReservationMobileApp.Services;

namespace ReservationMobileApp.ViewModels
{
    public class SearchResultsViewModel : BaseViewModel
    {
        // use to search the total quantity of list and out put 
        public ObservableCollection<ProvideItem> SearchByQuery { get; set; }

        private int _TotalServices;
        public int TotalServices
        {
            set
            {
                _TotalServices = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalServices;
            }
        }

        public SearchResultsViewModel(string searchText)
        {
            SearchByQuery = new ObservableCollection<ProvideItem>();
            GetServiceItemsByQuery(searchText);
        }

        // the count will show in the serach page determine The quantity of the searching text were matched
        private async void GetServiceItemsByQuery(string searchText)
        {
            var data = await new ProvideItemService().GetServicesItemsByQueryAsync(searchText);
            SearchByQuery.Clear();
            foreach (var item in data)
            {
                SearchByQuery.Add(item);
            }
            TotalServices = SearchByQuery.Count;
        }
    }
}
