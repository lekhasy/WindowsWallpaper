using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WindowsWallpaper.Domain.Providers.Storage;

namespace WindowsWallpaper.Storage
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/uwp/app-settings/store-and-retrieve-app-data
    /// </summary>
    public class LocalSettingStorageProvider : ILocalStorageProvider
    {
        public async Task<T> GetAsync<T>(StorageKeys key, T defaultValue)
        {
            object tempValue;
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key.ToString(), out tempValue))
            {
                return (T)tempValue;
            }
            else
            {
                await SetAsync(key, defaultValue);
                return defaultValue;
            }
        }
        
        public Task SetAsync<T>(StorageKeys key, T value)
        {
            ApplicationData.Current.LocalSettings.Values[key.ToString()] = value;
            return Task.FromResult(0);
        }

        public Task<bool> TryGetAsync<T>(StorageKeys key, out T value)
        {
            object tempValue;
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue(key.ToString(), out tempValue))
            {
                value = (T)tempValue;
                return Task.FromResult(true);
            }
            else 
            {
                value = default(T);
                return Task.FromResult(false);
            }
            
        }
    }
}
