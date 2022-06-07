using MIcroInsta.Models;
using MIcroInsta.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIcroInsta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        PhotoDetailsPageViewModel viewModel;
        public ImagePage(PhotoType item)
        {
            InitializeComponent();
            BindingContext = viewModel = new PhotoDetailsPageViewModel(item);
        }
    }
}