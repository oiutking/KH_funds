﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kaihong_funds.publicHTML
{
    public partial class headbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            publicClass.Uer uer = new publicClass.Uer();


            if (uer.Uexsit && uer.Ustate)
            {
                
                Response.Redirect("http://www.hao123.com", false);
            }
        }
    }
}