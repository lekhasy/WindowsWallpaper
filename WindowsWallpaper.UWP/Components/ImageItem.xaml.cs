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
        DependencyProperty.Register("ImageSource", typeof(Domain.ImageSource), typeof(ImageItem), new PropertyMetadata(null));

        public Domain.ImageSource ImageSource
        {
            get
            {
                return (Domain.ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ImageSourcePropertyStr =
        DependencyProperty.Register("ImageSourceStr", typeof(string), typeof(ImageItem), new PropertyMetadata(null));

        public string ImageSourceStr
        {
            get
            {
                return (string)GetValue(ImageSourcePropertyStr);
            }
            set
            {
                SetValue(ImageSourcePropertyStr, value);
            }
        }

        public ImageItem()
        {
            this.InitializeComponent();
            vm = ViewModels.ImageItemViewModel.Create(ImageSource);
        }
    }
}