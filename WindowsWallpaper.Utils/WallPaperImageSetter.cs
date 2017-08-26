using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.System.UserProfile;

namespace WindowsWallpaper.Utils
{
    public static class WallPaperImageSetter
    {
        public static async Task<bool> SetLockScreenImageAsync(Uri source)
        {
            var filename = Guid.NewGuid().ToString();
            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("bground", CreationCollisionOption.OpenIfExists);
            filename += source.AbsolutePath.Substring(source.AbsolutePath.LastIndexOf('.'));
            var file = await DownloadFileAsync(folder, filename, source);
            var result = await UserProfilePersonalizationSettings.Current.TrySetLockScreenImageAsync(file);
            await CleanUpFolderAsync(folder, filename);
            return result;
        }

        public static async Task<bool> SetBackGroundImageAsync(Uri source)
        {
            var filename = Guid.NewGuid().ToString();
            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("lock", CreationCollisionOption.OpenIfExists);
            filename += source.AbsolutePath.Substring(source.AbsolutePath.LastIndexOf('.'));
            var file = await DownloadFileAsync(folder, filename, source);
            var result = await UserProfilePersonalizationSettings.Current.TrySetWallpaperImageAsync(file);
            await CleanUpFolderAsync(folder, filename);
            return result;
        }


        private static async Task<StorageFile> DownloadFileAsync(StorageFolder folder, string filename, Uri source)
        {
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);
            BackgroundDownloader backgroundDownloader = new BackgroundDownloader();
            DownloadOperation operation = backgroundDownloader.CreateDownload(source, file);
            await operation.StartAsync();
            return file;
        }



        private static async Task<StorageFolder> CleanUpFolderAsync(StorageFolder folder, string exceptFileName)
        {
            var files = await folder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery);
            foreach (var item in files)
            {
                if (!item.Name.Contains(exceptFileName))
                {
                    await item.DeleteAsync(StorageDeleteOption.PermanentDelete);
                }
            }
            return folder;
        }
    }
}
