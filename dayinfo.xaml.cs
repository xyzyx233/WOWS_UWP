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
    public sealed partial class dayinfo : Page
    {
        private List<dayshipinfo> dailyinfo;
        private List<Shipinfo> shipsjob;
        private info userinfo;
        public dayinfo()
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
            info info = (info)e.Parameter;
            userinfo = info;
            dailyinfo = info.dayinfo;
            shipsjob = info.allshipinfo;
            dailyinfo.Sort(SortCompare);
            shipsjob.Sort(SortCompare1);
            myname.Text += "\n"+info.name;
            if (info.zone == "south")
                server.Text += "南区";
            else
                server.Text += "北区";
            foreach (dayshipinfo d in dailyinfo)
            {
                string t = timehelper.GetTime(d.insert_date);
                if (!showday.Items.Contains(t))
                    showday.Items.Add(t);
            }
            foreach (Shipinfo d in shipsjob)
            {
                    shiplist.Items.Add(Ships.getshipinfo(d.id.vehicleTypeCd).alias);
            }
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(MainPage));
        }
        /// <summary>
        /// 对List<CAttributeFeature>进行排序时作为参数使用
        /// </summary>
        /// <param name="AF1"></param>
        /// <param name="AF2"></param>
        /// <returns></returns>
        private static int SortCompare(dayshipinfo AF1, dayshipinfo AF2)
        {
            int res = 0;
            if (AF1.insert_date.time > AF2.insert_date.time)
            {
                res = -1;
            }
            else if (AF1.insert_date.time < AF2.insert_date.time)
            {
                res = 1;
            }
            return res;
        }
        /// <summary>
         /// 对List<CAttributeFeature>进行排序时作为参数使用
         /// </summary>
         /// <param name="AF1"></param>
         /// <param name="AF2"></param>
         /// <returns></returns>
        private static int SortCompare1(Shipinfo AF1, Shipinfo AF2)
        {
            int res = 0;
            if (int.Parse(Ships.getshipinfo(AF1.id.vehicleTypeCd).lvl) > int.Parse(Ships.getshipinfo(AF2.id.vehicleTypeCd).lvl))
            {
                res = -1;
            }
            else if (int.Parse(Ships.getshipinfo(AF1.id.vehicleTypeCd).lvl) > int.Parse(Ships.getshipinfo(AF2.id.vehicleTypeCd).lvl))
            {
                res = 1;
            }
            return res;
        }

        private void textBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(MainPage));
        }

        private void shiplist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = shiplist.SelectedValue.ToString();
            string ss=Ships.getshipinfobyalias(s).cd;
            Shipinfo f = shipsjob.Find(

            delegate (Shipinfo user)
            {
                return user.id.vehicleTypeCd.Equals(Ships.getshipinfobyalias(s).cd);
            });
            maintodetail ff = new maintodetail();
            ff.f = f;
            ff.info = userinfo;
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(shipbattledetail), ff);
        }

        private void showday_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            maintoday ff = new maintoday();
            ff.f = showday.SelectedValue.ToString();
            ff.info = userinfo;
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(daydetail), ff);
        }
    }
    public class maintodetail {
        public Shipinfo f { get; set; }
        public info info { get; set; }
    }
    public class maintoday
    {
        public string f { get; set; }
        public info info { get; set; }
    }

}
