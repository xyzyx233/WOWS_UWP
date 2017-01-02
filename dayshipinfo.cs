using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOWS_UWP
{
    public class dayshipinfo
    {
        public int teambattles { get; set; }
        public int killplane { get; set; }
        public int teamewins { get; set; }
        public int alive { get; set; }
        public ID id { get; set; }
        public int killship { get; set; }
        public int damagecv { get; set; }
        public int capture { get; set; }
        public int damagedd { get; set; }
        public int draws { get; set; }
        public int defensep { get; set; }
        public double teamPower { get; set; }
        public int defense { get; set; }
        public double totalPower { get; set; }
        public int damage { get; set; }
        public double winPower { get; set; }
        public int damagefire { get; set; }
        public int damageshot { get; set; }
        public int exp { get; set; }
        public int damagebb { get; set; }
        public insertdate insert_date { get; set; }
        public int damageflood { get; set; }
        public int damageca { get; set; }
        public int battles { get; set; }
        public int capturep { get; set; }
        public int wins { get; set; }
    }
    public class insertdate
    {
        public int nanos { get; set; }
        public Int64 time { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int hours { get; set; }
        public int month { get; set; }
        public int timezoneOffset { get; set; }
        public int year { get; set; }
        public int day { get; set; }
        public int date { get; set; }
    }
    public class ID
    {
        public string vehicleTypeCd { get; set; }
        public string accountDbId { get; set; }
        public int battleTypeId { get; set; }
    }
}
