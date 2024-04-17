using System;
using SQLite;

namespace ReservationMobileApp.Model
{// act like schema for creating database table 
    [Table("CartItem")]
    public class CartItem
    {
        [AutoIncrement, PrimaryKey]
        //to set this column to be autoincrement and set as primary key
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string SelectedDate { get; set; }
        public string SelectedTime { get; set; }

    }
}
