using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class Dep
    {
        int _dep_id=-1;
        string _dep_name, _dep_no, _dep_summary, _dep_short;

        public void Save()
        {
            try
            {
                if (_dep_id != -1)
                {
                    string cmdstr = "update  [dep] set dep_name=@dep_name,dep_no=@dep_no,summary=@summary,dep_short=@dep_short where dep_id_id=" + _dep_id;
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] {"@dep_name","@dep_no","@summary","@dep_short" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Text, SqlDbType.Text };
                    input._par_val = new object[] { _dep_name,_dep_no,_dep_summary,_dep_short };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);

                }
                else
                {
                    string cmdstr = "insert into [dep] values(@dep_name,@dep_no,@summary,@dep_short)";
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@dep_name", "@dep_no", "@summary", "@dep_short" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Text, SqlDbType.Text };
                    input._par_val = new object[] { _dep_name, _dep_no, _dep_summary, _dep_short };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dep(int id)
        {
            string cmd = "select * from dep where 1=1 and dep_id=" + id;
            Dosql ds = new Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled)
            {
                DataTable _dtuser = ds.DtOut;
                if (_dtuser.Rows.Count == 1)
                {

                    _dep_id = Convert.ToInt32(_dtuser.Rows[0]["dep_id"]);
                    _dep_name = _dtuser.Rows[0]["dep_name"].ToString();
                    _dep_no = _dtuser.Rows[0]["dep_no"].ToString();
                    _dep_summary = _dtuser.Rows[0]["summary"].ToString();
                    _dep_short =_dtuser.Rows[0]["dep_id"].ToString();

                }
            }
            else
            {
                throw new Exception("err on creat dep by id");
            }
        }

        public int DeId
            {
            get { return _dep_id; }
            }
        public string DeName
        {
            get { return _dep_name; }
            set { _dep_name = value; }
        }

        public string DeNo
        {
            get { return _dep_no; }
            set { _dep_no = value; }
        }

        public string DeSummary
        {
            get { return _dep_summary; }
            set { _dep_summary = value; }
        }

        public string DeShort
        {
            get{ return _dep_short; }
            set { _dep_short = value; }
        }
    }
}