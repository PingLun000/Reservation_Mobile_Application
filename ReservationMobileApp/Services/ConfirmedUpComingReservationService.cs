using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using ReservationMobileApp.Model;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace ReservationMobileApp.Services
{
    public class ConfirmedUpComingReservationService
    {
        FirebaseClient client;
        public ConfirmedUpComingReservationService()
        {
            client = new FirebaseClient("https://confirmedreservation-86df2.firebaseio.com/");
        }

        //used to get the confirmed reservation from  firebase and show it as at both side
        public async Task<List<ReservationOrderDetails>> GetConfirmedUpComingReservation()
        {

            var ReservationDetails = ((await client
              .Child("ConfirmedReservation")
              .OnceAsync<ReservationOrderDetails>()).Select(item => new ReservationOrderDetails
              {
                  OrderId = item.Object.OrderId,
                  OrderDetailId = Guid.NewGuid().ToString(),
                  ProductID = item.Object.ProductID,
                  ProductName = item.Object.ProductName,
                  Price = item.Object.Price,
                  Quantity = item.Object.Quantity,
                  Username = item.Object.Username,
                  TotalCost = item.Object.TotalCost,
                  Status=item.Object.Status,
                  SelectedTime=item.Object.SelectedTime,
                  SelectedDate=item.Object.SelectedDate
                 
              }).ToList());

            return ReservationDetails;

        }





    }
   
}
