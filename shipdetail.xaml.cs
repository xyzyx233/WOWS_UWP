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
    public sealed partial class shipdetail : Page
    {
        public shipdetail()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 这里重写OnNavigatedTo方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //这个e.Parameter是获取传递过来的参数，其实大家应该再次之前判断这个参数是否为null的，我偷懒了
            shipinfo info = (shipinfo)e.Parameter;
            cd.Text = info.cd;
            id.Text = info.id;
            name.Text = info.name;
            alias.Text = info.alias;
            country.Text = info.country;
            tyoe.Text = info.type;
            lvl.Text = info.lvl;
            weight.Text = info.weight.ToString();
            baseweight.Text = info.baseweight.ToString();
            cnname.Text = info.cnname;
            if (info.jump)
                jump.Text = "否";
            else
                jump.Text = "是";
        }
        private void backtoparents_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(shipinformation));
        }
    }
}
