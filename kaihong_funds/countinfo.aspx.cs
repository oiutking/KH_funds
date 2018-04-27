using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kaihong_funds
{
    public partial class countinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startup();
            }
        }


        protected void startup()
        {
            try
            {
                string where_str = Session["countinfo_wherestr"].ToString();
                where_str += " and isfiled =1";
                string cds = "select count(*) from bill where bill_type=1 " + where_str;
                string cdhj = "select (case when sum(amount) is null then 0 else sum(amount) end) from bill where bill_type=1" + where_str;
                string zps = "select count(*) from bill where bill_type=2" + where_str;
                string zphj = "select (case when sum(amount) is null then 0 else sum(amount) end) from bill where bill_type=2" + where_str;
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cds);
                info.Text = string.Format("统计区间内共有，存单{0}张，存款合计", ds.DtOut.Rows[0][0].ToString());
                ds = new publicClass.Dosql();
                ds.DoRe(cdhj);
                info.Text += (ds.DtOut.Rows[0][0].ToString() + "元；");
                ds = new publicClass.Dosql();
                ds.DoRe(zps);
                info.Text += ("支票" + ds.DtOut.Rows[0][0].ToString() + "张，");
                ds = new publicClass.Dosql();
                ds.DoRe(zphj);
                info.Text += ("支取金额" + ds.DtOut.Rows[0][0].ToString()+ "元。");

                info_table.Text = info.Text;
                
                string cmd = "select * from bill where 1=1" + where_str;
                cmd = "select a.*, b.dep_name from (" + cmd + ") a left join dep b on a.payfrom=b.dep_id";
                cmd = "select c.*, d.no from (" + cmd + ") c left join depno d on c.payfrom_no=d.no_id";
                cmd = "select e.* ,f.edep_name,f.edep_no from (" + cmd + ") e left join exc_dep f on e.payto=f.edep_id order by e.bill_id asc";
                ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                this.list.DataSource = ds.DtOut;
                this.list.DataBind();
            }
            catch
            { }

        }

        protected void ref_Click(object sender, EventArgs e)
        {
            startup();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("showcount.aspx");
        }
    }
}