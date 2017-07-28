using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.Domain
{
    public interface IDailyImageSource
    {
        Task<IEnumerable<ImageSource>> GetTodayImageSourceAsync();
    }
}
