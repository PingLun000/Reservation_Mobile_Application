using System;
using System.Collections.Generic;

namespace ReservationMobileApp.Model
{
    public class Cart
    {  // use to maintain the services selected by the user within user's cart
        public string UserName { get; set; }
        public int CartId { get; set; }

        //use to maintain the details of the various services selected by user
        public List<CartItem> CartItems { get; set; }
    }
}
