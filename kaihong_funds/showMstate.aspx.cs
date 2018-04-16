using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kaihong_funds
{
    public partial class showMstate : System.Web.UI.Page
    {
        publicClass.Uer _uer;
        protected void Page_Load(object sender, EventArgs e)
        {
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
            if (!IsPostBack)
            {
                creat_year_list(DateTime.Now.Year);
                Mstateinfo(DateTime.Now.Year);
            }
        }

        protected void years_SelectedIndexChanged(object sender, EventArgs e)
        {
            creat_year_list(Convert.ToInt32(years.SelectedValue));
            Mstateinfo(Convert.ToInt32(years.SelectedValue));
        }

        protected void creat_year_list(int year)
        {
            years.Items.Clear();
            for (int i=year-10;i<year+10;i++)
            {
                ListItem it = new ListItem(i + "年", i.ToString());
                years.Items.Add(it);
                it.Selected=it.Value == year.ToString() ? true : false;
            }
        }

        protected void Mstateinfo(int y)
        {
            try
            {
                string cmd = string.Format("select a.* ,b.no from(select * from m_info where dep_id={0} and ms_date between '{1}-1-01' and '{2}-12-31') a left join depno b on a.no_id =b.no_id  order by a.no_id desc,a.ms_date asc ", _uer.Udep_id, y, y);
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                this.m_info.DataSource = ds.DtOut;
                this.m_info.DataBind();
            }
            catch
            {

            }
        }
    }
}