using FFImageLoading.Forms;
using MIcroInsta.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MIcroInsta.Services
{
    public class PhotosListDataStore :  IDataPhotosType<PhotoType>
    {
        HttpClient client;
        List<Photo> items;
        List<PhotoType> itemsType;

        public PhotosListDataStore()
        {
            items = new List<Photo>();
            itemsType = new List<PhotoType>();
            client = new HttpClient();
        }
        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = itemsType.Where((PhotoType arg) => arg.id.ToString() == id).FirstOrDefault();
            itemsType.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public Task<bool> AddPhotoAsync(CachedImage i, string text)
        {
            PhotoType lastItem = itemsType.LastOrDefault();
            PhotoType p = new PhotoType { id = lastItem.id + 1, url = null, download_urlImage = i, author = text  };
            itemsType.Add(p);
            return Task.FromResult(true);
        }
        public async Task<List<PhotoType>> GetItemsPhotoTypeAsync()
        {
            if (App.initalCall == 0)
            {
                var response = await client.GetStringAsync("https://picsum.photos/v2/list"); ;
                var allPhotos = JsonConvert.DeserializeObject<IEnumerable<PhotoType>>(response);
                foreach (var item in allPhotos)
                {
                    item.download_urlImage = new CachedImage();
                    item.download_urlImage.Source = item.download_url;
                }
                itemsType = allPhotos.ToList();
                App.initalCall = 1;
                return itemsType;
            }
            else
            {
                return itemsType;
            }
        }
    }
}
