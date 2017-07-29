using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace WindowsWallpaper.BGTaskEntries
{
    public sealed class UpdateImageBgTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral defferal = taskInstance.GetDeferral();
            
            

            defferal.Complete();
        }
    }
}