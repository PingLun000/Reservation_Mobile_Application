using System;
using ReservationMobileApp.Pages;
using ReservationMobileApp.Repositories;
using ReservationMobileApp.Services;
using ReservationMobileApp.Views;
using Plugin.SharedTransitions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReservationMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] {
                "AppTheme_Experimental",
                "MediaElement_Experimental"
                });

            InitializeComponent();

            DependencyService.Register<IZomato, Zomato>();
            //MainPage = new HomePage();


             
             MainPage = new NavigationPage(new SettingsPage());
            
           
           /*
             string uname = Preferences.Get("Username", String.Empty);
              if (String.IsNullOrEmpty(uname))
              {
                  MainPage = new TabbedLoginPage();
              }
              else
              {
                  MainPage = new NavigationPage(new TabbedPages());
              } */
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
    }
}
