using MIcroInsta.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIcroInsta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosThumbnailsLIst : ContentPage
    {
        public PhotosThumbnailsLIst()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            //await vm.GetAllPhotos();
            await vm.GetAllPhotosType();
        }
        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            PhotoType photo = new PhotoType();
            photo = tapGesture.CommandParameter as PhotoType;

            await Navigation.PushAsync(new PhotoDetails(photo));
        }
    }
}