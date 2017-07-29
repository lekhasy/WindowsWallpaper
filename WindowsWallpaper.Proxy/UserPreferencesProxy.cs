using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain.Providers.Storage;
using WindowsWallpaper.Domain.Proxy;
using WindowsWallpaper.Storage;

namespace WindowsWallpaper.Proxy
{
    public class UserPreferencesProxy : IUserPreferencesProxy
    {

        private UserPreferencesProxy() { }

        static UserPreferencesProxy _Curent = new UserPreferencesProxy();

        public static UserPreferencesProxy Create()
        {
            return _Curent;
        }

        ILocalStorageProvider _LocalStorageProvider = new LocalSettingStorageProvider();

        public Task<bool> GetAutoUpdateBGImageAsync(bool defaultValue)
        {
            return _LocalStorageProvider.TryGetAsync(StorageKeys.AutoUpdateBackgroundImage, out defaultValue);
        }

        public Task SetAutpUpdateImageAsync(bool value)
        {
            return _LocalStorageProvider.SetAsync(StorageKeys.AutoUpdateBackgroundImage, value);
        }

        public Task<bool> GetAutoUpdateLockScreenImageAsync(bool defaultValue)
        {
            return _LocalStorageProvider.GetAsync(StorageKeys.AutoUpdateLockScreenImage, defaultValue);
        }

        public Task SetAutoUpdateLockScreenImageAsync(bool value)
        {
            return _LocalStorageProvider.SetAsync(StorageKeys.AutoUpdateLockScreenImage, value);
        }
    }
}