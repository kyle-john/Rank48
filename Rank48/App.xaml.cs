using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Rank48
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new Xamarin.Forms.NavigationPage(new MainPage())
            {
                BarTextColor = Color.White
            };

            var ios = page.On<iOS>();
            ios.SetUseSafeArea(true);
            ios.SetPrefersLargeTitles(true);
            ios.SetLargeTitleDisplay(LargeTitleDisplayMode.Always);

            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=7d4507fa-7214-4dcf-8513-59cf2820909e;" 
                            + "ios=51b747aa-ec3e-4877-9401-7186a6b2cfff", 
                            typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
