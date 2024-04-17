using System;
using System.Collections.ObjectModel;
using ReservationMobileApp.Model;
using ReservationMobileApp.Services;

namespace ReservationMobileApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedCategory;
            }
        }
        //maintain a collection of services by category
        public ObservableCollection<ProvideItem> ServicessByCategory { get; set; }

        private int _TotalServicesItems;
        public int TotalServicesItems
        {
            set
            {
                _TotalServicesItems = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalServicesItems;
            }
        }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            ServicessByCategory = new ObservableCollection<ProvideItem>();
            GetServicesItems(category.CategoryID);
        }

        private async void GetServicesItems(int categoryID)
        {   //retrieve the service based on the the category Id
            var data = await new ProvideItemService().GetServicestemsByCategoryAsync(categoryID);
            ServicessByCategory.Clear();
            //add the service item to the collection

            foreach (var item in data)
            {
                ServicessByCategory.Add(item);
            }
            TotalServicesItems = ServicessByCategory.Count;
        }
    }
}
