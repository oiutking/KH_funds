using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class Mstate : System.Web.UI.Page
    {
        private publicClass.Uer _uer;
        private publicClass.Dep _dep;
        private string m_state;
        int[] temp;
        protected void Page_Load(object sender, EventArgs e)
        {
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
            _dep = new publicClass.Dep(_uer.Udep_id);
            creat_summary();
            creat_info_list();
        }

        protected void creat_summary()
        {
            try
            {
                string cmd = "select top 1 m_date_word from m_state where m_dep_id=" + _uer.Udep_id + "order by m_s_id desc";
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                string done = "";
                if (ds.Sqled && ds.DtOut.Rows.Count == 1)
                {
                    m_state = ds.DtOut.Rows[0][0].ToString();
                    temp = new int[]{ Convert.ToInt16(m_state.Split('-')[0]), Convert.ToInt16(m_state.Split('-')[1]) };
                    done = string.Format("本部门已经月结至{0}年{1}月,当前操作账期为{2}年{3}月", temp[0], temp[1], temp[1] == 12 ? temp[0] + 1 : temp[0], temp[1] == 12 ? 1 : temp[1] + 1);
                }
                this.summary.Text = done;
            }
            catch
            {
                this.summary.Text = "调取日结状态出错！";
            }
               
        }

        protected void creat_info_list()
        {
            try
            {
                string cmd_pde_no_list="select * from depno where dep_id="+_uer.Udep_id;
                string cmd_minfo = "select * from m_info where dep_id=" + _uer.Udep_id + "and m_date_word like '" + m_state + "'";
                publicClass.Dosql ds = new publicClass.Dosql();
                DataTable dt_dep_no_list,dt_out,dt_minfo;
                ds.DoRe(cmd_pde_no_list);
                dt_dep_no_list = ds.DtOut;
                ds = new publicClass.Dosql();
                ds.DoRe(cmd_minfo);
                dt_minfo = ds.DtOut;
                dt_out = new DataTable();
                dt_out.Columns.Add("no_id");
                dt_out.Columns.Add("no");
                dt_out.Columns.Add("state");
                dt_out.Columns.Add("m_date_word");
                dt_out.Columns.Add("qcye");
                dt_out.Columns.Add("bqsr");
                dt_out.Columns.Add("bqzc");
                dt_out.Columns.Add("qmye");
                foreach(DataRow dr in dt_dep_no_list.Rows)
                {
                    DataRow in_dr = dt_out.NewRow();
                    in_dr["no_id"] = dr["no_id"];
                    in_dr["no"] = dr["no"];
                    in_dr["state"]=Convert.ToBoolean( dr["state"])?"启用":"停用";
                    in_dr["m_date_word"] = (temp[1] == 12 ? temp[0] + 1 : temp[0]).ToString() + "-" + (temp[1] == 12 ? 1 : temp[1] + 1).ToString();
                    DataRow[] r = dt_minfo.Select("no_id="+ dr["no_id"]);
                    if (r.Length == 0)
                    {
                        in_dr["qcye"] = "0";
                        
                    }
                    else
                    {
                        in_dr["qcye"] = r[0][8].ToString();
                       
                    }
                    publicClass.MSE mse = new publicClass.MSE(Convert.ToDateTime((temp[1] == 12 ? temp[0] + 1 : temp[0]).ToString() + "-" + (temp[1] == 12 ? 1 : temp[1] + 1).ToString()+"-25"));
                    string cmd_bqsr =string.Format("select sum(amount) from bill where payfrom={0} and payto=-1 and isfiled =1 and make_date between '{1}' and '{2}' and payfrom_no = {3}",_uer.Udep_id,mse.S,mse.E, dr["no_id"]);
                    string cmd_bqzc = string.Format("select sum(amount) from bill where payfrom={0} and payto<>-1 and isfiled =1 and make_date between '{1}' and '{2}' and payfrom_no = {3}", _uer.Udep_id, mse.S, mse.E, dr["no_id"]);
                    ds = new publicClass.Dosql();
                    ds.DoRe(cmd_bqsr);
                    in_dr["bqsr"] = ds.DtOut.Rows[0][0].ToString() == ""? "0" : ds.DtOut.Rows[0][0].ToString(); 
                    ds = new publicClass.Dosql();
                    ds.DoRe(cmd_bqzc);
                    in_dr["bqzc"] = ds.DtOut.Rows[0][0].ToString() == "" ? "0" : ds.DtOut.Rows[0][0].ToString();
                    in_dr["qmye"] = Convert.ToDecimal(in_dr["bqsr"]) + Convert.ToDecimal(in_dr["qcye"]) - Convert.ToDecimal(in_dr["bqzc"]);
                    dt_out.Rows.Add(in_dr);
                }
                this.m_info.DataSource = dt_out;
                this.m_info.DataBind();
            }
            catch(Exception ex)
            {

            }
        }
    }
}