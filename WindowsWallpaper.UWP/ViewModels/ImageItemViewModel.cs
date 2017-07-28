using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.UWP.ViewModels
{
    public class ImageItemViewModel : BaseViewModel
    {
        private Domain.ImageSource _source;

        public Domain.ImageSource SourceImg
        {
            get { return _source; }
            set
            {
                if (_source != value)
                {
                    _source = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ImageItemViewModel(Domain.ImageSource source)
        {
            SourceImg = source;
        }

        public static ImageItemViewModel Create(Domain.ImageSource source)
        {
            return new ImageItemViewModel(source);
        }
    }
}