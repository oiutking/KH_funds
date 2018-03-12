using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class fillposit : System.Web.UI.Page
    {
        private publicClass.Uer _uer;
        private publicClass.Dep _dep;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.No.Items.Clear();
            try
            {
                _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));                
                _dep = new publicClass.Dep(_uer.Udep_id);
                this.Payfrom.Text = _dep.DeName;
                DataTable dt = new DataTable();
                string cmd = "select * from depno where dep_id = " + _dep.DeId;
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    dt = ds.DtOut;
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lit = new ListItem();
                        lit.Text = r["no_name"].ToString() + r["no"].ToString();
                        lit.Value = r["no"].ToString();
                        No.Items.Add(lit);
                    }
                }

            }
            catch
            {
                this.ErrStr.Text = "页面参数有误！";
            }

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(_uer.Ulvl == 7 ? true : false);
        }
    }
}