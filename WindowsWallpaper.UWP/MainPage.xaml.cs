using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.UserProfile;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsWallpaper.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ViewModels.MainPageViewModel vm = new ViewModels.MainPageViewModel();
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await vm.InitDataAsync();
            }
            catch
            {
                MessageDialog dialog = new MessageDialog("Please check your internet connection");
                await dialog.ShowAsync();
            }
        }
    }
}
