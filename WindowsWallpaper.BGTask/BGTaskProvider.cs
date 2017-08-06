using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using WindowsWallpaper.Domain.Providers.BGTask;

namespace WindowsWallpaper.BGTask
{
    public class BGTaskProvider : IBGTaskProvider
    {
        public void RegisterBGTask(BGTaskKey key, IBackgroundTrigger trigger, IEnumerable<SystemConditionType> condition)
        {
            var taskRegistered = false;

            foreach (var tsk in BackgroundTaskRegistration.AllTasks)
                if (tsk.Value.Name == key.GetTaskName())
                {
                    taskRegistered = true;
                    break;
                }

            if (taskRegistered) return;

            var builder = new BackgroundTaskBuilder()
            {
                Name = key.GetTaskName(),
                TaskEntryPoint = key.GetTaskEnty()
            };

            builder.SetTrigger(trigger);
            foreach (var con in condition)
                builder.AddCondition(new SystemCondition(con));

            BackgroundTaskRegistration task = builder.Register();
        }

        public void UnRegisterBGTask(BGTaskKey key, bool cancelTask)
        {
            var task = BackgroundTaskRegistration.AllTasks.FirstOrDefault(t => t.Value.Name == key.GetTaskName()).Value;
            if (task != null)
            {
                task.Unregister(cancelTask);
            }
        }

        public bool IsBGTaskRegistered(BGTaskKey key)
        {
            return BackgroundTaskRegistration.AllTasks.Any(t => t.Value.Name == key.GetTaskName());
        }
    }
}
