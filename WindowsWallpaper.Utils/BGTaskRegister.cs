using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace WindowsWallpaper.Utils
{
    public static class BGTaskRegister
    {
        public static void RegisterBGTask(string taskName, string entrypoint, IBackgroundTrigger triggers, IEnumerable<SystemConditionType> condition)
        {
            var taskRegistered = false;

            foreach (var tsk in BackgroundTaskRegistration.AllTasks)
                if (tsk.Value.Name == taskName)
                {
                    taskRegistered = true;
                    break;
                }

            if (taskRegistered) return;

            var builder = new BackgroundTaskBuilder();

            builder.Name = taskName;
            builder.TaskEntryPoint = entrypoint; 
            builder.SetTrigger(new TimeTrigger(30, false));
            foreach (var con in condition)
                builder.AddCondition(new SystemCondition(con));

            BackgroundTaskRegistration task = builder.Register();
        }
    }
}
