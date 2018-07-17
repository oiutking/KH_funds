using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace Userid
{
    public class get_access_token
    {
        string API_key = "iDZMn726zfMz8tTuvA18P6Fu";
        string Secret_key = "PUjq7PCLMxme2wFu6st8NNZmQAG8guVZ";

        public string Get_access_token()
        {
            
            try
            {
                string URL = string.Format("https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id={0}&client_secret={1}", API_key, Secret_key);
                var client = new HttpClient();
                var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("LoginName", "365admin"), new KeyValuePair<string, string>("Password", "fob123") });
                var result = client.PostAsync(URL, content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                return resultContent;
            }
            catch
            {
                return "";
            }

        }
       
    }



}