using MIcroInsta.Models;
using MIcroInsta.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MIcroInsta.ViewModels
{
    public class PhotosThumbnailsListViewModel: BaseViewModel
    {
        public IDataPhotosType<PhotoType> DataStorePhotosType => DependencyService.Get<IDataPhotosType<PhotoType>>();
        private ObservableCollection<PhotoType> _allPhotosType;
        public ObservableCollection<PhotoType> AllPhotosType
        {
            get
            {
                return _allPhotosType;
            }
            set
            {
                SetProperty(ref _allPhotosType, value);
            }
        }
        public ICommand AddItemCommand => new Xamarin.Forms.Command(async () => {

            await Shell.Current.GoToAsync("AddPhotoPage");
         
        });
    
        public PhotosThumbnailsListViewModel()
        {
            AllPhotosType = new ObservableCollection<PhotoType>();
            Title = "Home";
        }
        public async Task GetAllPhotos()
        {
            IsBusy = true;
            //var ttAllPhotosStatic = await DataStorePhotos.GetItemsAsync();
            //AllPhotosStatic = ttAllPhotosStatic.ToList();
            //AllPhotos = new ObservableCollection<Photo>(ttAllPhotosStatic);
            IsBusy = false;
        }
        public async Task GetAllPhotosType()
        {
            IsBusy = true;
            var ttAllPhotosStatic = await DataStorePhotosType.GetItemsPhotoTypeAsync();
            AllPhotosType = new ObservableCollection<PhotoType>(ttAllPhotosStatic);
            IsBusy = false;
        }
    }
}
