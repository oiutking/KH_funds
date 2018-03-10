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
        public publicClass.Uer Uer = new publicClass.Uer();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if((Session["login"]==null?"not": Session["login"].ToString())=="not")
            {
                Session["logout"] = "登录校验错误，请重新登录！";
                Response.Redirect("login.aspx");
            }
            int id = Convert.ToInt32(Session["uer_id"] == null ? -1 : Session["uer_id"]);
            publicClass.Uer uer = new publicClass.Uer(id);
            if (uer.Uexsit)
            {
                this.uer_name.Text = uer.Uname;
                publicClass.Dep dep = new publicClass.Dep(uer.Udep_id);
                this.dep_name.Text = dep.DeName;
                this.lg_date.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                Uer = uer;
            }


        }

        protected void quit_Click(object sender, EventArgs e)
        {
            Session["login"] = "not";
            Session["uer_id"] = "-1";
            Session["logout"] = "用户退出！";
            Response.Redirect("login.aspx");
        }
    }
}