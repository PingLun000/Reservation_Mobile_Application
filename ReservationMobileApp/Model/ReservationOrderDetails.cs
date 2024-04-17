using System;
namespace ReservationMobileApp.Model
{
     
        public class ReservationOrderDetails
        {
            public string OrderId { get; set; }
            public string Username { get; set; }
            public decimal TotalCost { get; set; }
            public string OrderDetailId { get; set; }
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            
            public string Status { get; set; }
        public string SelectedDate { get; set; }
        public string SelectedTime { get; set; }

    }
}
