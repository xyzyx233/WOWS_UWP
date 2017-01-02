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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace WOWS_UWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class shipinformation : Page
    {
        public shipinformation()
        {
            this.InitializeComponent();
            List<string> l = Ships.getallnamelist();
            foreach (string s in l)
            {
                shiplistdisplay.Items.Add(s);
            }
        }

        private void shiplistdisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = shiplistdisplay.SelectedValue.ToString();
            if (s.EndsWith(")"))
                s = s.Substring(0, (s.Length - 4));
            shipinfo f = Ships.getshipinfobyalias(s);
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(shipdetail),f);
        }

        private void textBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(MainPage));
        }
    }
}
