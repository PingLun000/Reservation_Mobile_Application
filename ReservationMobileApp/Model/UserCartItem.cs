using System;
namespace ReservationMobileApp.Model
{
    public class UserCartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        public string SelectedDate { get; set; }

        public string SelectedTime { get; set; }
    }
}
