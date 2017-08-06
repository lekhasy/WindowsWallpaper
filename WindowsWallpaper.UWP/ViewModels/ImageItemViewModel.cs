using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.UWP.ViewModels
{
    public class ImageItemViewModel : BaseViewModel
    {
        private Domain.Entities.ImageSource _source;

        public Domain.Entities.ImageSource SourceImg
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

        private ImageItemViewModel(Domain.Entities.ImageSource source)
        {
            SourceImg = source;
        }

        public static ImageItemViewModel Create(Domain.Entities.ImageSource source)
        {
            return new ImageItemViewModel(source);
        }
    }
}