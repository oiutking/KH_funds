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
                string cmd_minfo = "select * from m_info wheredep_id=" + _uer.Udep_id + "and m_date_word like '" + m_state + "'";
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
                    in_dr["state"]=dr["state"].ToString()=="1"?"启用":"停用";
                }

            }
            catch
            {

            }
        }
    }
}