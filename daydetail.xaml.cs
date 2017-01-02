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
    public sealed partial class daydetail : Page
    {
        private info i;
        private List<dayshipinfo> dayinfo;
        private List<dayshipinfo> selectedday=new List<dayshipinfo>();
        private string dates;
        public daydetail()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            maintoday info = (maintoday)e.Parameter;
            i = info.info;
            dates=date.Text = info.f;
            dayinfo = i.dayinfo;
            string[] s=dates.Split('-');
            foreach (dayshipinfo d in dayinfo)
            {
                if (d.insert_date.month+1 ==int.Parse(s[1])&& d.insert_date.date==int.Parse(s[2]))
                {
                    selectedday.Add(d);
                }
            }
            List<string> l = new List<string>();
            foreach (dayshipinfo a in selectedday)
            {
                l.Add(infomation(a));

            }
            daydetail1.ItemsSource = l;
        }

        private string infomation(dayshipinfo a)
        {
            string s="";
            s += Ships.getshipinfo(a.id.vehicleTypeCd).alias + "\n";
            s += "战斗场数："+a.battles+"\n";
            s += "战力：" + getshippower(i.allshipinfo.Find(
                delegate (Shipinfo user)
            {
                return user.id.vehicleTypeCd==a.id.vehicleTypeCd;
            })) + "\n";
            s+="伤害："+ a.damage/a.battles +"\n";
            s+="胜率："+((double)a.wins/(double)a.battles).ToString("P") +"\n";
            return s;
        }
        private string getshippower(Shipinfo s)
        {
            double totalp = s.totalPower / (double)s.battles;
            double winp = s.winPower / (double)s.battles;
            double x = (totalp + s.movingPower) / 2 * (1 + winp / Ships.getshipinfo(s.id.vehicleTypeCd).weight);
            if (x - (int)x - 0.5 > 0)
            {
                return ((int)x + 1).ToString();
            }
            else
            {
                return ((int)x).ToString();
            }
        }

        private void textBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(dayinfo), i);
        }
    }
}
