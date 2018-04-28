using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public static class calljs
    {
        public static void alert(System.Web.UI.Page p, String str)
        {
            string js = "<script type='text/javascript'>";
            
            js += "$.myAlert('"+str+"')";
            js += "</script>";
             p.ClientScript.RegisterStartupScript(p.GetType(), "myscript", js);
        }
    }
}