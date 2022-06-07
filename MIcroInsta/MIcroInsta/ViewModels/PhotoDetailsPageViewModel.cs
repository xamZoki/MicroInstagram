using MIcroInsta.Models;
using MIcroInsta.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MIcroInsta.ViewModels
{
    public class PhotoDetailsPageViewModel : BaseViewModel
    {
        public IDataPhotosType<PhotoType> DataStorePhotosType => DependencyService.Get<IDataPhotosType<PhotoType>>();
        public ICommand SaveCommand => new Xamarin.Forms.Command(async () => 
        { 
            
            await Shell.Current.GoToAsync("..");
            await Application.Current.MainPage.DisplayAlert("", "Changes Saved", "OK");
        });
        public PhotoType SelectedPhoto { get; set; }
        public PhotoDetailsPageViewModel(PhotoType item)
        {
            SelectedPhoto = new PhotoType();
            SelectedPhoto = item;
            Title = "Details";
        }
        public async Task DeleteItem(string id)
        {
            await DataStorePhotosType.DeleteItemAsync(id);
        }
    }
}
