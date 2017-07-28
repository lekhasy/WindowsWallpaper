using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace WindowsWallpaper.UWP
{
    public static class RegisterBGTask
    {
        const string UpdateDailyImageBGTask = "UpdateDailyImageBGTask";
        const string UpdateDailyImageBGTaskEndPoint = "WindowsWallpaper.BGTask.UpdateImageBgTask";
        public static void RegisterUpdateDailyImageBGTask()
        {
            Utils.BGTaskRegister.RegisterBGTask(UpdateDailyImageBGTask, UpdateDailyImageBGTaskEndPoint, new TimeTrigger(30, false), new List<SystemConditionType> {SystemConditionType.InternetAvailable});
        }
    }
}
