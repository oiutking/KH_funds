using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace kaihong_funds
{
    public partial class showbill : System.Web.UI.Page
    {
        private publicClass.Uer _uer;
        private publicClass.Dep _dep;
        private publicClass.bill _bill;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
                _bill = new publicClass.bill(Convert.ToInt32(Session["bill_preview"].ToString().Split(',')[0]));
                _dep = new publicClass.Dep(_uer.Udep_id);
                if (!IsPostBack)
                {
                    creat_siglist();
                }
            }
            catch
            { }
        }

        protected void creat_siglist()
        {
            try
            {
                this.sigs.Items.Clear();
                this.sigs.Items.Add(new ListItem("请选择", "-1"));
                string cmd_siglist =string.Format( "select * from sig where state=1 and dep_id={0} and lvl={1}",_uer.Udep_id,_uer.Ulvl);
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd_siglist);
                foreach(DataRow r in ds.DtOut.Rows)
                {
                    ListItem lt = new ListItem(r["sig_name"].ToString(), r["sig_id"].ToString());
                    sigs.Items.Add(lt);
                }
            }
            catch
            {

            }
        }

        protected void sigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            string now = DateTime.Now.ToString();
            MemoryStream memStream = new MemoryStream();
            binFormatter.Serialize(memStream, now);
            byte[] b64 = memStream.GetBuffer();
            if (sigs.SelectedValue != "-1")
            {
                this.img.ImageUrl = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/sigimg.aspx?id=" + sigs.SelectedValue + "&code=" + Convert.ToBase64String(b64);
            }
            else
            {
                this.img.ImageUrl = "";
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("review.aspx");
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            try
            {
                if (_bill.Op == _uer.Ulvl && _bill.Payfrom==_uer.Udep_id)
                {
                    string cmd_delop = string.Format("delete from op where lvl={0} and bill_id={1}", _bill.Op, _bill.Bill_id);
                    int new_op = _bill.Op - 1 < 1 ? 1 : _bill.Op - 1;
                    string cmd_upbill = string.Format("update bill set op={0} where bill_id =" + _bill.Bill_id, new_op);
                    publicClass.DS_input ip1 = new publicClass.DS_input();
                    publicClass.DS_input ip2 = new publicClass.DS_input();
                    ip1._cmd = cmd_delop;
                    ip2._cmd = cmd_upbill;
                    ip1._par_name= ip2._par_name=new string[] { };
                    ip1._par_type = ip2._par_type= new SqlDbType[] { };
                    ip1._par_val = ip2._par_val = new object[] { };
                    publicClass.Dosql ds = new publicClass.Dosql();
                    ds.DoNoRe(new publicClass.DS_input[] { ip1, ip2 });
                    if (!ds.Sqled)
                    {
                        throw new Exception("票据回退失败！");
                    }


                }
                else
                {
                    throw new Exception("票据审批流程出错！");
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}