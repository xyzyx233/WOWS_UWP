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
    public sealed partial class shipbattledetail : Page
    {
        private maintodetail sx;
        private Shipinfo s;
        private info i;
        public shipbattledetail()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            sx = (maintodetail)e.Parameter;
            s = sx.f;
            i = sx.info;
            shipname.Text = Ships.getshipinfo(s.id.vehicleTypeCd).alias;
            englishname.Text = Ships.getshipinfo(s.id.vehicleTypeCd).name;
            type.Text = gettypebyenglissh(Ships.getshipinfo(s.id.vehicleTypeCd).type);
            power.Text = getshippower();
            planefall.Text = s.killplane.ToString();
            teamup.Text = s.teambattles.ToString() ;
            teamwin.Text = s.teamwins.ToString();
            alivetimes.Text = s.alive.ToString();
            shotdown.Text = s.killship.ToString();
            hurtCV.Text = s.damagecv.ToString();
            highdamge.Text = s.maxdamage.ToString();
            averagehurt.Text = (s.damage / s.battles).ToString();
            firefire.Text = s.damagefire.ToString();
            maxdown.Text = s.maxkillship.ToString();
            shot.Text = (s.damageshot / s.battles).ToString();
            experience.Text = s.exp.ToString();
            maxexp.Text = s.maxexp.ToString();
            tobb.Text = s.damagebb.ToString();
            toCA.Text = s.damageca.ToString();
            floodhurt.Text = s.damageflood.ToString();
            avedemage.Text = ((s.damageflood + s.damagefire + s.damageshot) / s.battles).ToString();
            battle.Text = s.battles.ToString();
            rate.Text = getrate();
        }

        private string getrate()
        {
            double x=double.Parse(getshippower());
            double y = Ships.getshipinfo(s.id.vehicleTypeCd).weight;
            double z = Ships.getshipinfo(s.id.vehicleTypeCd).baseweight;
            double o = Math.Round(1 - Math.Abs(x - y) / z, 2);
            return o.ToString("P");
        }

        private string getshippower()
        {
            double totalp = s.totalPower /(double)s.battles;
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

        private string gettypebyenglissh(string type)
        {
            switch (type)
            {
                case "Cruiser":
                    return "巡洋舰 CL/CA";
                case "Destroyer":
                    return "驱逐舰 DD";
                case "Battleship":
                    return "战列舰 BB";
                case "AirCarrier":
                    return "航母 CV";
                default:
                    return type;
            }
        }

        private void textBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(dayinfo), i);
        }
    }
}
