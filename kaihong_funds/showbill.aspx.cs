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
                _bill = new publicClass.bill(Convert.ToInt32(Session["bill_preview"].ToString()));
                _dep = new publicClass.Dep(_uer.Udep_id);
                if (!IsPostBack)
                {
                    creat_siglist();
                }
                show_bill();
                ispower();
                oplist();
            }
            catch
            { }
        }

        protected void show_bill()
        {
            if (_bill.Bill_type==1)
            {
                CD.Visible = true;
                ZP.Visible = false;
                cd_ckdw.Text = new publicClass.Dep(_bill.Payfrom).DeName;
                cd_ckzh.Text=new publicClass.dep_no(_bill.Payfrom_no).No+"("+new publicClass.dep_no(_bill.Payfrom_no).No_name+")";
                cd_maker.Text = new publicClass.Uer(_bill.Maker).Uname;
                cd_amount.Text = _bill.Amount.ToString();
                cd_kpsj.Text = _bill.Make_date.ToShortDateString();

            }
            else
            {
                CD.Visible = false;
                ZP.Visible = true;
                zp_fkdw.Text = new publicClass.Dep(_bill.Payfrom).DeName;
                zp_fkzh.Text= new publicClass.dep_no(_bill.Payfrom_no).No + "(" + new publicClass.dep_no(_bill.Payfrom_no).No_name + ")";
                publicClass.exc_dep edep = new publicClass.exc_dep(_bill.Payto);
                zp_skdw.Text = edep.Edep_name;
                zp_skzh.Text = edep.Edep_no;
                zp_maker.Text = new publicClass.Uer(_bill.Maker).Uname;
                zp_amount.Text = _bill.Amount.ToString();
                zp_kprq.Text = _bill.Make_date.ToShortDateString();

            }
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
                    string cmd_delop = string.Format("delete from op where lvl={0} and bill_id={1}", _uer.Ulvl-1, _bill.Bill_id);
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
                    _bill.Op--;
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
            finally
            {
                ispower();
                oplist();
                
            }
        }

        protected void Unnamed_Click2(object sender, EventArgs e)
        {
            try
            {
                if (_bill.Op!=_uer.Ulvl) { throw new Exception("lvl错误!"); }
                if (sigs.SelectedValue == "-1" && _bill.Op<=2) { throw new Exception("印章选择错误！"); }
                string cmd_insert_op = string.Format("insert into op values({0},{1},'{2}',{3},{4},{5},{6},{7},'{8}')",_bill.Bill_id,_uer.Uid,DateTime.Now.ToShortDateString(),_uer.Ulvl,-1,Convert.ToInt32(sigs.SelectedValue),-1,-1,summary.Text);
                string cmd_up_bill = string.Format("update bill set op ={0} where bill_id={1}", _bill.Op + 1, _bill.Bill_id);
                publicClass.Dosql ds = new publicClass.Dosql();
                publicClass.DS_input[] ips = new publicClass.DS_input[2];
                ips[0] = new publicClass.DS_input();
                ips[1] = new publicClass.DS_input();
                ips[0]._cmd = cmd_insert_op;
                ips[1]._cmd = cmd_up_bill;
                ips[0]._par_name = ips[1]._par_name = new string[] { };
                ips[0]._par_type = ips[1]._par_type = new SqlDbType[] { };
                ips[0]._par_val = ips[1]._par_val = new object[] { };
                ds.DoNoRe(ips);
                _bill.Op++;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ispower();
                oplist();
            }
        }

        protected void ispower()
        {
            if (_bill.Op==5)
            {
                filed.Enabled = true;
            }
            else
            {
                filed.Enabled = false;
            }
            if (_bill.Op==_uer.Ulvl)
            {
                flowback.Enabled = true;
                saveop.Enabled = true;
            }
            else
            {
                flowback.Enabled = false;
                saveop.Enabled = false;
            }
        }

        protected void oplist()
        {
            try
            {
                string list_str = string.Format("select a.* ,b.uer_name from (select * from op where 1=1 and bill_id={0} )a left join uer b on a.uer_id=b.uer_id order by a.op_id asc", _bill.Bill_id);
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(list_str);
                OP_list.DataSource = ds.DtOut;
                OP_list.DataBind();
            }
            catch
            {

            }
        }

        protected void flowend_Click(object sender, EventArgs e)
        {
            try
            {
                string del = string.Format("delete from op where bill_id={0}", _bill.Bill_id);
                string up = string.Format("update bill set op=1 where bill_id={0}", _bill.Bill_id);
                publicClass.Dosql ds = new publicClass.Dosql();
                publicClass.DS_input[] ips = new publicClass.DS_input[2];
                ips[0] = new publicClass.DS_input();
                ips[1] = new publicClass.DS_input();
                ips[0]._cmd = del;
                ips[1]._cmd = up;
                ips[0]._par_name = ips[1]._par_name = new string[] { };
                ips[0]._par_type = ips[1]._par_type = new SqlDbType[] { };
                ips[0]._par_val = ips[1]._par_val = new object[] { };
                ds.DoNoRe(ips);
                _bill.Op = 1;
            }
            catch
            { }
            finally
            {
                ispower();
                oplist();

            }
        }
    }
}