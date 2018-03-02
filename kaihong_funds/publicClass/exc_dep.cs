using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class exc_dep
    {
        int _edep_id, _dep_id;
        string _edep_name, _edep_no, _summary;

        public int Edep_id
        {
            get { return _edep_id; }
        }

        public int Dep_id
        {
            get { return _dep_id; }
            set { _dep_id = value; }
        }

        public string Edep_name
        {
            get { return _edep_name; }
            set { _edep_name = value; }
        }

        public string Edep_no
        {
            get { return _edep_no; }
            set { _edep_no = value; }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        public exc_dep()
        { }
        public exc_dep(int id)
        {
            string cmd = "select * from exc_dep where 1=1 and edep_id=" + id;
            Dosql ds = new Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled)
            {
                DataTable _dtuser = ds.DtOut;
                if (_dtuser.Rows.Count == 1)
                {
                    
                    _edep_id = Convert.ToInt32(_dtuser.Rows[0]["edep_id"]);
                    _edep_name = _dtuser.Rows[0]["edep_name"].ToString();
                    _edep_no = _dtuser.Rows[0]["edep_no"].ToString();
                    _summary = _dtuser.Rows[0]["summary"].ToString();
                    _dep_id = Convert.ToInt32(_dtuser.Rows[0]["dep_id"]);

                }
            }
            else
            {
                throw new Exception("err on creat exc_dep by id");
            }
        }
        public void Save()
        {
            try
            {
                if (_dep_id != -1)
                {
                    string cmdstr = "update  [exc_dep] set dep_name=@dep_name,dep_no=@dep_no,summary=@summary,dep_id=@dep_id where dep_id_id=" + _dep_id;
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@dep_name", "@dep_no", "@summary", "@dep_id" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Text, SqlDbType.BigInt };
                    input._par_val = new object[] { _edep_name, _edep_no, _summary, _dep_id };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);

                }
                else
                {
                    string cmdstr = "insert into [exc_dep] values(@dep_name,@dep_no,@summary,@dep_id)";
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@dep_name", "@dep_no", "@summary", "@dep_id" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Text, SqlDbType.BigInt };
                    input._par_val = new object[] { _edep_name, _edep_no,_summary, _dep_id };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}