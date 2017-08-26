using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain.Entities;

namespace WindowsWallpaper.Domain.Proxy
{
    public interface IImageSourceProxy
    {
        Task<IEnumerable<WwImageSource>> GetImagesAsync();

        Task<WwImageSource> GetLockScreenImageAsync();
        Task<WwImageSource> GetBackgroundImageAsync();

    }
}