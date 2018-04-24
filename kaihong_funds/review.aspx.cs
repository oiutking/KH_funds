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

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            this.menu.Isadmin(this.headbar.Uer.Ulvl == 7 ? true : false);

        }

        private void bill_list_creat(int _pageindex = 1, int _pagesize = 6, string wherestr = "")
        {
            int _pagecount=0,_pages,_page_s,_page_e;
            string cmd, datatemp="";
            string[] dataarr;
            if (Session["review_list_where"] != null) { wherestr = Session["review_list_where"].ToString(); } else { wherestr = ""; }
            //设置查询条件
            try
            {
                cmd = "select count(*) from bill where isfiled=0 " + wherestr;
                if (_uer.Ulvl<=2)
                {
                    cmd += " and payfrom = " + _uer.Udep_id;
                }
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    _pagecount = Convert.ToInt32(ds.DtOut.Rows[0][0]);
                }
                _pages = _pagecount % _pagesize == 0 ? _pagecount / _pagesize : (_pagecount / _pagesize) + 1;
                
                _pageindex = _pageindex > _pages ? _pages : _pageindex;
                _pageindex = _pageindex < 1 ? 1 : _pageindex;

                hide.Value = _pageindex.ToString();//控制分页按钮高亮

                if (_pages<=5)
                {
                    _page_s = 1;
                    _page_e = _pages;
                }
                else
                {
                    _page_s = _pageindex - 2 < 1 ? 1 : _pageindex - 2;
                    if(_pageindex<=2)
                    { _page_e = 5; }
                    else
                    { _page_e = _pageindex + 2 > _pages ? _pages : _pageindex + 2; }                    
                }

                if (_page_s==1)
                {
                    front.Visible = false;
                }
                else
                {
                    front.Visible = true;
                }
                if(_pageindex+2<_pages)
                {
                    back.Visible = true;
                }
                else
                {
                    back.Visible = false;
                }
                this.end.CommandArgument = _pages.ToString();
                for (int i = _page_s; i<=_page_e;i++)
                {
                    datatemp += i.ToString()+",";
                }
                if (datatemp.Length != 0)
                {
                    dataarr = datatemp.Substring(0, datatemp.Length - 1).Split(',');
                }
                else
                {
                    dataarr = new string[] { "1" };
                }
                this.pagestr.DataSource = dataarr;
                this.pagestr.DataBind();

                //cmd = string.Format("select e.* ,f.* from (select c.*,d.no_name,d.no from (select top({0}) a.*,b.dep_name from bill a,dep b where a.payfrom =b.dep_id  and isfiled =0 and bill_id not in (select top({1})bill_id from bill where 1=1 {2} order by bill_id desc) {3}) c left join depno d on d.no_id = c.payfrom_no) e left join exc_dep f on e.payto=f.edep_id", _pagesize, _pagesize*(_pageindex-1),wherestr,wherestr);
                
                if (_uer.Ulvl <= 2)
                {
                    wherestr += " and payfrom = " + _uer.Udep_id;
                }
                cmd = string.Format("select e.*,f.* from(select c.*,d.edep_name,d.edep_no from (select a.*,b.no_name,b.no from (select top {0} * from bill where 1=1 and isfiled=0 {1} and bill_id not in(select top {2} bill_id from bill where 1=1 and isfiled=0 {3} order by bill_id desc) order by bill_id desc) a left join depno b on a.payfrom_no=b.no_id) c left join  exc_dep d on c.payto =d.edep_id) e left join dep f on e.payfrom= f.dep_id", _pagesize, wherestr, _pagesize * (_pageindex - 1), wherestr);
                //cmd += " order by bill_id desc";
                ds = null;
                ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if(ds.Sqled)
                {
                    this.Repeater1.DataSource = ds.DtOut;
                    this.Repeater1.DataBind();
                }
                



            }
            catch(Exception ex)
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

        protected void end_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(((Button)sender).CommandArgument);
            bill_list_creat(i);
        }

        protected void pageno_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            bill_list_creat(Convert.ToInt32(((Button)sender).Text));
        }

        protected void start_Click(object sender, EventArgs e)
        {
            
            bill_list_creat(1);
        }

        protected void goback_Click(object sender, EventArgs e)
        {
            int i = (Convert.ToInt32(hide.Value) - 1);
            bill_list_creat(i);
        }

        protected void next_Click(object sender, EventArgs e)
        {
            int i = (Convert.ToInt32(hide.Value) + 1);
            bill_list_creat(i);
        }

        //显示层切换,显示
        protected void show_sear_btn_Click(object sender, EventArgs e)
        {
            this.show_sear_btn.Visible = false;
            this.renew_list_btn.Visible = false;
            this.ymbt.Text = "条件查询";
            this.search_div.Visible = true;
            this.list_tab.Visible = false;
            this.ErrStr.Visible = false;

            //初始化页面控件

            string cmd ="";
            
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
                this.ErrStr.Text = "页面参数有误！";
                this.ErrStr.Visible=true;
            }
            

        }

        protected void format_DropDownList(string _cmd,DropDownList _list,int[]  _txt_index,int val_index, int select_key)
        {
            _list.Items.Clear();
            _list.SelectedIndex = -1;
            publicClass.Dosql ds = new publicClass.Dosql();
            DataTable temp = new DataTable();
            ds.DoRe(_cmd);
            if(ds.Sqled)
            {
                temp = ds.DtOut;
            }
            ListItem it = new ListItem();
            it.Text = "全部";
            it.Value = 0.ToString();            
            _list.Items.Add(it);


            foreach(DataRow r in temp.Rows)
            {
                it = new ListItem();
                foreach (int i in _txt_index)
                {
                    it.Text += r[i]+",";
                }
                it.Text = it.Text.Substring(0, it.Text.Length - 1);
                it.Value = r[val_index].ToString();
                if (it.Value == select_key.ToString())
                {
                    it.Selected = true;
                }
                _list.Items.Add(it);
            }
        }

        protected void renew_list_btn_Click(object sender, EventArgs e)
        {
            this.ymbt.Text = "票据列表";
            this.search_div.Visible = false;
            this.list_tab.Visible = true;
            Session["review_list_where"] = "";
            bill_list_creat();
        }

        protected void dep_list_TextChanged(object sender, EventArgs e)
        {
            string cmd;
            cmd = "select * from depno where 1=1 and dep_id=" +this.dep_list.SelectedValue;
            format_DropDownList(cmd, this.sear_payfrom_no_list, new int[] { 1, 2 }, 0,0);
            cmd = "select * from exc_dep where 1=1 and dep_id=" + this.dep_list.SelectedValue;
            format_DropDownList(cmd, this.sear_exc_dep_list, new int[] { 1, 2 }, 0,0);
        }

        protected void search_btn_Click(object sender, EventArgs e)
        {
            string cmd="";
            if (this.dep_list.SelectedValue!="0")
            {
                cmd += " and payfrom =" + this.dep_list.SelectedValue;
            }
            if (this.bill_type.SelectedValue!="0")
            {
                cmd += " and bill_type =" + this.bill_type.SelectedValue;
            }
            if (this.sear_payfrom_no_list.SelectedValue!="0")
            {
                cmd += " and payfrom_no = " + this.sear_payfrom_no_list.SelectedValue;
            }
            if (this.sear_exc_dep_list.SelectedValue!="0")
            {
                cmd += " and payto =" + this.sear_exc_dep_list.SelectedValue;
            }
            if (this.sear_amount.Text!="")
            {
                cmd += " and amount =" + this.sear_amount.Text;
            }

            Session["review_list_where"] = cmd;

            bill_list_creat();
            this.show_sear_btn.Visible = true;
            this.renew_list_btn.Visible = true;
            this.search_div.Visible = false;
            this.list_tab.Visible = true;


        }

        protected void back_btn_Click(object sender, EventArgs e)
        {
            this.show_sear_btn.Visible = true;
            this.renew_list_btn.Visible = true;
            this.search_div.Visible = false;
            this.list_tab.Visible = true;
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
                            format_DropDownList(cmd, sear_payfrom_no_list, new int[] { 1,2 }, 0,0);
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
                    format_DropDownList(cmd, sear_payfrom_no_list, new int[] { 1,2 }, 0,0);
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

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            Session["bill_preview"] = ((Button)sender).CommandArgument.ToString();
            Response.Redirect("showbill.aspx");
        }
    }
}