using System;
using System.Threading.Tasks;
using ReservationMobileApp.Pages;
using ReservationMobileApp.Repositories;
using ReservationMobileApp.Services;
using ReservationMobileApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReservationMobileApp.ViewModels
{
    public class LoginServiceProviderViewModel : BaseViewModel
    {
        private string _ServiceProviderName;
        public string ServiceProviderName
        {
            set
            {
                this._ServiceProviderName = value;
                OnPropertyChanged();
            }
            get
            {
                return this._ServiceProviderName;
            }
        }

        private string _ServiceProviderPassword;
        public string ServiceProviderPassword
        {
            set
            {
                this._ServiceProviderPassword = value;
                OnPropertyChanged();
            }
            get
            {
                return this._ServiceProviderPassword;
            }
        }


        private bool _IsBusy1;
        public bool IsBusy1
        {
            set
            {
                this._IsBusy1 = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy1;
            }
        }

        private bool _ResultSP;
        public bool ResultSP
        {
            set
            {
                this._ResultSP = value;
                OnPropertyChanged();
            }
            get
            {
                return this._ResultSP;
            }
        }

        private bool _Disable1;
        public bool Disable1
        {
            set
            {
                _Disable1 = value;
                OnPropertyChanged();
            }

            get
            {
                return _Disable1;
            }
        }

        public Command LoginCommandSP { get; set; }
        public Command RegisterCommandSP { get; set; }

        public LoginServiceProviderViewModel()
        {
            Disable1 = false;

            LoginCommandSP = new Command(async () => await LoginCommandAsyncSP());
            RegisterCommandSP = new Command(async () => await RegisterCommandAsyncSP());
        }

        private async Task RegisterCommandAsyncSP()
        {
            if (IsBusy1)
                return;
            try
            {
                IsBusy1 = true;
                //var userService = new UserService();
                var userServiceSP = DependencyService.Get<IServiceProviderService>();
                //registed command calling the method that used to difine the register Use Username, if the RegisterUserSP return false it is the credentials is exist else nope 
                ResultSP = await userServiceSP.RegisterUserSP(ServiceProviderName, ServiceProviderPassword);
                if (ResultSP)
                    await Application.Current.MainPage.DisplayAlert("Success", "Service Provider Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error",
                        "Service Provider already exists with this credentials", "OK");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy1 = false;
            }
        }

        private async Task LoginCommandAsyncSP()
        {
            if (IsBusy1)
                return;
            try
            {
                IsBusy1 = true;
                //var userService = new UserService();
                var userServiceSP = DependencyService.Get<IServiceProviderService>();
                ResultSP = await userServiceSP.LoginUserSP(ServiceProviderName, ServiceProviderPassword);
                if (ResultSP)
                {
                    Preferences.Set("ServiceProviderName", ServiceProviderName);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new TabbedReservationPages());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Service provider's Username or Password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy1 = false;
            }
        }

    }
}
