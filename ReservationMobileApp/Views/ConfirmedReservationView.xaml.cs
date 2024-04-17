using ReservationMobileApp.Pages;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace ReservationMobileApp.Views
{
  
    public partial class ConfirmReservationView : ContentPage
    {
        public ConfirmReservationView(string id)
        {
            InitializeComponent();
            LabelName.Text = "Welcome " + Preferences.Get("Username", "Guest") + ",";
            LabelOrderID.Text = id;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new TabbedReservationPages());
        }
    }
}