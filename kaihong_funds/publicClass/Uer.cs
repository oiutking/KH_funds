using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace kaihong_funds.publicClass
{
    public class Uer
    {
        private int _id=-1, _dep_id, _lvl;
        private string _psw, _name, _no;
        private Boolean _state=false,_exist=false;

        public Uer()
        { }

        public Uer(int Uid)
        {
            string cmd = "select * from uer where 1=1 and uer_id=" + Uid;
            Dosql ds = new Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled)
            {
                DataTable _dtuser = ds.DtOut;
                if (_dtuser.Rows.Count==1)
                {
                    _exist = true;
                    _id = Convert.ToInt32(_dtuser.Rows[0]["uer_id"]);                  
                    _lvl = Convert.ToInt32(_dtuser.Rows[0]["uer_lvl"]);
                    _psw = _dtuser.Rows[0]["psw"].ToString();
                    _name= _dtuser.Rows[0]["uer_name"].ToString();
                    _no= _dtuser.Rows[0]["uer_no"].ToString();
                    _state =Convert.ToBoolean( _dtuser.Rows[0]["state"]);
                    _dep_id =Convert.ToInt32( _dtuser.Rows[0]["dep_id"]);

                }
            }
            else
            {
                throw new Exception("err on creat uer by id");
            }

        }
        public  Uer(int Uid,int Udep_id,int Ulvl,string Upws,string Uname,string Uno,Boolean Ustate,Boolean Uexist)
        {
            _id = Uid;
            _dep_id = Udep_id;
            _lvl = Ulvl;
            _psw = Upws;
            _name = Uname;
            _no = Uno;
            _state = Ustate;
            _exist = Uexist;

        }

        public void Save()
        {
            try
            {
                if (_id != -1 & _exist)
                {
                    string cmdstr = "update  [uer] set psw=@psw,uer_name=@uer_name,uer_no=@uer_no,dep_id=@dep_id,state=@state,uer_lvl=@uer_lvl where uer_id="+_id;
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@psw", "@uer_name", "@uer_no", "@dep_id", "@state", "@uer_lvl" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Text, SqlDbType.BigInt, SqlDbType.Bit, SqlDbType.BigInt };
                    input._par_val = new object[] { _psw, _name, _no,_dep_id, _state, _lvl };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);

                }
                else
                {
                    string cmdstr = "insert into [uer] values(@psw,@uer_name,@uer_no,@dep_id,@state,@uer_lvl)";
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@psw", "@uer_name", "@uer_no", "@dep_id", "@state", "@uer_lvl" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Text, SqlDbType.BigInt, SqlDbType.Bit, SqlDbType.BigInt };
                    input._par_val = new object[] { _psw, _name, _no, _dep_id, _state, _lvl };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Uid
        {
            get{ return _id; }
        }
        public int Udep_id
        {
            get { return _dep_id; }
            set { _dep_id = value; }
        }
        public int Ulvl 
        {
            get { return _lvl; }
            set { _lvl = value; }
        }
        public string Upsw
        {
            get { return _psw; }
            set { _psw = value; }
        }
        public string Uname
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Uno
        {
            get { return _no; }
            set { _no = value; }
        }
        public Boolean Ustate
        {
            get { return _state; }
            set { _state = value; }
        }
        public Boolean Uexsit
        {
            get { return _exist; }
           
        }
        
    }
}