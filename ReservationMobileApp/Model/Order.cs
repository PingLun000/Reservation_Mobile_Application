using System;
namespace ReservationMobileApp.Model
{
    public class Order
    {   
        //define Property
        public string OrderId { get; set; }
        public string Username { get; set; }
        public decimal TotalCost { get; set; }
        public string ReceiptId { get; set; }
        public string SelectedDate { get; set; }
        public string SelectedTime { get; set; }
    }
}
