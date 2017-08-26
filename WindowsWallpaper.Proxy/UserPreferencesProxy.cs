using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using WindowsWallpaper.Domain.Providers.BGTask;
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

        IBGTaskProvider _BGTaskprovider = new BGTask.BGTaskProvider();

        public Task<bool> GetAutoUpdateBGImageAsync(bool defaultValue)
        {
            return _LocalStorageProvider.GetAsync(StorageKeys.AutoUpdateBackgroundImage, defaultValue);
        }

        public async Task SetAutoUpdateImageAsync(bool value)
        {
            await _LocalStorageProvider.SetAsync(StorageKeys.AutoUpdateBackgroundImage, value);
            await EnsureBGTaskSetProperlyAsync();
        }

        public Task<bool> GetAutoUpdateLockScreenImageAsync(bool defaultValue)
        {
            return _LocalStorageProvider.GetAsync(StorageKeys.AutoUpdateLockScreenImage, defaultValue);
        }

        public async Task SetAutoUpdateLockScreenImageAsync(bool value)
        {
            await _LocalStorageProvider.SetAsync(StorageKeys.AutoUpdateLockScreenImage, value);
            await EnsureBGTaskSetProperlyAsync();
        }

        private async Task EnsureBGTaskSetProperlyAsync()
        {
            var bgstate = await GetAutoUpdateBGImageAsync(false);
            var lockscreenState = await GetAutoUpdateLockScreenImageAsync(false);

            if (bgstate || lockscreenState)
                _BGTaskprovider.RegisterBGTask(BGTaskKey.UpdateDailyImageBGTask, new TimeTrigger(15, false), new List<SystemConditionType> { SystemConditionType.InternetAvailable });
            else
                _BGTaskprovider.UnRegisterBGTask(BGTaskKey.UpdateDailyImageBGTask, false);
        }

    }
}