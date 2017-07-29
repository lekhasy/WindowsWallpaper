using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain.Providers.Storage;

namespace WindowsWallpaper.Domain.Proxy
{
    public interface IUserPreferencesProxy
    {
        Task<bool> GetAutoUpdateBGImageAsync(bool defaultValue);
        Task SetAutpUpdateImageAsync(bool value);

        Task<bool> GetAutoUpdateLockScreenImageAsync(bool defaultValue);
        Task SetAutoUpdateLockScreenImageAsync(bool value);

    }
}