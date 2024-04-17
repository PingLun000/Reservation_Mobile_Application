using System;
using System.Collections.Generic;
using ReservationMobileApp.Helpers;
using Xamarin.Forms;

namespace ReservationMobileApp.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        async void ButtonCategories_Clicked(System.Object sender, System.EventArgs e)
        {
            var data = new AddCategoryData();
            await data.AddCategoriesAsync();
        }

        async void ButtonProducts_Clicked(System.Object sender, System.EventArgs e)
        {
            var data = new AddServicesData();
            await data.AddServicesAsync();
        }

        void ButtonCart_Clicked(System.Object sender, System.EventArgs e)
        {
            var table = new CreateCartTable();
            if (table.CreateTable())
                DisplayAlert("Success", "Cart Table Created", "Ok");
            else
                DisplayAlert("Error", "Error while creating table", "Ok");
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
