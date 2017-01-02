using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace WOWS_UWP
{
    class httphelper
    {
        private userinfo user = null;
        public async Task<string> GetLogininfo(string username,string zone)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://rank.kongzhong.com/Data/action/WowsAction/getLogin?name="+username+"&zone="+zone);
                    if (response.EnsureSuccessStatusCode().StatusCode.ToString().ToLower() == "ok")
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        if (responseBody.Contains("errno"))
                            return "error information!";
                        user = JSONhelper.DeserializeJsonToObject<userinfo>(responseBody);
                    }
                    return user.account_db_id;
                }
                catch (HttpRequestException ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    return "";
                }
            }
        }
        public async Task<List<dayshipinfo>> Getdayshipinfo()
        {
            List<dayshipinfo> r=null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://rank.kongzhong.com//Data/action/WowsAction/getDayInfo?aid="+user.account_db_id);
                    if (response.EnsureSuccessStatusCode().StatusCode.ToString().ToLower() == "ok")
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        r = JSONhelper.DeserializeJsonToList<dayshipinfo>(responseBody);
                    }
                    return r;
                }
                catch (HttpRequestException ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    return null;
                }
            }
        }
        //http://rank.kongzhong.com/Data/action/WowsAction/getShipInfo?aid=1825623712
        public async Task<List<Shipinfo>> Getallshipinfo()
        {
            List<Shipinfo> r = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://rank.kongzhong.com/Data/action/WowsAction/getShipInfo?aid=" + user.account_db_id);
                    if (response.EnsureSuccessStatusCode().StatusCode.ToString().ToLower() == "ok")
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        r = JSONhelper.DeserializeJsonToList<Shipinfo>(responseBody);
                    }
                    return r;
                }
                catch (HttpRequestException ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                    return null;
                }
            }
        }
    }

}
