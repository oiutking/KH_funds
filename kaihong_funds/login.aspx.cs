using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kaihong_funds
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ok_Click(object sender, EventArgs e)
        {
            if (this.valcode_input.Text!=Session["valcode"].ToString())
            {
                this.warning.Text = "验证码输入错误，请重试！";
                this.warning.ForeColor = System.Drawing.Color.Sienna;
            }
            else
            {
                this.warning.Text = "";
               
            }
        }

        protected void Valcode_Click(object sender, ImageClickEventArgs e)
        {
            this.Valcode.ImageUrl = "ValCode.aspx";
        }
    }
}