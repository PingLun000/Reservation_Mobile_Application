using System;
namespace ReservationMobileApp.Model
{

    //define the property that are required for  the category 

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPoster { get; set; }
        public string ImageUrl { get; set; }
    }
}
