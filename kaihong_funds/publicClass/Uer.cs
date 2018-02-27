using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public class Uer
    {
        private int _id, _dep_id, _lvl;
        private string _pws, _name, _no;
        private Boolean _state=false,_exist=false;

        public Uer()
        { }

        public Uer(int Uid)
        {
            string cmd = "select * from uer where 1=1 and uer_id=" + Uid;
            //do sql 
        }
        public  Uer(int Uid,int Udep_id,int Ulvl,string Upws,string Uname,string Uno,Boolean Ustate,Boolean Uexist)
        {
            _id = Uid;
            _dep_id = Udep_id;
            _lvl = Ulvl;
            _pws = Upws;
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
        }
        public int Ulvl 
        {
            get { return _lvl; }
        }
        public string Upsw
        {
            get { return _pws; }
        }
        public string Uname
        {
            get { return _name; }
        }
        public string Uno
        {
            get { return _no; }
        }
        public Boolean Ustate
        {
            get { return _state; }
        }
        public Boolean Uexsit
        {
            get { return _exist; }
        }
        
    }
}