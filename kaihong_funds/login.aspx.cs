using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace kaihong_funds
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["logout"]!=null )
            {
                this.warning.Text = Session["logout"].ToString();
            }

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ok_Click(object sender, EventArgs e)
        {
            if (this.valcode_input.Text!=Session["valcode"].ToString())
            {
                this.warning.Text = "验证码输入错误，请重试！";
                
            }
            else
            {
                this.warning.Text = "";
                DataTable temp = new DataTable();
                
                string cmdstr = "select uer_id from uer where 1=1 and uer_no like '" + this.uer_no.Text + "'";
                try
                {
                    publicClass.Dosql ds = new publicClass.Dosql();
                    ds.DoRe(cmdstr);
                    if (ds.Sqled)
                    {
                        temp = ds.DtOut;
                        publicClass.Uer _uer = new publicClass.Uer(Convert.ToInt32(temp.Rows[0][0]));
                        if (this.uer_psw.Text.Equals(_uer.Upsw))
                        {
                            Session["uer_id"] = _uer.Uid;
                            Session["login"] = "ok";
                            Response.Redirect("index.aspx");
                        }
                        else
                        {
                            throw new Exception("psw wrong");
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }

                   
                }
                catch(Exception ex)
                {
                    this.warning.Text = "登录信息有误，请核对！" + ex.Message;
                }


               
            }
        }

        protected void Valcode_Click(object sender, ImageClickEventArgs e)
        {
            this.Valcode.ImageUrl = "ValCode.aspx";
        }
    }
}