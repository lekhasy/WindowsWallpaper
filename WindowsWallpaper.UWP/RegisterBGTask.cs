using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using WindowsWallpaper.Domain;

namespace WindowsWallpaper.UWP
{
    public static class WindowsWallpaperBGTaskRegister
    {
        public static void RegisterUpdateDailyBGImageBGTask()
        {
            Utils.BGTaskRegister.RegisterBGTask(AppConstants.UpdateDailyImageBGTask, AppConstants.UpdateDailyImageBGTaskEndPoint, new TimeTrigger(30, false), new List<SystemConditionType> {SystemConditionType.InternetAvailable});
        }
    }
}
