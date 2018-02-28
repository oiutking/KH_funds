using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class Uer
    {
        private int _id, _dep_id, _lvl;
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