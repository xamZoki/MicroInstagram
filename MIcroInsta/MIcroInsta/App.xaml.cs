using MIcroInsta.Services;
using MIcroInsta.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIcroInsta
{
    public partial class App : Application
    {
        public static int initalCall = 0;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<PhotosListDataStore>();
            MainPage = new AppShell();
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
