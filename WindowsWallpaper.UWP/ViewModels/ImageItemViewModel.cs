using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.UWP.ViewModels
{
    public class ImageItemViewModel : BaseViewModel
    {
        private Domain.Entities.WwImageSource _source;

        public Domain.Entities.WwImageSource SourceImg
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

        private ImageItemViewModel(Domain.Entities.WwImageSource source)
        {
            SourceImg = source;
        }

        public static ImageItemViewModel Create(Domain.Entities.WwImageSource source)
        {
            return new ImageItemViewModel(source);
        }
    }
}