using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class sigadmin : System.Web.UI.Page
    {
        private string list_str;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sigadmin_list"] == null)
            {
                list_str = "select * from sig";
            }
            else
            {
                list_str = Session["sigadmin_list"].ToString();
            }
            if(!IsPostBack)
            {
                creat_sig_list();
                creat_dep_list();
            }
           
        }

        protected void creat_dep_list()
        {
            string cmd;
            if (Session["sigadmin_deplist_cmd"]==null)
            {
                cmd = "select * from dep";
            }
            else
            {
                cmd = Session["sigadmin_deplist_cmd"].ToString();
            }
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

        protected void creat_sig_list()
        {
            this.sig_list.Items.Clear();
            try
            {

                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(list_str);
                if (ds.Sqled)
                {
                    foreach (DataRow r in ds.DtOut.Rows)
                    {
                        ListItem it = new ListItem(r["sig_name"].ToString(), r["sig_id"].ToString());
                        sig_list.Items.Add(it);
                    }

                }


            }
            catch (Exception ex)
            { }

        }

        protected void sig_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            publicClass.sig sig = new publicClass.sig(Convert.ToInt32(this.sig_list.SelectedValue));
            this.Image1.ImageUrl = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/sigimg.aspx?id=" + this.sig_list.SelectedValue;
            foreach(ListItem i in state.Items)
            {
                if(i.Value==(sig.State==true?"1":"0"))
                {
                    i.Selected = true;
                }
                else
                {
                    i.Selected = false;
                }
            }
            foreach (ListItem i in lvl.Items)
            {
                if (i.Value == sig.Lvl.ToString())
                {
                    i.Selected = true;
                }
                else
                {
                    i.Selected = false;
                }
            }
            foreach (ListItem i in dep_list.Items)
            {
                if (i.Value == sig.Dep_id.ToString())
                {
                    i.Selected = true;
                }
                else
                {
                    i.Selected = false;
                }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("update sig set dep_id = {0},[state]={1},lvl = {2} where sig_id ={3}" , this.dep_list.SelectedValue, this.state.SelectedValue, this.lvl.SelectedValue,this.sig_list.SelectedValue);
                publicClass.Dosql ds = new publicClass.Dosql();
                publicClass.DS_input ip = new publicClass.DS_input();
                ip._cmd = cmd;
                ip._par_name = new string[] { };
                ip._par_type = new SqlDbType[] { };
                ip._par_val = new object[] { };
                ds.DoNoRe(new publicClass.DS_input[] { ip });
            }
            catch
            {

            }

        }
    }
}