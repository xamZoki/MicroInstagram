using FFImageLoading.Forms;
using MIcroInsta.Models;
using MIcroInsta.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MIcroInsta.ViewModels
{
    public class AddPhotoPageViewModel: BaseViewModel
    {
        public IDataPhotosType<PhotoType> DataStorePhotosType => DependencyService.Get<IDataPhotosType<PhotoType>>();
        public string ImageSource { get { return "drupallogo.png"; } set { ImageSource = value; } }
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                SetProperty(ref _text, value);
            }
        }
        public async Task AddPhoto(CachedImage imageSource, string id)
        {
           await DataStorePhotosType.AddPhotoAsync(imageSource, id);
        }

    }
}
