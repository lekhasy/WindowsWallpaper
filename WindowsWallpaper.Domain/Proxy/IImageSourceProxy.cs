using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace WindowsWallpaper.Domain.Proxy
{
    public interface IImageSourceProxy
    {
        IEnumerable<ImageSource> GetImages();
    }
}