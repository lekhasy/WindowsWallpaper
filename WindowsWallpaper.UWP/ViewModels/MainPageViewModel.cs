using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.System.UserProfile;

namespace WindowsWallpaper.UWP.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        ICollection<Domain.Entities.ImageSource> _images = new ObservableCollection<Domain.Entities.ImageSource>();

        public ICollection<Domain.Entities.ImageSource> Images
        {
            get { return _images; }
            set
            {
                if (_images != value)
                {
                    _images = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Domain.Entities.ImageSource _selectedImage;

        public Domain.Entities.ImageSource SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                if (_selectedImage != value)
                {
                    _selectedImage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public async Task InitDataAsync()
        {
            ImageSource.BingDailyImageSource source = new ImageSource.BingDailyImageSource();
            Images = (await source.GetTodayImageSourceAsync()).ToList();
        }

        public async Task<string> DownloadCurrentImage()
        {
            try
            {
                var filename = new string(SelectedImage.Description.TakeWhile(c => c != '(').ToArray());
                filename += SelectedImage.Source.AbsolutePath.Substring(SelectedImage.Source.AbsolutePath.LastIndexOf('.'));
                StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);
                BackgroundDownloader backgroundDownloader = new BackgroundDownloader();
                DownloadOperation operation = backgroundDownloader.CreateDownload(SelectedImage.Source, file);
                await operation.StartAsync();
                return file.DisplayName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SetAsBackGround()
        {
            var filename = Guid.NewGuid().ToString();
            filename += SelectedImage.Source.AbsolutePath.Substring(SelectedImage.Source.AbsolutePath.LastIndexOf('.'));
            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("lock", CreationCollisionOption.OpenIfExists);
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);
            BackgroundDownloader backgroundDownloader = new BackgroundDownloader();
            DownloadOperation operation = backgroundDownloader.CreateDownload(SelectedImage.Source, file);
            await operation.StartAsync();
            var result = await UserProfilePersonalizationSettings.Current.TrySetWallpaperImageAsync(file);
            await EnsureNewFolder(folder, filename);
            return result;
        }

        public async Task<bool> SetAsLockScreen()
        {
            var filename = Guid.NewGuid().ToString();
            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("lock", CreationCollisionOption.OpenIfExists);
            filename += SelectedImage.Source.AbsolutePath.Substring(SelectedImage.Source.AbsolutePath.LastIndexOf('.'));
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);
            BackgroundDownloader backgroundDownloader = new BackgroundDownloader();
            DownloadOperation operation = backgroundDownloader.CreateDownload(SelectedImage.Source, file);
            await operation.StartAsync();
            var result = await UserProfilePersonalizationSettings.Current.TrySetLockScreenImageAsync(file);
            await EnsureNewFolder(folder, filename);
            return result;
        }

        public async Task<StorageFolder> EnsureNewFolder(StorageFolder folder, string filename)
        {
            var files = await folder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.DefaultQuery);
            foreach (var item in files)
            {
                if (!item.Name.Contains(filename))
                {
                    await item.DeleteAsync(StorageDeleteOption.PermanentDelete);
                }
            }
            return folder;
        }
    }
}
