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
    public partial class ServiceProviderReservationPage : ContentPage
    {
        public ServiceProviderReservationPage()
        {
            InitializeComponent();
           //the code below is used to show the pop up 
            //RequestView.SelectionChanged += RequestView_ShowDetails;
        }

       // the code below is used to show the pop up 
        /* private void RequestView_ShowDetails(object sender, SelectionChangedEventArgs e)
          {
              var selection = e.CurrentSelection; // currentselection will return a list of read only items

              //clicked , display
              String display = String.Empty;
              display = "Requestor\n ";
              for(int a = 0; a < selection.Count; a++)
              {
                  var selected = selection[a] as Order;
                  display += $"{selected.Username}({selected.TotalCost})";
              }
              DisplayAlert("Requestor", display, "OK", "cancel");
         }*/

      

        async void CV_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as ReservationOrderDetails;
            if (selectedProduct == null)
                return;
            await Navigation.PushModalAsync(new ReservationDetailsView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}