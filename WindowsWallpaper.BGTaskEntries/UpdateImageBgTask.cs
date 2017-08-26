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

            Domain.Proxy.IUserPreferencesProxy userPreference = Proxy.UserPreferencesProxy.Create();
            Domain.Proxy.IImageSourceProxy imgProxy = new Proxy.ImageSourceProxy();

            if (await userPreference.GetAutoUpdateBGImageAsync(false))
            {
                var bgcreenImage = await imgProxy.GetLockScreenImageAsync();
                await Utils.WallPaperImageSetter.SetBackGroundImageAsync(bgcreenImage.Source);
            }

            if(await userPreference.GetAutoUpdateLockScreenImageAsync(false))
            {
                var lockscreenImage = await imgProxy.GetLockScreenImageAsync();
                await Utils.WallPaperImageSetter.SetLockScreenImageAsync(lockscreenImage.Source);
            }

            defferal.Complete();
        }
    }
}