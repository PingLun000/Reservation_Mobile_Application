using System;
using System.Collections.Generic;
using ReservationMobileApp.Model;
using ReservationMobileApp.ViewModels;
using Xamarin.Forms;

namespace ReservationMobileApp.Views
{
    public partial class ReservationDetailsView : ContentPage
    {
        ReservationDetailsViewModel RDV;
        public ReservationDetailsView(ReservationOrderDetails reservation)
        {
            InitializeComponent();
            RDV = new ReservationDetailsViewModel(reservation);
            this.BindingContext = RDV;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}