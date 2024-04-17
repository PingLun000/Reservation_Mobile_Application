using System;
using System.Threading.Tasks;
using Firebase.Database;
using ReservationMobileApp.Model;
using System.Linq;
using Firebase.Database.Query;
using ReservationMobileApp.Repositories;
using Xamarin.Forms;
using ReservationMobileApp.Services;

[assembly:Dependency(typeof(UserService))]
namespace ReservationMobileApp.Services
{
    public class UserService : IUserService
    {
        FirebaseClient client;

        public UserService()
        {// this is the endpoint URL of database offirebase
            client = new FirebaseClient("https://newapp2-df63e.firebaseio.com/");
        }

        //to define the user existing or not 
        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            return (user != null);
        }

        //port for registering user
        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        Username = uname,
                        Password = passwd
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        //a method to support login 
        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();

            return (user != null);
        }
    }
}
