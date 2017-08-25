using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain.Entities;

namespace WindowsWallpaper.Domain
{
    public interface IDailyImageSource
    {
        Task<IEnumerable<ImageSource>> GetTodayImageSourceAsync();
    }
}
