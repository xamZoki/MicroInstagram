using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MIcroInsta.Services
{
    public interface IDataPhotos<Photo>
    {
        Task<List<Photo>> GetItemsAsync();
        bool EditPhotoAsync(string id, CachedImage image);
        Task<bool> DeleteItemAsync(string id);
        Task<bool> AddPhotoAsync(CachedImage image, string id);
    }
    public interface IDataPhotosType<PhotoType>
    {
        Task<List<PhotoType>> GetItemsPhotoTypeAsync();
        Task<bool> DeleteItemAsync(string id);
        //bool EditPhotoAsync(string id, CachedImage image);
        //Task<bool> DeleteItemAsync(string id);
        Task<bool> AddPhotoAsync(CachedImage imageSource, string id);
    }
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        
    }
}
