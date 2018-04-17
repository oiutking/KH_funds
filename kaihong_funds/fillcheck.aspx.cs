using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class fillcheck : System.Web.UI.Page
    {
        private publicClass.Uer _uer;
        private publicClass.Dep _dep;
        protected void Page_Load(object sender, EventArgs e)
        {

            this.ErrStr.Text = "";
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
            _dep = new publicClass.Dep(_uer.Udep_id);
            if (!IsPostBack)
            {
                payfrom_no_list();
                payto_list();
            }

        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(_uer.Ulvl == 7 ? true : false);
        }

        protected void payfrom_no_list( string cmd_str ="")
        {
            try { 
            this.No.Items.Clear();
            this.Payfrom.Text = _dep.DeName;
            DataTable dt = new DataTable();
            string cmd;
            if (cmd_str == "")
                {
                    cmd = "select * from depno where state = 1 and dep_id = " + _dep.DeId;
                }
                else
                {
                    cmd = "select * from depno where state = 1 and dep_id = " + _dep.DeId + "and ( no_name like '%" + cmd_str + "%' or no like '%" + cmd_str + "%')";
                }
            publicClass.Dosql ds = new publicClass.Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled)
                {
                    dt = ds.DtOut;
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lit = new ListItem();
                        lit.Text = r["no_name"].ToString() +"("+ r["no"].ToString()+")";
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

        protected void payto_list(string cmd_str="")
        {
            try
            {
                this.payto_saerch_list.Items.Clear();
                DataTable dt = new DataTable();
                string cmd;
                if (cmd_str == "")
                {
                    cmd = "select * from exc_dep where state = 1 and dep_id = " + _dep.DeId;
                }
                else
                {
                    cmd = "select * from exc_dep where state = 1 and dep_id = " + _dep.DeId + "and ( edep_name like '%" + cmd_str + "%' or edep_no like '%" + cmd_str + "%')";
                }
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    dt = ds.DtOut;
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lit = new ListItem();
                        lit.Text = r["edep_name"].ToString() +"("+ r["edep_no"].ToString()+")";
                        lit.Value = r["edep_id"].ToString();
                        payto_saerch_list.Items.Add(lit);
                    }
                }

            }
            catch
            {
                this.ErrStr.Text = "页面参数有误！";
            }
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
                        payfrom_no_list(ser_no_txt.Text);
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
                payfrom_no_list();
                ser_no.Text = "查找账号";
            }
        }

        protected void search_btn_Click(object sender, EventArgs e)
        {
            if (search_btn.Text == "查找单位")
            {
                if (payto_saerch_list.Visible)
                {
                    payto_saerch_list.Visible = false;
                    payto_search_txt.Visible = true;
                }
                else
                {
                    if (payto_search_txt.Text == "")
                    {
                        payto_saerch_list.Visible = true;
                        payto_search_txt.Visible = false;

                    }
                    else
                    {
                        payto_list(payto_search_txt.Text);
                        payto_saerch_list.Visible = true;
                        payto_search_txt.Visible = false;
                        search_btn.Text = "恢复列表";
                        payto_search_txt.Text = "";
                    }
                }
            }
            else
            {
                payto_saerch_list.Visible = true;
                payto_search_txt.Visible = false;
                payto_list();
                search_btn.Text = "查找单位";
            }

        }

        protected void OK_Click(object sender, EventArgs e)
        {
            try
            {
             publicClass.bill _bill = new publicClass.bill();
            _bill.Bill_id_head = "";
            _bill.Bill_id_body = 0;
            _bill.Bill_type = 2;
            _bill.Payfrom = _uer.Udep_id;
            _bill.Payto = Convert.ToInt32(this.payto_saerch_list.SelectedValue);
            _bill.Amount = Convert.ToDecimal(this.Amount.Text);
            _bill.Summary = Summary.Text;
            _bill.Maker = _uer.Uid;
            _bill.Make_date = DateTime.Now;
            _bill.Isdel = false;
            _bill.Iscx = false;
            _bill.Prnt = 0;
            _bill.Op = 1;
            _bill.Dep_id = _uer.Udep_id;
            _bill.Secret = "";
            _bill.Payfrom_no = Convert.ToInt32(this.No.SelectedValue);
            _bill.Payto_no = Convert.ToInt32(this.payto_saerch_list.SelectedValue);
            _bill.Isfiled = false;
            _bill.save();

            this.Amount.Text = "";
            this.Summary.Text = "";
            this.ErrStr.Text = "存单保存成功";
            this.ErrStr.ForeColor = System.Drawing.Color.Green;
            Response.Redirect("review.aspx");

            }
            catch (Exception ex)
            {
                this.ErrStr.Text = "存单保存失败";
                this.ErrStr.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    
}