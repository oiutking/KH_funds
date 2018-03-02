using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class sig
    {
        private int _sig_id=-1, _dep_id, _type, _lvl;
        private string _sig_word;
        private Boolean _state;

        public int Sig_id
        {
            get { return _sig_id; }
        }

        public int Dep_id
        {
            get { return _dep_id; }
            set { _dep_id = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int  Lvl
        {
            get { return _lvl; }
            set { _lvl = value; }
        }

        public string Sig_word
        {
            get { return _sig_word; }
            set { _sig_word = value; }
        }

        public Boolean State
        {
            set { _state = value; }
            get { return _state; }
        }
        public sig()
        { }

        public sig(int id)
        {
            string cmd = "select * from sig where 1=1 and sig_id=" + id;
            Dosql ds = new Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled)
            {
                DataTable _dtuser = ds.DtOut;
                if (_dtuser.Rows.Count == 1)
                {
                    _sig_id= Convert.ToInt32(_dtuser.Rows[0]["sig_id"]);
                    _dep_id = Convert.ToInt32(_dtuser.Rows[0]["dep_id"]);
                    _state =Convert.ToBoolean( _dtuser.Rows[0]["dep_name"]);
                    _sig_word = _dtuser.Rows[0]["sig_word"].ToString();
                    _type =Convert.ToInt32( _dtuser.Rows[0]["type"]);
                    _lvl =Convert.ToInt32( _dtuser.Rows[0]["lvl"]);

                }
            }
            else
            {
                throw new Exception("err on creat sig by id");
            }
        }

        public void Save()
        {
            try
            {
                if (_sig_id != -1)
                {
                    string cmdstr = "update  [sig] set dep_id=@dep_id,state=@state,sig_word=@sig_word,type=@type,lvl=@lvl where sig_id=" + _sig_id;
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@dep_id", "@state","@sig_word", "@type", "@lvl" };
                    input._par_type = new SqlDbType[] { SqlDbType.BigInt, SqlDbType.Bit, SqlDbType.Text, SqlDbType.Int,SqlDbType.Int};
                    input._par_val = new object[] { _dep_id,_type,_sig_word,_type,_lvl };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);

                }
                else
                {
                    string cmdstr = "insert into [sig] values( @dep_id, @state, @sig_word, @type, @lvl )";
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@dep_id", "@state", "@sig_word", "@type", "@lvl" };
                    input._par_type = new SqlDbType[] { SqlDbType.BigInt, SqlDbType.Bit, SqlDbType.Text, SqlDbType.Int, SqlDbType.Int };
                    input._par_val = new object[] { _dep_id, _type, _sig_word, _type, _lvl };
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