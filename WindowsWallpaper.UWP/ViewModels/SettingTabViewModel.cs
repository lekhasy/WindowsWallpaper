using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.UWP.ViewModels
{
    public class SettingTabViewModel : BaseViewModel
    {
        private bool _autoUpdateBackgroundState = false;
        public bool AutoUpdateBackgroundState
        {
            get { return _autoUpdateBackgroundState; }
            set
            {
                if (_autoUpdateBackgroundState != value)
                {
                    Dictionary<int, int> d = new Dictionary<int, int>();
                    _autoUpdateBackgroundState = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}