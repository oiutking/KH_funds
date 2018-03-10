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
          



        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(this.headbar.Uer.Ulvl == 7 ? true : false);
            list("");
        }

        private void list(string cmd)
        {
            string cmdstr = cmd == "" ? "select * from exc_dep where dep_id =" + this.headbar.Uer.Udep_id : cmd;
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

            Boolean bit = ((Button)sender).Text == "停用" ? false : true;
            string cmd = "update exc_dep set state = @state where edep_id = @edep_id";
            publicClass.DS_input input = new publicClass.DS_input();
            input._cmd = cmd;
            input._par_name = new string[] { "@state", "@edep_id" };
            input._par_type = new SqlDbType[] { SqlDbType.Bit, SqlDbType.BigInt };
            input._par_val = new object[] { bit,e.CommandArgument };
            publicClass.Dosql dosql = new publicClass.Dosql();
            dosql.DoNoRe(new publicClass.DS_input[]{ input});
            list("");
    
        }
    }
}