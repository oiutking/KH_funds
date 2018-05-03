using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class key
    {
        int _key_id=-1, _uer_id=0;
        string _key_word="", _sn="";
        Boolean _state=false;
        public key()
        {
        }

        public void save()
        {
            try
            {
                if (_key_id != -1)
                {
                    string cmdstr = "update  [key] set key_word=@key_word,uer_id=@uer_id,state=@state,SN=@SN where key_id=" +_key_id;
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@key_word", "@uer_id", "@state", "@SN" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.BigInt, SqlDbType.Bit, SqlDbType.Text };
                    input._par_val = new object[] { _key_word, _uer_id, _state, _sn };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);

                }
                else
                {
                    throw new Exception("不能新建KEY！");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public key(int id,int flag=0)
        {
            try
            {

                string cmd="";
                if(flag==0)
                {
                    cmd= "select * from [key] where 1=1 and uer_id=" + id;
                }
                else
                {
                    cmd = "select * from [key] where 1=1 and key_id=" + id;
                }
                Dosql ds = new Dosql();
                ds.DoRe(cmd);
                if (ds.Sqled)
                {
                    DataTable _dt_key = ds.DtOut;
                    if (_dt_key.Rows.Count == 1)
                    {

                        _uer_id = Convert.ToInt32(_dt_key.Rows[0]["uer_id"]);
                        _key_word = _dt_key.Rows[0]["key_word"].ToString();
                        _key_id = Convert.ToInt32(_dt_key.Rows[0]["key_id"]);
                        _state = Convert.ToBoolean(_dt_key.Rows[0]["state"]);
                        _sn = _dt_key.Rows[0]["sn"].ToString();

                    }
                }
                else
                {
                    throw new Exception("err on creat key by id");
                }
            }
            catch
            {
                _state = false;
            }
        }

        public int Key_id
        {
            get { return _key_id; }
            set { _key_id = value; }
        }

        public int Uer_id
        {
            get { return _uer_id; }
            set { _uer_id = value; }
        }
        public string Key_word
        {
            get { return _key_word; }
        }

        public string SN
        {
            get { return _sn; }
        }

        public Boolean State
        {
            get { return _state; }
            set { _state =value;}
        }
    }
}