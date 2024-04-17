using System;
using System.Threading.Tasks;

namespace ReservationMobileApp.Repositories
{
    public interface IServiceProviderService
    {
        //it used to check and define true or false
       
            Task<bool> IsUserExistsSP(string uname);
            Task<bool> RegisterUserSP(string uname, string passwd);
            Task<bool> LoginUserSP(string uname, string passwd);
        }
    
}
