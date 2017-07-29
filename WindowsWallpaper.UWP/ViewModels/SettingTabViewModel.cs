using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain;
using WindowsWallpaper.Domain.Providers.BGTask;
using WindowsWallpaper.Domain.Proxy;
using WindowsWallpaper.Proxy;

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
                    UpdateBGStateAsync(value).Wait();
                }
            }
        }

        private bool _autoUpdateLockScreenState = false;
        public bool AutoUpdateLockScreenState
        {
            get { return _autoUpdateLockScreenState; }
            set
            {
                if (_autoUpdateLockScreenState != value)
                {
                    Dictionary<int, int> d = new Dictionary<int, int>();
                    _autoUpdateLockScreenState = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _updatingAutoUpdateBackgroundState = false;
        public bool UpdatingAutoUpdateBackgroundState
        {
            get { return _updatingAutoUpdateBackgroundState; }
            set
            {
                if (_updatingAutoUpdateBackgroundState != value)
                {
                    Dictionary<int, int> d = new Dictionary<int, int>();
                    _updatingAutoUpdateBackgroundState = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _updatingAutoUpdateLockScreenState = false;
        public bool UpdatingAutoUpdateLockScreenState
        {
            get { return _updatingAutoUpdateLockScreenState; }
            set
            {
                if (_updatingAutoUpdateLockScreenState != value)
                {
                    Dictionary<int, int> d = new Dictionary<int, int>();
                    _updatingAutoUpdateLockScreenState = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _initTingData = false;
        public bool InitingData
        {
            get { return _initTingData; }
            set
            {
                if (_initTingData != value)
                {
                    Dictionary<int, int> d = new Dictionary<int, int>();
                    _initTingData = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public async Task InitDataAsync()
        {
            InitingData = true;
            AutoUpdateBackgroundState = _BGTaskProxy.CheckBGTaskRegistered(BGTaskKey.UpdateDailyImageBGTask);
            InitingData = false;
            await Task.FromResult(0);
        }

        IUserPreferencesProxy _UserPreferencesProxy = UserPreferencesProxy.Create();
        IBGTaskProxy _BGTaskProxy = BGTaskProxy.Create();


        private async Task UpdateBGStateAsync(bool enable)
        {
            UpdatingAutoUpdateBackgroundState = true;
            
            
            UpdatingAutoUpdateBackgroundState = false;
            
        }
    }
}