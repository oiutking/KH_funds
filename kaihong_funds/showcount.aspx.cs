using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kaihong_funds
{
    public partial class showcount : System.Web.UI.Page
    {
        publicClass.Uer _uer;
        publicClass.Dep _dep;
        protected void Page_Load(object sender, EventArgs e)
        {
            _uer = new publicClass.Uer(Convert.ToInt32(Session["uer_id"]));
            _dep = new publicClass.Dep(_uer.Udep_id);
            if (!IsPostBack)
            {
                startup();
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(this.headbar.Uer.Ulvl == 7 ? true : false);
        }

        protected void format_DropDownList(string _cmd, DropDownList _list, int[] _txt_index, int val_index,int select_key)
        {
            _list.Items.Clear();
            _list.SelectedIndex = -1;
            publicClass.Dosql ds = new publicClass.Dosql();
            DataTable temp = new DataTable();
            ds.DoRe(_cmd);
            if (ds.Sqled)
            {
                temp = ds.DtOut;
            }
            ListItem it = new ListItem();
            it.Text = "全部";
            it.Value = "0";
            _list.Items.Add(it);
            foreach (DataRow r in temp.Rows)
            {
                it = new ListItem();
                foreach (int i in _txt_index)
                {
                    it.Text += r[i] + ",";
                }
                it.Text = it.Text.Substring(0, it.Text.Length - 1);
                it.Value = r[val_index].ToString();
                if(it.Value==select_key.ToString())
                {
                    it.Selected = true;
                }
                _list.Items.Add(it);
            }
        }

        protected void startup()
        {
            
            //初始化页面控件

            string cmd = "";

            try
            {
                //单位list
                cmd = "select * from dep where 1=1";
                if (_uer.Ulvl <= 2)
                {
                    cmd += " and dep_id=" + _uer.Udep_id;
                    this.dep_list.Enabled = false;
                    this.sear_dep_btn.Enabled = false;

                }
                else
                {
                    this.dep_list.Enabled = true;
                    this.sear_dep_btn.Enabled = true;
                }
                format_DropDownList(cmd, this.dep_list, new int[] { 1 }, 0,_uer.Udep_id);

                //单位账号list
                cmd = "select * from depno where 1=1";
                if (_uer.Ulvl <= 2)
                {
                    cmd += " and dep_id=" + _uer.Udep_id;


                }

                format_DropDownList(cmd, this.sear_payfrom_no_list, new int[] { 1, 2 }, 0,0);

                //往来单位
                cmd = "select * from exc_dep where 1=1";
                if (_uer.Ulvl <= 2)
                {
                    cmd += " and dep_id=" + _uer.Udep_id;


                }

                format_DropDownList(cmd, this.sear_exc_dep_list, new int[] { 1, 2 }, 0,0);

            }
            catch
            {
            }


        }


        protected void dep_list_TextChanged(object sender, EventArgs e)
        {
            string cmd;
            cmd = "select * from depno where 1=1 and dep_id=" + this.dep_list.SelectedValue;
            format_DropDownList(cmd, this.sear_payfrom_no_list, new int[] { 1, 2 }, 0,0);
            cmd = "select * from exc_dep where 1=1 and dep_id=" + this.dep_list.SelectedValue;
            format_DropDownList(cmd, this.sear_exc_dep_list, new int[] { 1, 2 }, 0,0);
        }

        protected void search_btn_Click(object sender, EventArgs e)
        {
            string cmd = "";
            if (this.dep_list.SelectedValue != "0")
            {
                cmd += " and payfrom =" + this.dep_list.SelectedValue;
            }
            if (this.bill_type.SelectedValue != "0")
            {
                cmd += " and bill_type =" + this.bill_type.SelectedValue;
            }
            if (this.sear_payfrom_no_list.SelectedValue != "0")
            {
                cmd += " and payfrom_no = " + this.sear_payfrom_no_list.SelectedValue;
            }
            if (this.sear_exc_dep_list.SelectedValue != "0")
            {
                cmd += " and payto =" + this.sear_exc_dep_list.SelectedValue;
            }

            if (str_date_e.Text != "" && str_date_s.Text != "")
            {
                cmd += " and make_date between '" + str_date_s.Text + "' and '" + str_date_e.Text + "'";
            }
            Session["countinfo_wherestr"] = cmd;
            Response.Redirect("countinfo.aspx");


        }

        protected void sear_dep_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.Text == "查找")
                {
                    if (dep_list.Visible)
                    {
                        dep_list.Visible = false;
                        sear_dep_txt.Visible = true;
                    }
                    else
                    {
                        if (sear_dep_txt.Text == "")
                        {
                            dep_list.Visible = true;
                            sear_dep_txt.Visible = false;

                        }
                        else
                        {
                            string cmd = "select * from dep where dep_name like '%" + sear_dep_txt.Text + "%'";
                            if (_uer.Ulvl <= 2)
                            {
                                cmd += "and dep_id " + _uer.Udep_id;
                            }
                            format_DropDownList(cmd, dep_list, new int[] { 1 }, 0,0);
                            dep_list.Visible = true;
                            sear_dep_txt.Visible = false;
                            btn.Text = "恢复";
                            sear_dep_txt.Text = "";
                        }
                    }
                }
                else
                {
                    string cmd = "select * from dep where 1=1 ";
                    if (_uer.Ulvl <= 2)
                    {
                        cmd += "and dep_id = " + _uer.Udep_id;
                    }
                    format_DropDownList(cmd, dep_list, new int[] { 1 }, 0,0);
                    dep_list.Visible = true;
                    sear_dep_txt.Visible = false;
                    //no_list();
                    btn.Text = "查找";
                }
            }
            catch
            {
                dep_list.Items.Clear();
            }
        }

        protected void sear_payfrom_no_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.Text == "查找")
                {
                    if (sear_payfrom_no_list.Visible)
                    {
                        sear_payfrom_no_list.Visible = false;
                        sear_payfrom_no_txt.Visible = true;
                    }
                    else
                    {
                        if (sear_payfrom_no_txt.Text == "")
                        {
                            sear_payfrom_no_list.Visible = true;
                            sear_payfrom_no_txt.Visible = false;

                        }
                        else
                        {
                            string cmd = "select * from depno where no_name like '%" + sear_payfrom_no_txt.Text + "%' or no like '%" + sear_payfrom_no_txt.Text + "%'";
                            if (_uer.Ulvl <= 2)
                            {
                                cmd += "and dep_id " + _uer.Udep_id;
                            }
                            format_DropDownList(cmd, sear_payfrom_no_list, new int[] { 1, 2 }, 0,0);
                            sear_payfrom_no_list.Visible = true;
                            sear_payfrom_no_txt.Visible = false;
                            btn.Text = "恢复";
                            sear_payfrom_no_txt.Text = "";
                        }
                    }
                }
                else
                {
                    string cmd = "select * from depno where 1=1 ";
                    if (_uer.Ulvl <= 2)
                    {
                        cmd += "and dep_id = " + _uer.Udep_id;
                    }
                    format_DropDownList(cmd, sear_payfrom_no_list, new int[] { 1, 2 }, 0,0);
                    sear_payfrom_no_list.Visible = true;
                    sear_payfrom_no_txt.Visible = false;
                    //no_list();
                    btn.Text = "查找";
                }
            }
            catch
            {
                sear_payfrom_no_list.Items.Clear();
            }

        }

        protected void sear_exc_dep_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.Text == "查找")
                {
                    if (sear_exc_dep_list.Visible)
                    {
                        sear_exc_dep_list.Visible = false;
                        sear_exc_dep_txt.Visible = true;
                    }
                    else
                    {
                        if (sear_exc_dep_txt.Text == "")
                        {
                            sear_exc_dep_list.Visible = true;
                            sear_exc_dep_txt.Visible = false;

                        }
                        else
                        {
                            string cmd = "select * from exc_dep where edep_name like '%" + sear_exc_dep_txt.Text + "%' or edep_no like '%" + sear_exc_dep_txt.Text + "%'";
                            if (_uer.Ulvl <= 2)
                            {
                                cmd += "and dep_id " + _uer.Udep_id;
                            }
                            format_DropDownList(cmd, sear_exc_dep_list, new int[] { 1, 2 }, 0,0);
                            sear_exc_dep_list.Visible = true;
                            sear_exc_dep_txt.Visible = false;
                            btn.Text = "恢复";
                            sear_exc_dep_txt.Text = "";
                        }
                    }
                }
                else
                {
                    string cmd = "select * from exc_dep where 1=1 ";
                    if (_uer.Ulvl <= 2)
                    {
                        cmd += "and dep_id = " + _uer.Udep_id;
                    }
                    format_DropDownList(cmd, sear_exc_dep_list, new int[] { 1, 2 }, 0,0);
                    sear_exc_dep_list.Visible = true;
                    sear_exc_dep_txt.Visible = false;
                    //no_list();
                    btn.Text = "查找";
                }
            }
            catch
            {
                sear_exc_dep_list.Items.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.date_s.Visible = true;
            this.str_date_s.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.date_e.Visible = true;
            this.str_date_e.Visible = false;
        }

        protected void date_s_SelectionChanged(object sender, EventArgs e)
        {
            date_s.Visible = false;
            str_date_s.Visible = true;
            str_date_s.Text = date_s.SelectedDate.ToShortDateString();
        }

        protected void date_e_SelectionChanged(object sender, EventArgs e)
        {
            date_e.Visible = false;
            str_date_e.Visible = true;
            str_date_e.Text = date_e.SelectedDate.ToShortDateString();
        }



    }
}