using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using WindowsWallpaper.Domain;
using WindowsWallpaper.Domain.Providers.BGTask;
using WindowsWallpaper.Domain.Proxy;

namespace WindowsWallpaper.Proxy
{
    public class BGTaskProxy : IBGTaskProxy
    {
        private BGTaskProxy() { }

        private static BGTaskProxy Current = new BGTaskProxy();

        public static BGTaskProxy Create()
        {
            return Current;
        }

        IBGTaskProvider BGProvider = new BGTask.BGTaskProvider();
        
        public void RegisterUpdateDailyUpdateImageBGTask()
        {
        
            BGProvider.RegisterBGTask(BGTaskKey.UpdateDailyImageBGTask, new TimeTrigger(30, false), new List<SystemConditionType> { SystemConditionType.InternetAvailable });
        }

        public void UnRegisterDailyUpdateImageBGTask()
        {
            BGProvider.UnRegisterBGTask(BGTaskKey.UpdateDailyImageBGTask, false);
        }

        public bool CheckBGTaskRegistered(BGTaskKey key)
        {
            return BGProvider.IsBGTaskRegistered(key);
        }
    }
}