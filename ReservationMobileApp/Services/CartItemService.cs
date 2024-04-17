using System;
using ReservationMobileApp.Model;
using Xamarin.Forms;


namespace ReservationMobileApp.Services
{

    //define a method that have a method which handle user cart services and return the number of services the user selected
    public class CartItemService
    {
        public int GetUserCartCount()
        {       
            //using(SQLite.SQLiteConnection conn=new SQLite.SQLiteConnection())
            var cn = DependencyService.Get<ISQLite>().GetConnection();
             //cn.CreateTable<CartItem>();
            var count = cn.Table<CartItem>().Count();
            cn.Close();
            return count;
        }

        public void RemoveItemsFromCart()
        {   //get the connection to the tabble and delete all the services in the cart once the user complete send the reservation or logout
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.DeleteAll<CartItem>();
            cn.Commit();
            cn.Close();
        }
    }
}
