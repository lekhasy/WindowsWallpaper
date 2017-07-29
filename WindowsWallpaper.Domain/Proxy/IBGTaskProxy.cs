using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain.Providers.BGTask;

namespace WindowsWallpaper.Domain.Proxy
{
    public interface IBGTaskProxy
    {
        void RegisterUpdateDailyUpdateImageBGTask();

        void UnRegisterDailyUpdateImageBGTask();

        bool CheckBGTaskRegistered(BGTaskKey key);
    }
}