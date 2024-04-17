using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ReservationMobileApp.Model;
using ReservationMobileApp.ViewModels;
using ReservationMobileApp.Views;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReservationMobileApp.Services
{
    public class HandleReservationService
    {   
        // used to define when the reservation has been confrimed by the service provider, it will delete from the original database into confirmed reservation database
        FirebaseClient client;
        FirebaseClient romove;
        public string GetOrderId { get; private set; }
        public string GetProductName { get; private set; }
        public decimal GetPrice { get; private set; }
        public int GetQuantity { get; private set; }
        public object SelectedReservation { get; private set; }
        public int GetProductID { get; private set; }
        public decimal GetTotalcost { get; private set; }
        public string GetUsername { get; private set; }
        public string GetSelectedTime { get; private set; }
        public string GetSelectedDate { get; private set; }
        public string GetStatus { get; private set; }

        public HandleReservationService()
        {
            client = new FirebaseClient("https://confirmedreservation-86df2.firebaseio.com/");
            romove = new FirebaseClient("https://serviceprovideddata.firebaseio.com/");
            var cn = DependencyService.Get<ISQLite>().GetConnection();
         

        }

        public async Task ProcessData()
        {
            int count = 1;
            if (count == 1)
            {
                if (GetStatus == "Confirmed")
                    await ProcessConfirmedDataAsync();

                else
                    if(GetStatus== "Denied")
                        await ProcessDeniedDataAsync();
                

                
               
                await Application.Current.MainPage.Navigation.PushModalAsync(
                    new ConfirmReservationView(GetOrderId));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error To Accept Reservation", "OK");
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }

        }

        public async Task ProcessConfirmedDataAsync()
        {     

          ReservationOrderDetails confirm = new ReservationOrderDetails()
                {
                    OrderId = GetOrderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductID = GetProductID,
                    ProductName = GetProductName,
                    Price = GetPrice,
                    Quantity = GetQuantity,
                    Username = GetUsername,
                    TotalCost = GetTotalcost,
                    Status=GetStatus,
                    SelectedTime = GetSelectedTime,
                    SelectedDate = GetSelectedDate
          };
                await client.Child("ConfirmedReservation").PostAsync(confirm);

          await DeleteRequestor();
           
        }

        public async Task ProcessDeniedDataAsync()
        {

            ReservationOrderDetails denied = new ReservationOrderDetails()
            {
                OrderId = GetOrderId,
                OrderDetailId = Guid.NewGuid().ToString(),
                ProductID = GetProductID,
                ProductName = GetProductName,
                Price = GetPrice,
                Quantity = GetQuantity,
                Username = GetUsername,
                TotalCost = GetTotalcost,
                Status = GetStatus,
                SelectedTime = GetSelectedTime,
                SelectedDate =GetSelectedDate
            };
            await client.Child("DeniedReservation").PostAsync(denied);

            await DeleteRequestor();

        }

        public async Task DeleteRequestor()
        {
            var toDeletePerson = (await romove
              .Child("ReservationOrderDetails")
              .OnceAsync<ReservationOrderDetails>()).Where(a => a.Object.OrderId == GetOrderId).FirstOrDefault();
            await romove.Child("ReservationOrderDetails").Child(toDeletePerson.Key).DeleteAsync();

        }
        public async Task ReservationRequestAsync(ReservationOrderDetails selectedReservation,int dicision)
        {
            GetOrderId = selectedReservation.OrderId;
            GetProductName = selectedReservation.ProductName;
            GetQuantity = selectedReservation.Quantity;
            GetPrice = selectedReservation.Price;
            GetProductID = selectedReservation.ProductID;
            GetTotalcost = selectedReservation.TotalCost;
            GetUsername = selectedReservation.Username;
            GetSelectedTime = selectedReservation.SelectedTime;
            GetSelectedDate = selectedReservation.SelectedDate;
            if (dicision == 1)
                GetStatus = "Confirmed";
            else
                GetStatus = "Denied";

            await ProcessData();

        }


    }
}
