using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOWS_UWP
{
    class timehelper
    {
        /// <summary>
     /// 时间戳转为C#格式时间
     /// </summary>
     /// <param name="timeStamp">Unix时间戳格式</param>
     /// <returns>C#格式时间</returns>
        public static string GetTime(insertdate i)
        {
            return (i.year + 1900).ToString() + "-" + (i.month + 1).ToString() + "-" + i.date.ToString();
        }
        public static string GetTime(updatedate i)
        {
            return (i.year + 1900).ToString() + "-" + (i.month + 1).ToString() + "-" + i.date.ToString();
        }
    }
}
