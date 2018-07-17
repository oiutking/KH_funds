using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Userid
{
    public partial class checkid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string  info="";
            try
            {
                string a = Request.Form["a"];
                string[] strs = a.Split(',');
                string base64 = strs[1];
                byte[] img = Sigformat.Toms(base64).ToArray();
                string apid = "iDZMn726zfMz8tTuvA18P6Fu";
                string secretid = "PUjq7PCLMxme2wFu6st8NNZmQAG8guVZ";
                Baidu.Aip.Ocr.Ocr client = new Baidu.Aip.Ocr.Ocr(apid, secretid);
                client.Timeout = 6000;
                string idside = "front";
                var options = new Dictionary<string, object>{
                            {"detect_direction", "false"},
                            { "detect_risk","true"} };
                var res = client.Idcard(img, idside, options);
                if (res["error_code"] is null)
                {
                    
                    string str = "姓名:" + res["words_result"]["姓名"]["words"].ToString();
                    str += "<br>证件号码:" + res["words_result"]["公民身份号码"]["words"].ToString();
                    str += "<br>证件类型:" + res["risk_type"].ToString();
                    info = str;
                }
                else
                {
                    info = "照片内容错误！";
                }
            }
            catch
            {
                info = "内部处理错误！";
            }
            Response.Write(info);
            Response.End();
            Response.Flush();
        }
    }
}