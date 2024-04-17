using System;
using System.Runtime.InteropServices.ComTypes;
using ReservationMobileApp.Model;
using Xamarin.Forms;
using SQLite;

namespace ReservationMobileApp.Helpers
{
    public class CreateCartTable
    {//create the database and the table within the SQLite 
        public bool CreateTable()
        {
            try
            {
                var cn = DependencyService.Get<ISQLite>().GetConnection();
                cn.CreateTable<CartItem>();
                //cn.CreateTable<ReservationCartItem>();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
