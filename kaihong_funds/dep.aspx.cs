using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class dep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["depno_list"] = "";
                this.new_dep_div.Visible = false;
                this.ymbt.Text = "部门账号列表";
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(this.headbar.Uer.Ulvl == 7 ? true : false);
            list(Session["depno_list"].ToString());
        }

        protected void list(string cmd)
        {
            string cmdstr = cmd == "" ? "select * from depno where dep_id =" + this.headbar.Uer.Udep_id + "order by no_id desc" : cmd;
            DataTable listdata = new DataTable();
            publicClass.Dosql ds = new publicClass.Dosql();
            ds.DoRe(cmdstr);
            if (ds.Sqled)
            {
                this.Repeater1.DataSource = ds.DtOut;
                this.Repeater1.DataBind();
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            this.new_dep_div.Visible = false;
            this.list_tab.Visible = true;
            this.ymbt.Text = "部门账号列表";
        }

        protected void newdep_Click(object sender, EventArgs e)
        {
            this.new_dep_div.Visible = true;
            this.list_tab.Visible =false;
            this.ymbt.Text = "新建账号";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["depno_list"] = "select * from depno where no_name like '%"+search.Text+"%' or no like '%"+search.Text + "%' order by no_id desc" ;
        }

        protected void ref_Click(object sender, EventArgs e)
        {
            Session["depno_list"] = "";
            search.Text = "";
        }

        protected void stop_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean bit = ((Button)sender).Text == "停用" ? false : true;
                publicClass.DS_input inp = new publicClass.DS_input();
                inp._cmd = "update depno set state=@state where no_id =@no_id";
                inp._par_name = new string[] { "@state", "@no_id" };
                inp._par_type = new SqlDbType[] { SqlDbType.Bit, SqlDbType.BigInt };
                inp._par_val = new object[] { bit, ((Button)sender).CommandArgument };
                publicClass.Dosql dosql = new publicClass.Dosql();
                dosql.DoNoRe(new publicClass.DS_input[] { inp });

            }
            catch
            {

            }
        }

        protected void savenew_Click(object sender, EventArgs e)
        {
            try
            {
                publicClass.DS_input inp = new publicClass.DS_input();
              
                inp._cmd = "insert into  depno values (@no_name,@no,@state,@dep_id,@summary)";
                inp._par_name = new string[] { "@no_name", "@no","@state","@dep_id","@summary" };
                inp._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text,SqlDbType.Bit,SqlDbType.BigInt,SqlDbType.Text };
                inp._par_val = new object[] { this.no_name.Text, no.Text,false,this.headbar.Uer.Udep_id,summary.Text };
                publicClass.Dosql dosql = new publicClass.Dosql();
                dosql.DoNoRe(new publicClass.DS_input[] { inp });
                this.new_dep_div.Visible = false;
                this.list_tab.Visible = true;
                this.no_name.Text = "";
                this.no.Text = "";
                this.summary.Text = "";
                this.ymbt.Text = "部门账号列表";
            }
            catch
            {
                this.ErrStr.Text = "新建账号失败,请确认填写无误！";
            }
        }
    }
}