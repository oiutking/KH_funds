using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace kaihong_funds
{
    public partial class review : System.Web.UI.Page
    {
        private publicClass.Uer _uer;
        private publicClass.Dep _dep;
        protected void Page_Load(object sender, EventArgs e)
        {
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
            _dep = new publicClass.Dep(_uer.Udep_id);
            if (!IsPostBack)
            {
                bill_list_creat();
            }

        }

        private void bill_list_creat()
        {
            string cmd;
            if (Session["bill_list_ses"]!=null)
            {
                cmd = Session["bill_list_ses"].ToString();
            }
            else
            {
                cmd = "select a.*,b.dep_name from bill a , dep b where 1=1 and a.payfrom =b.dep_id and isfiled = 0";
                if (_uer.Ulvl <= 2)
                {
                    cmd += "and payfrom ="+_uer.Udep_id ;
                }
                        
            }
            try
            {
                cmd += " order by bill_id desc";
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    this.Repeater1.DataSource = ds.DtOut;
                    this.Repeater1.DataBind();
                }
            }
            catch
            {
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "delete from bill where bill_id=@bill_id";
                publicClass.DS_input ip = new publicClass.DS_input();
                ip._cmd = cmd;
                ip._par_name = new string[] { "@bill_id" };
                ip._par_type = new SqlDbType[] { SqlDbType.BigInt };
                ip._par_val = new object[] { ((Button)sender).CommandArgument };
                publicClass.Dosql ds = new publicClass.Dosql();
                publicClass.DS_input[] i = { ip };
                ds.DoNoRe(i);
                bill_list_creat();
            }
            catch
            {

            }

        }
    }
}