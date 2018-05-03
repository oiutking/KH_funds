using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class AdminKEY : System.Web.UI.Page
    {
        private publicClass.key _key;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startup();
            }

        }

        protected void startup()
        {
            string cmd_u_list = "select * from uer";
            string cmd_k_list = "select * from [key]";
            publicClass.Dosql ds = new publicClass.Dosql();
            ds.DoRe(cmd_k_list);
            foreach(DataRow r in ds.DtOut.Rows)
            {
                ListItem lt = new ListItem(r[4].ToString(), r[0].ToString());
                this.KEY_list.Items.Add(lt);
            }
            ds = new publicClass.Dosql();
            ds.DoRe(cmd_u_list);
            foreach (DataRow r in ds.DtOut.Rows)
            {
                ListItem lt = new ListItem(r[2].ToString(), r[0].ToString());
                this.u_list.Items.Add(lt);
            }

        }

        protected void search_text_btn_Click(object sender, EventArgs e)
        {
            KEY_list.ClearSelection();
            foreach(ListItem it in KEY_list.Items)
            {
                if(it.Text.IndexOf(key_name_txtb.Text,0)>=0)
                {
                    it.Selected = true;
                    return;
                }
            }
        }

        protected void ser_uer_btn_Click(object sender, EventArgs e)
        {
            u_list.ClearSelection();
            foreach (ListItem it in u_list.Items)
            {
                if (it.Text.IndexOf(ser_uer_txt.Text, 0) >= 0)
                {
                    it.Selected = true;
                    return;
                }
            }
        }

        protected void KEY_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            _key = new publicClass.key(Convert.ToInt32(KEY_list.SelectedValue),1);
            if (_key.State)
            { this.state.SelectedIndex = 0; }
            else
            { this.state.SelectedIndex = 1; }
            u_list.ClearSelection();
            foreach(ListItem it in u_list.Items)
            {
                if(it.Value==_key.Uer_id.ToString())
                {
                    it.Selected=true;
                }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                _key = new publicClass.key(Convert.ToInt32(KEY_list.SelectedValue), 1);
                _key.State = state.SelectedValue == "0" ? false : true;
                _key.Uer_id = Convert.ToInt32(this.u_list.SelectedValue);
                _key.save();
                startup();
            }
            catch
            {

            }
        }
    }
}