using System;
using System.Collections.Generic;
using ReservationMobileApp.Model;
using ReservationMobileApp.ViewModels;
using Xamarin.Forms;


namespace ReservationMobileApp.Views
{
    public partial class ProductDetailsView : ContentPage
    {
        ProductDetailsViewModel pvm;
      

        public ProductDetailsView(ProvideItem foodItem)
        {
            InitializeComponent();
            //string time = (string)time_Selected?.SelectedItem;
            // string time = time_Selected?.Time.ToString();

            /* pvm = new ProductDetailsViewModel(foodItem, date_Selected );

             this.BindingContext = pvm;*/
            
             string time = time_Selected.Time.ToString();
            
            pvm = new ProductDetailsViewModel(foodItem, date_Selected, time_Selected);
            this.BindingContext = pvm;
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

       
    }
}
