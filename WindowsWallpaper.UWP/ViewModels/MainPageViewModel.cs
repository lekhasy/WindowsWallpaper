using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.UWP.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        ICollection<Domain.ImageSource> _images = new ObservableCollection<Domain.ImageSource>();

        public ICollection<Domain.ImageSource> Images
        {
            get { return _images; }
            set
            {
                if (_images != value)
                {
                    _images = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public async Task InitDataAsync()
        {
            ImageSource.BingDailyImageSource source = new ImageSource.BingDailyImageSource();
            Images = (await source.GetTodayImageSourceAsync()).ToList();
        }
    }
}
