using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.Domain.Providers.BGTask
{
    public enum BGTaskKey
    {
        UpdateDailyImageBGTask
    }

    public static class BGTaskKeyExtension
    {

        public const string UpdateDailyImageBGTaskName = "UpdateDailyImageBGTask";
        public const string UpdateDailyImageBGTaskEndPoint = "WindowsWallpaper.BGTaskEntries.UpdateImageBgTask";

        public static string GetTaskName(this BGTaskKey key)
        {
            switch (key)
            {
                case BGTaskKey.UpdateDailyImageBGTask: return UpdateDailyImageBGTaskName;
            }

            throw new ArgumentException();
        }

        public static string GetTaskEnty(this BGTaskKey key)
        {
            switch (key)
            {
                case BGTaskKey.UpdateDailyImageBGTask: return UpdateDailyImageBGTaskEndPoint;
            }

            throw new ArgumentException();
        }
    }
}
