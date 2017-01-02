using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOWS_UWP
{
    public class info
    {
        public string name { get; set; }
        public string ID { get; set; }
        public string zone { get; set; }
        public List<dayshipinfo> dayinfo {get;set;}
        public List<Shipinfo> allshipinfo { get; set; } 
    }
}
