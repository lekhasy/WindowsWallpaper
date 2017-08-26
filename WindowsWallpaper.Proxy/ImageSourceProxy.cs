using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using WindowsWallpaper.Domain;
using WindowsWallpaper.Domain.Entities;
using WindowsWallpaper.Domain.Proxy;

namespace WindowsWallpaper.Proxy
{
    public class ImageSourceProxy : IImageSourceProxy
    {
        public async Task<WwImageSource> GetBackgroundImageAsync()
        {
            return (await GetImagesAsync()).First();
        }

        public async Task<IEnumerable<WwImageSource>> GetImagesAsync()
        {
            IDailyImageSource source = new ImageSource.BingDailyImageSource();
            var Images = (await source.GetTodayImageSourceAsync()).ToList();
            return Images;
        }

        public async Task<WwImageSource> GetLockScreenImageAsync()
        {
            return (await GetImagesAsync()).First();
        }
    }
}
