using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kaihong_funds
{
    public partial class filedbillinfo : System.Web.UI.Page
    {
        private publicClass.Uer _uer;
        private publicClass.Dep _dep;
        private publicClass.bill _bill;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                startup();

                show_bill();

            }
            catch
            { }

        }
        protected void startup()
        {
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
            _bill = new publicClass.bill(Convert.ToInt32(Session["bill_filedinfo_id"].ToString()));
            _dep = new publicClass.Dep(_uer.Udep_id);

        }

        protected void show_bill()
        {
            if (_bill.Bill_type == 1)
            {
                CD.Visible = true;
                ZP.Visible = false;
                cd_ckdw.Text = new publicClass.Dep(_bill.Payfrom).DeName;
                cd_bz.Text = _bill.Summary;
                cd_pjbh.Text = _bill.Bill_id_head +"-"+ _bill.Bill_id_body;
                cd_jmxx.Text = _bill.Secret;
                cd_jmaxx.Text =publicClass.str2base64.tostr(_bill.Secret);
                cd_dycs.Text = _bill.Prnt + "次";
                cd_ckzh.Text = new publicClass.dep_no(_bill.Payfrom_no).No + "(" + new publicClass.dep_no(_bill.Payfrom_no).No_name + ")";
                cd_maker.Text = new publicClass.Uer(_bill.Maker).Uname;
                cd_amount.Text = _bill.Amount.ToString();
                cd_kpsj.Text = _bill.Make_date.ToShortDateString();

            }
            else
            {
                CD.Visible = false;
                ZP.Visible = true;
                zp_fkdw.Text = new publicClass.Dep(_bill.Payfrom).DeName;
                zp_fkzh.Text = new publicClass.dep_no(_bill.Payfrom_no).No + "(" + new publicClass.dep_no(_bill.Payfrom_no).No_name + ")";
                publicClass.exc_dep edep = new publicClass.exc_dep(_bill.Payto);
                zp_skdw.Text = edep.Edep_name;
                zp_skzh.Text = edep.Edep_no;
                zp_maker.Text = new publicClass.Uer(_bill.Maker).Uname;
                zp_amount.Text = _bill.Amount.ToString();
                zp_kprq.Text = _bill.Make_date.ToShortDateString();
                zp_bz.Text = _bill.Summary;
                zp_pjbh.Text = _bill.Bill_id_head + "-" + _bill.Bill_id_body;
                zp_jmxx.Text = _bill.Secret;
                zp_jmaxx.Text = publicClass.str2base64.tostr(_bill.Secret);
                zp_dycs.Text = _bill.Prnt + "次";


            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("showfiled.aspx");
        }

        protected void print_Click(object sender, EventArgs e)
        {
            _bill.Prnt++;
            _bill.save();
            show_bill();
            Session["bill_preview"] = _bill.Bill_id + "," + _bill.Bill_type;

            this.ClientScript.RegisterStartupScript(ClientScript.GetType(), "print", "<script type='text/javascript' > window.open('preview.aspx', '打印预览', '_blank') </script >");
        }

        protected void ref_Click(object sender, EventArgs e)
        {
            startup();

            show_bill();
        }
    }
    
}