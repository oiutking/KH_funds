using System;
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
            uer.Upsw = "web_test";
            uer.Uname = "web_test_name";
            uer.Uno = "web_test_no";
            uer.Udep_id = 123;
            uer.Ustate = false;
            uer.Ulvl = 6;
            uer.Save();


        }
    }
}