using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIcroInsta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPhotoPage : ContentPage
    {
        public AddPhotoPage()
        {
            InitializeComponent();
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                Plugin.Media.Abstractions.MediaFile _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                newItem.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (newItem.Source!=null)
            {
                await vm.AddPhoto(newItem, vm.Text);
                await Shell.Current.GoToAsync("..");
                await Application.Current.MainPage.DisplayAlert("New image is added on the bottom of list", "", "OK");
            }
        }
    }
}