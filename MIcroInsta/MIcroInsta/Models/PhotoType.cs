

using FFImageLoading.Forms;
using Xamarin.Forms;

namespace MIcroInsta.Models
{
    public class PhotoType
    {
        public int id { get; set; }
        public string author { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
        public CachedImage download_urlImage { get; set; }
        //public Image download_urlImage { 
        //    get 
        //    {
        //        download_urlImage.Source = download_url;
        //        return download_urlImage; 
        //    }
        //    set
        //    {
        //        download_urlImage.Source = value.Source;
        //    }
        //}
        public int width { get; set; }
        public int height { get; set; }
    }
}
