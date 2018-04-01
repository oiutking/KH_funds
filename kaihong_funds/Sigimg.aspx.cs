using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace kaihong_funds
{
    public partial class Sigimg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sigid;
            if (Request.QueryString["id"]!=null)
            {
                sigid = Request.QueryString["id"].ToString();
            }
            else
            {
                sigid = "1";
            }
            
            publicClass.sig sig = new publicClass.sig(Convert.ToInt32(sigid));
            MemoryStream ms = new MemoryStream(); 
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(publicClass.Sigformat.ToImage(sig.Sig_word));
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/gif";
            Response.BinaryWrite(ms.ToArray());
        }
    }
}