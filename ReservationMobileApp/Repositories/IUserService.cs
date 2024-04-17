using System;
using System.Threading.Tasks;

namespace ReservationMobileApp.Repositories
{
    public interface IUserService
    {   //same as Iservice provider
        Task<bool> IsUserExists(string uname);
        Task<bool> RegisterUser(string uname, string passwd);
        Task<bool> LoginUser(string uname, string passwd);
    }
}
