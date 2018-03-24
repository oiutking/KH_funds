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

        private void bill_list_creat(int _pageindex = 1, int _pagesize = 6, string wherestr = "")
        {
            int _pagecount=0,_pages,_page_s,_page_e;
            string cmd, datatemp="";
            string[] dataarr;
            string[][] dataarrs;
            try
            {
                cmd = "select count(*) from bill where isfiled=0 " + wherestr;
                if (_uer.Ulvl<2)
                {
                    cmd += " and payform = " + _uer.Udep_id;
                }
                publicClass.Dosql ds = new publicClass.Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    _pagecount = Convert.ToInt32(ds.DtOut.Rows[0][0]);
                }
                _pages = _pagecount % _pagesize == 0 ? _pagecount / _pagesize : (_pagecount / _pagesize) + 1;
                _pageindex = _pageindex < 1 ? 1 : _pageindex;
                _pageindex = _pageindex > _pages ? _pages : _pageindex;
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

                for (int i = _page_s; i<=_page_e;i++)
                {
                    datatemp += i.ToString()+",";
                }
                dataarr = datatemp.Substring(0, datatemp.Length - 1).Split(',');
                this.pagestr.DataSource = dataarr;
                this.pagestr.DataBind();

                cmd = string.Format("select top({0}) a.*,b.dep_name from bill a,dep b where a.payfrom =b.dep_id and isfiled =0 and bill_id not in (select top({1})bill_id from bill order by bill_id desc) {2}", _pagesize, _pagesize*(_pageindex-1),wherestr);
                if (_uer.Ulvl < 2)
                {
                    cmd += " and payform = " + _uer.Udep_id;
                }
                cmd += " order by bill_id desc";
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
            bill_list_creat(999999);
        }

        protected void pageno_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            hide.Value = btn.Text;
            bill_list_creat(Convert.ToInt32(((Button)sender).Text));
        }

        protected void start_Click(object sender, EventArgs e)
        {
            bill_list_creat(-1);
        }

        protected void goback_Click(object sender, EventArgs e)
        {
            int i = (Convert.ToInt32(hide.Value) - 1);
            hide.Value = i.ToString();               
            bill_list_creat(i);
        }

        protected void next_Click(object sender, EventArgs e)
        {
            int i = (Convert.ToInt32(hide.Value) + 1);
            hide.Value = i.ToString();
            bill_list_creat(i);
        }
    }
}