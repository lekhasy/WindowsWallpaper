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

        public async Task SetAsBackGround()
        {

             //UserProfilePersonalizationSettings.Current.TrySetWallpaperImageAsync(new )
        }

    }
}
