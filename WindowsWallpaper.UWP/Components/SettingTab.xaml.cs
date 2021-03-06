﻿using System;
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
using WindowsWallpaper.UWP.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WindowsWallpaper.UWP.Components
{
    public sealed partial class SettingTab : UserControl
    {
        SettingTabViewModel vm;
        public SettingTab()
        {
            this.InitializeComponent();
            vm = new SettingTabViewModel();
            this.DataContext = vm;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await vm.ReloadDataAsync();
        }
    }
}