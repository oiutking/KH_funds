using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace kaihong_funds
{
    public partial class ValCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code ="";            
            Random rd = new Random();
            code += rd.Next(1000, 9999);
            Session["valcode"] = code;          
            Bitmap bmp = new Bitmap(80,30);
            MemoryStream MS = null;
            Graphics G = Graphics.FromImage(bmp);
            G.Clear(Color.BlanchedAlmond);
            G.DrawString(code, new Font("宋体", 22), new SolidBrush(Color.SlateGray), 0, 0);
            MS = new MemoryStream();
            bmp.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.ContentType = "image/Jpeg";
            Response.BinaryWrite(MS.ToArray());
        }
    }
}