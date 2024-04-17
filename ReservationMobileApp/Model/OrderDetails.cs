using System;
namespace ReservationMobileApp.Model
{
    public class OrderDetails
    {   
        //define property 
        public string OrderDetailId { get; set; }
        public string OrderId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SelectedDate { get; set; }
        public string SelectedTime { get; set; }
    }
}
