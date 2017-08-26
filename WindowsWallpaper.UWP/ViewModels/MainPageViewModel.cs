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
using WindowsWallpaper.Domain;
using WindowsWallpaper.Domain.Proxy;
using WindowsWallpaper.Proxy;

namespace WindowsWallpaper.UWP.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        ICollection<Domain.Entities.WwImageSource> _images = new ObservableCollection<Domain.Entities.WwImageSource>();

        public ICollection<Domain.Entities.WwImageSource> Images
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

        private Domain.Entities.WwImageSource _selectedImage;

        public Domain.Entities.WwImageSource SelectedImage
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
            IDailyImageSource source = new ImageSource.BingDailyImageSource();
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

         IUserPreferencesProxy _UserPreferencesProxy = UserPreferencesProxy.Create();

        public async Task<bool> SetAsBackGround()
        {
            var settingresult = await Utils.WallPaperImageSetter.SetBackGroundImageAsync(SelectedImage.Source);
            if(settingresult)
            await _UserPreferencesProxy.SetAutoUpdateImageAsync(false);
            return settingresult;
        }

        public async Task<bool> SetAsLockScreen()
        {
            var settingResult = await Utils.WallPaperImageSetter.SetLockScreenImageAsync(SelectedImage.Source);
            if (settingResult)
                await _UserPreferencesProxy.SetAutoUpdateLockScreenImageAsync(false);
            return settingResult;
        }
    }
}
