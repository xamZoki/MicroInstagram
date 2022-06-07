using MIcroInsta.Models;
using MIcroInsta.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIcroInsta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoDetails : ContentPage
    {
        PhotoDetailsPageViewModel viewModel;
        public PhotoDetails(PhotoType item)
        {
            InitializeComponent();
            BindingContext = viewModel = new PhotoDetailsPageViewModel(item);
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Image frame = (Image)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            PhotoType photo = new PhotoType();
            photo = tapGesture.CommandParameter as PhotoType;

            await Navigation.PushAsync(new ImagePage(photo));
        }
        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            int id =  (int)button.CommandParameter;

            await viewModel.DeleteItem(id.ToString());
            await Navigation.PopAsync();
            
            Device.BeginInvokeOnMainThread(async() => await Application.Current.MainPage.DisplayAlert("Item deleted", "", "OK"));
        }
    }
}