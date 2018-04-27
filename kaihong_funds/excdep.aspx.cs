using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



namespace kaihong_funds
{
    public partial class excdep : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["edep_list"] = "";          
                this.new_dep_div.Visible = false;
            }


        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(this.headbar.Uer.Ulvl == 7 ? true : false);

            list(Session["edep_list"].ToString());
        }

        private void list(string cmd)
        {
            string cmdstr = cmd == "" ? "select * from exc_dep where dep_id =" + this.headbar.Uer.Udep_id +"order by edep_id desc": cmd;
            DataTable listdata = new DataTable();
            publicClass.Dosql ds = new publicClass.Dosql();
            ds.DoRe(cmdstr);
            if (ds.Sqled)
            {
                this.Repeater1.DataSource = ds.DtOut;
                this.Repeater1.DataBind();
            }
            
        }

        protected void stop_Command(object sender, CommandEventArgs e)
        {


            
    
        }

        protected void newdep_Click(object sender, EventArgs e)
        {
            
            this.list_tab.Visible = false;
            this.new_dep_div.Visible = true;
            this.ErrStr.Text = "";
            this.ymbt.Text = "新建单位";
            this.edep_name.Text = this.edep_no.Text = this.summary.Text = "";
        }

        protected void cancelnew_Click(object sender, EventArgs e)
        {
            this.list_tab.Visible = true;
            this.new_dep_div.Visible = false;
            this.ymbt.Text = "往来单位列表";

        }

        protected void savenew_Click(object sender, EventArgs e)
        {
            try
            {
                publicClass.exc_dep edep = new publicClass.exc_dep();
                edep.Edep_name = this.edep_name.Text.Length==0?null:edep_name.Text;
                edep.Edep_no = this.edep_no.Text.Length==0?null: edep_no.Text;
                edep.Summary = this.summary.Text.Length==0?null: summary.Text;
                edep.Dep_id = this.headbar.Uer.Udep_id;
                edep.State = false;
                edep.Save();
                list(Session["edep_list"].ToString());
                this.list_tab.Visible = true;
                this.new_dep_div.Visible = false;
                this.ymbt.Text = "往来单位列表";
                this.edep_name.Text = "";
                this.edep_no.Text = "";
                this.summary.Text = "";

            }
            catch
            {
                this.ErrStr.Text = "新建单位失败,请确认填写无误！";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["edep_list"] = "select * from exc_dep where edep_name like '%" + search.Text + "%'or edep_no like '%"+ search.Text + "%' order by edep_id desc";

        }

        protected void ref_Click(object sender, EventArgs e)
        {
            Session["edep_list"] = "";
            search.Text = "";
        }

        protected void stop_Click(object sender, EventArgs e)
        {
            Boolean bit = ((Button)sender).Text == "停用" ? false : true;
            string cmd = "update exc_dep set state = @state where edep_id = @edep_id";
            publicClass.DS_input input = new publicClass.DS_input();
            input._cmd = cmd;
            input._par_name = new string[] { "@state", "@edep_id" };
            input._par_type = new SqlDbType[] { SqlDbType.Bit, SqlDbType.BigInt };
            input._par_val = new object[] { bit, ((Button)sender).CommandArgument };
            publicClass.Dosql dosql = new publicClass.Dosql();
            dosql.DoNoRe(new publicClass.DS_input[] { input });
        }
    }
}