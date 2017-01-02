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
using WOWS_UWP;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace WOWS_UWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        httphelper h = new httphelper();
        Ships ships = new Ships();
        info infos = new info();
        public MainPage()
        {
            this.InitializeComponent();
            button.IsEnabled = false;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //4253988848
            //shipinfo s= Ships.getshipinfo("4253988848");
            if (infos.ID.Length < 2|| Zoneselect.SelectedValue.ToString()=="")
            {
                var dialog = new ContentDialog()
                {
                    Title = "消息提示",
                    Content = "信息不完整，重新填写。",
                    PrimaryButtonText = "确定",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();
                return;

            }
            infos.dayinfo= await h.Getdayshipinfo();
            infos.allshipinfo = await h.Getallshipinfo();
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(dayinfo), infos);
        }

        private async void Zoneselect_DropDownClosed(object sender, object e)
        {
            if (Zoneselect.SelectedValue.ToString().Equals("南区"))
                infos.zone = "south";
            else
                infos.zone = "north";
            infos.name = usernameinput.Text;
            if (infos.name == "")
            {
                var dialog = new ContentDialog()
                {
                    Title = "消息提示",
                    Content = "用户名不能为空",
                    PrimaryButtonText = "确定",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                await dialog.ShowAsync();
                return;
            }
            infos.ID = await h.GetLogininfo(usernameinput.Text, infos.zone);
            if (infos.ID.Equals("error information!"))
            {
                //Output.Text += infos.name + '\n';
                //Output.Text += infos.zone+'\n';
                Output.Text += infos.ID + '\n';
                return;
            }
            button.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(shipinformation), infos);
        }
    }
}
