using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WindowsWallpaper.UWP.Components
{
    public sealed partial class ImageItem : UserControl
    {
        ViewModels.ImageItemViewModel vm;

        public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register("ImageSource", typeof(Domain.Entities.ImageSource), typeof(ImageItem), new PropertyMetadata(null));

        public Domain.Entities.ImageSource ImageSource
        {
            get
            {
                return (Domain.Entities.ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        public ImageItem()
        {
            this.InitializeComponent();
            vm = ViewModels.ImageItemViewModel.Create(null);
        }

        private void UserControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (this.DataContext is Domain.Entities.ImageSource)
            {
                this.DataContext = ViewModels.ImageItemViewModel.Create(this.DataContext as Domain.Entities.ImageSource);
            }
        }
    }
}