using System;
using System.Collections.Generic;
using System.Linq;
using ReservationMobileApp.Model;
using Plugin.SharedTransitions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReservationMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingReservationView : ContentPage
    {
        public UpcomingReservationView()
        {
            InitializeComponent();
            RequestView.SelectionChanged += RequestView_ShowDetails;
        }
       private void RequestView_ShowDetails(object sender, SelectionChangedEventArgs e)
        {
            var selection = e.CurrentSelection; // currentselection will return a list of read only items

            //clicked , display
            String display = String.Empty;
            display = "Requestor Details";
            for (int a = 0; a < selection.Count; a++)
            {
                
                var selected = selection[a] as ReservationOrderDetails;
                display += $"\nUsername : {selected.Username} \nOrderId : {selected.OrderId} \nService Provider : {selected.ProductName} \nQuantity : {selected.Quantity}  " +
                    $"\nDeposit :  {selected.Price} \nTotal Deposit : {selected.TotalCost} \nSelected Time : {selected.SelectedTime} \nSelected Date : {selected.SelectedDate} \nStatus : {selected.Status}";
            }
            DisplayAlert("Requestor", display, "OK");
        }
       /* async void CV_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as ReservationOrderDetails;
            if (selectedProduct == null)
                return;
          //  await Navigation.PushModalAsync(new UpcomingReservationView());
            ((CollectionView)sender).SelectedItem = null;
        }*/
    }
}