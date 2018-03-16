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
            no_list();
            this.ErrStr.Text = "";

        }

        protected void no_list(string icmd="")
        {
            this.No.Items.Clear();
            try
            {
                _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
                _dep = new publicClass.Dep(_uer.Udep_id);
                this.Payfrom.Text = _dep.DeName;
                DataTable dt = new DataTable();
                string cmd;
                if (icmd == "")
                {
                 cmd = "select * from depno where state = 1 and dep_id = " + _dep.DeId;
                }
                else
                {
                    cmd = "select * from depno where state = 1 and dep_id = " + _dep.DeId + "and ( no_name like '%" + icmd + "%' or no like '%" + icmd + "%')";
                }
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    dt = ds.DtOut;
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lit = new ListItem();
                        lit.Text = r["no_name"].ToString() + r["no"].ToString();
                        lit.Value = r["no_id"].ToString();
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

        protected void ser_no_Click(object sender, EventArgs e)
        {
            if (ser_no.Text == "查找账号")
            {
                if (No.Visible)
                {
                    No.Visible = false;
                    ser_no_txt.Visible = true;
                }
                else
                {
                    if (ser_no_txt.Text == "")
                    {
                        No.Visible = true;
                        ser_no_txt.Visible = false;

                    }
                    else
                    {
                        no_list(ser_no_txt.Text);
                        No.Visible = true;
                        ser_no_txt.Visible = false;
                        ser_no.Text = "恢复列表";
                        ser_no_txt.Text = "";
                    }
                }
            }
            else
            {
                No.Visible = true;
                ser_no_txt.Visible = false;
                no_list();
                ser_no.Text = "查找账号";
            }

        }

        protected void OK_Click(object sender, EventArgs e)
        {
            publicClass.bill _bill = new publicClass.bill();
            _bill.Bill_id_head = "";
            _bill.Bill_id_body = -1;
            _bill.Bill_type = 1;            
            _bill.Payfrom = _uer.Udep_id;
            _bill.Payto = -1;
            _bill.Amount = Convert.ToDecimal(this.Amount.Text);
            _bill.Summary = Summary.Text;
            _bill.Maker = _uer.Uid;
            _bill.Make_date = DateTime.Now;
            _bill.Isdel = false;
            _bill.Iscx = false;
            _bill.Prnt = 0;
            _bill.Op = 0;
            _bill.Dep_id = _uer.Udep_id;
            _bill.Secret = "";
            _bill.Payfrom_no = Convert.ToInt32(this.No.SelectedValue);       
            _bill.Payto_no = -1; 
            try
            {
                _bill.save();
                foreach(Control i in this.Controls)
                {
                    this.Amount.Text = "";
                    this.Summary.Text = "";
                    this.ErrStr.Text = "存单保存成功";
                    this.ErrStr.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch(Exception ex)
            {
                this.ErrStr.Text = "存单保存失败";
                this.ErrStr.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}