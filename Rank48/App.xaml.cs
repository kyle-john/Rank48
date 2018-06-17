using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

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
