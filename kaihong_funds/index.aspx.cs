using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kaihong_funds
{
    public partial class index1 : System.Web.UI.Page
    {
        private publicClass.Uer _uer;
        private publicClass.Dep _dep;

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(this.headbar.Uer.Ulvl == 7 ? true : false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
                _dep = new publicClass.Dep(_uer.Udep_id);
                string cmd_yj = "select top 1 m_date_word from m_state where 1=1 and m_dep_id= " + _uer.Udep_id + "order by m_s_id desc";
                publicClass.MSE mse = new publicClass.MSE(DateTime.Now);
                string cmd_bysr = string.Format("select case when sum(amount) is null then 0 else sum(amount) end  from bill where bill_type=1 and isfiled =1 and make_date between '{0}' and '{1}'", mse.S, mse.E);
                string cmd_byzc = string.Format("select case when sum(amount) is null then 0 else sum(amount) end  from bill where bill_type=2 and isfiled =1 and make_date between '{0}' and '{1}'", mse.S, mse.E); ;
                string cmd_zyzh = "select count(*) from depno where 1=1 and state=1";
                string cmd_wldw = "select count(*) from exc_dep where 1=1 and state=1";
                string cmd_dy = "select count(*) from bill where isfiled=1 and prnt=0";
                string cmd_sp = "select count(*) from bill where op=" + _uer.Ulvl;
                string cmd_gd = "select count(*) from bill where op=5 and isfiled =0";
                string str_where = " and dep_id= " + _uer.Udep_id;
                if (_uer.Ulvl <= 2)
                {
                    cmd_bysr += " and payfrom = "+ _uer.Udep_id;
                    cmd_byzc += " and payfrom =" + _uer.Udep_id;
                    cmd_zyzh += str_where;
                    cmd_wldw += str_where; ;
                    cmd_dy += " and payfrom = " + _uer.Udep_id;
                    cmd_sp += " and payfrom = " + _uer.Udep_id;
                    cmd_gd += " and payfrom = " + _uer.Udep_id;
                }
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd_yj);
                yj_lab.Text = ds.DtOut.Rows[0][0].ToString();
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_bysr);
                bysr_lab.Text= ds.DtOut.Rows[0][0].ToString();
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_byzc);
                byzc_lab.Text = ds.DtOut.Rows[0][0].ToString();
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_zyzh);
                zyzh_lab.Text = ds.DtOut.Rows[0][0].ToString();
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_wldw);
                wldw_lab.Text = ds.DtOut.Rows[0][0].ToString();
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_dy);
                dy_lab.Text = ds.DtOut.Rows[0][0].ToString();
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_sp);
                sp_lab.Text = ds.DtOut.Rows[0][0].ToString();
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_gd);
                gd_lab.Text = ds.DtOut.Rows[0][0].ToString();
                dbsx_lal.Text=(Convert.ToInt32(sp_lab.Text)+Convert.ToInt32(dy_lab.Text)+ Convert.ToInt32(gd_lab.Text)).ToString();
                sz_lab.Text = (Convert.ToDecimal(bysr_lab.Text) - Convert.ToDecimal(byzc_lab.Text)).ToString();
                sp_img.Text = string.Format("<div class='bar' style='width:{0}%';></div>", (Convert.ToInt16(sp_lab.Text) * 100 / Convert.ToInt16(dbsx_lal.Text)).ToString());
                gd_img.Text = string.Format("<div class='bar' style='width:{0}%';></div>", (Convert.ToInt16(gd_lab.Text) * 100 / Convert.ToInt16(dbsx_lal.Text)).ToString());
                dy_img.Text = string.Format("<div class='bar' style='width:{0}%';></div>", (Convert.ToInt16(dy_lab.Text) * 100 / Convert.ToInt16(dbsx_lal.Text)).ToString());
            }
            catch (Exception ex)
            {

            }
        }

    }
}
   