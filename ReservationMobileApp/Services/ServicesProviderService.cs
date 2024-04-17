
using System.Threading.Tasks;
using Firebase.Database;
using ReservationMobileApp.Model;
using System.Linq;
using Firebase.Database.Query;
using ReservationMobileApp.Repositories;
using Xamarin.Forms;
using ReservationMobileApp.Services;

[assembly: Dependency(typeof(ServicesProviderService))]
namespace ReservationMobileApp.Services
{
    public class ServicesProviderService : IServiceProviderService
    {
        //define the variable of firebase, since using the realtime database
        FirebaseClient client;

        //define constructor and create a instance for firebase client

        public ServicesProviderService()
        {
            client = new FirebaseClient("https://serviceprovideddata.firebaseio.com/");
        }

        //checking the firebase data if service provider wish to register, login 
        public async Task<bool> IsUserExistsSP(string uname)
        {
            var Provider_User = (await client.Child("Provider_Users")
                .OnceAsync<UserServiceProvider>()).Where(u => u.Object.UsernameSP == uname).FirstOrDefault();

            return (Provider_User != null);
        }

        public async Task<bool> RegisterUserSP(string uname, string passwd)
        {
            if (await IsUserExistsSP(uname) == false)
            {
                await client.Child("Provider_Users")
                    .PostAsync(new UserServiceProvider()
                    {
                        UsernameSP = uname,
                        PasswordSP = passwd
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUserSP(string uname, string passwd)
        {
            var Provider_User = (await client.Child("Provider_Users")
                .OnceAsync<UserServiceProvider>()).Where(u => u.Object.UsernameSP == uname)
                .Where(u => u.Object.PasswordSP == passwd).FirstOrDefault();

            return (Provider_User != null);
        }
    }
}
