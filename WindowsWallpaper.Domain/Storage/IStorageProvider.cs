using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.Domain.Storage
{
    public interface IStorageProvider
    {
        Task<bool> TryGetAsync<T>(StorageKeys key, out T value);
        Task<T> GetAsync<T>(StorageKeys key, T defaultValue);
        Task SetAsync<T>(StorageKeys key, T value);
    }    
}
