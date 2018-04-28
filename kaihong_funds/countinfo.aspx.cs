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
                int cds_int, zps_int;
                decimal ckhj_je, zphj_je;
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cds);
                cds_int=Convert.ToInt16( ds.DtOut.Rows[0][0].ToString());
                ds = new publicClass.Dosql();
                ds.DoRe(cdhj);
                ckhj_je=Convert.ToDecimal( ds.DtOut.Rows[0][0]);
                ds = new publicClass.Dosql();
                ds.DoRe(zps);
                zps_int= Convert.ToInt16(ds.DtOut.Rows[0][0].ToString());
                ds = new publicClass.Dosql();
                ds.DoRe(zphj);
                zphj_je= Convert.ToDecimal(ds.DtOut.Rows[0][0]);

                info_table.Text = string.Format("当前汇总区间内包含：<br>存单{0}张，存款金额合计{1}元；<br>支票{2}张，支出金额合计{3}元；<br>收支合计余额{4}元。",cds_int,ckhj_je,zps_int,zphj_je,ckhj_je,ckhj_je-zphj_je);
                
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