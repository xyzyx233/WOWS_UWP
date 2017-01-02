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
        private Shipinfo s;
        public shipbattledetail()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            s = (Shipinfo)e.Parameter;
            shipname.Text = Ships.getshipinfo(s.id.vehicleTypeCd).alias;
            englishname.Text = Ships.getshipinfo(s.id.vehicleTypeCd).name;
            type.Text = gettypebyenglissh(Ships.getshipinfo(s.id.vehicleTypeCd).type);
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
    }
}
