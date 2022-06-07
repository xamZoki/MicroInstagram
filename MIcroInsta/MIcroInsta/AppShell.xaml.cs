using MIcroInsta.ViewModels;
using MIcroInsta.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MIcroInsta
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddPhotoPage), typeof(AddPhotoPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
