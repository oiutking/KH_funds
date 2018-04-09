using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class useradmin : System.Web.UI.Page
    {
        protected string user_list_str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                creat_user_list();
                creat_dep_list();
            }

        }

        protected void creat_user_list()
        {
            this.user_list.Items.Clear();
            if (Session["admin_user_list_str"] == null)
            {
                user_list_str = "select * from [uer]";
            }
            else
            {
                user_list_str = Session["admin_user_list_str"].ToString();
            }

            try
            {
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(user_list_str);
                if (ds.Sqled)
                {
                    foreach (DataRow r in ds.DtOut.Rows)
                    {
                        ListItem it = new ListItem(r["uer_name"].ToString() + "(" + r["uer_no"].ToString() + ")", r["uer_id"].ToString());
                        this.user_list.Items.Add(it);
                    }
                }

            }
            catch
            {

            }
        }

        protected void search_text_btn_Click(object sender, EventArgs e)
        {
            Session["admin_user_list_str"] = string.Format("select * from [uer] where uer_name like '%{0}%' or uer_no like '%{1}%'", user_name_txtb.Text, user_name_txtb.Text);
            creat_user_list();
        }

        protected void ref_btn_Click(object sender, EventArgs e)
        {
            Session["admin_user_list_str"] = null;
            creat_user_list();
        }

        protected void user_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lvl.SelectedIndex = -1;
                dep_list.SelectedIndex = -1;
                state.SelectedIndex = -1;
                publicClass.Uer uer = new publicClass.Uer(Convert.ToInt32(this.user_list.SelectedValue));
                foreach (ListItem i in dep_list.Items)
                {
                    if (i.Value == uer.Udep_id.ToString())
                    {
                        i.Selected = true;
                    }
                    else
                    {
                        i.Selected = false;
                    }
                }
                if (uer.Ustate)
                {
                    state.SelectedIndex = 0;
                }
                else
                {
                    state.SelectedIndex = 1;
                }
                foreach (ListItem i in lvl.Items)
                {
                    if (i.Value == uer.Ulvl.ToString())
                    {
                        i.Selected = true;
                    }
                    else
                    {
                        i.Selected = false;
                    }
                }
                this.psw_txt.Text = uer.Upsw;

            }
            catch
            {

            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                publicClass.Uer uer = new publicClass.Uer(Convert.ToInt32(user_list.SelectedValue));
                uer.Upsw = psw_txt.Text;
                uer.Ulvl = Convert.ToInt32(this.lvl.SelectedValue);
                uer.Ustate = this.state.SelectedValue=="0"?false:true;
                uer.Udep_id = Convert.ToInt32(this.dep_list.SelectedValue);
                uer.Save();
            }
            catch (Exception ex)
            {

            }
        }

        protected void creat_dep_list()
        {
            string cmd = "select * from dep";
            try
            {
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    foreach (DataRow r in ds.DtOut.Rows)
                    {
                        ListItem it = new ListItem(r["dep_name"].ToString(), r["dep_id"].ToString());
                        dep_list.Items.Add(it);
                    }

                }
            }
            catch
            {

            }
        }

        protected void newuser_Click(object sender, EventArgs e)
        {
            try
            {
                publicClass.Uer _uer = new publicClass.Uer();
                string[] tep_name = user_name_txtb.Text.Substring(0, user_name_txtb.Text.Length - 1).Split('(');
                _uer.Uname = tep_name[0];
                _uer.Uno = tep_name[1];
                _uer.Upsw = psw_txt.Text;
                _uer.Udep_id = Convert.ToInt32(dep_list.SelectedValue);
                _uer.Ustate = state.SelectedValue == "1" ? true : false;
                _uer.Ulvl = Convert.ToInt32(lvl.SelectedValue);
                _uer.Save();              
            }
            catch
            {

            }
            finally
            {
                Session["admin_user_list_str"] = null;
                creat_dep_list();
                psw_txt.Text = "";
                user_name_txtb.Text = "";
            }

        }
    }
}