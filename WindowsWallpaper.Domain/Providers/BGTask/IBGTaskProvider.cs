using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace WindowsWallpaper.Domain.Providers.BGTask
{
    public interface IBGTaskProvider
    {
        void RegisterBGTask(BGTaskKey key, IBackgroundTrigger triggers, IEnumerable<SystemConditionType> condition);
        void UnRegisterBGTask(BGTaskKey key, bool cancelTask);
        bool IsBGTaskRegistered(BGTaskKey key);
    }
}