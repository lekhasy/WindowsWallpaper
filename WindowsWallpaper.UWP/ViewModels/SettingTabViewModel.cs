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
                    UpdateLockScreenStateAsync(value).Wait();
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

        private bool _initTingData = true;
        public bool InitingData
        {
            get { return _initTingData; }
            set
            {
                if (_initTingData != value)
                {
                    _initTingData = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public async Task ReloadDataAsync()
        {
            InitingData = true;
            AutoUpdateBackgroundState  = await _UserPreferencesProxy.GetAutoUpdateBGImageAsync(false);
            AutoUpdateLockScreenState = await _UserPreferencesProxy.GetAutoUpdateLockScreenImageAsync(false);
            InitingData = false;
        }

        IUserPreferencesProxy _UserPreferencesProxy = UserPreferencesProxy.Create();

        private async Task UpdateBGStateAsync(bool enable)
        {
            UpdatingAutoUpdateBackgroundState = true;

            await _UserPreferencesProxy.SetAutoUpdateImageAsync(enable);
            
            UpdatingAutoUpdateBackgroundState = false;
        }
        
        private async Task UpdateLockScreenStateAsync(bool enable)
        {
            UpdatingAutoUpdateLockScreenState = true;

            await _UserPreferencesProxy.SetAutoUpdateLockScreenImageAsync(enable);

            UpdatingAutoUpdateLockScreenState = false;
        }
    }
}