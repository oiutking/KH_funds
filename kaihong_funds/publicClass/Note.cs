using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class Note
    {
        int _note_id=-1;
        string _word="";

        public Note()
        { }

        public string Word
        {
            set { _word = value; }
            get { return _word; }
        }

        public Note(int id )
        {
            string cmd = "select * from note where 1=1 and uer_id=" + id;
            Dosql ds = new Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled)
            {
                DataTable _dtuser = ds.DtOut;
                if (_dtuser.Rows.Count == 1)
                {
                   
                    _note_id = Convert.ToInt32(_dtuser.Rows[0]["note_id"]);
                    _word = _dtuser.Rows[0]["word"].ToString();
                    
                }
            }
            else
            {
                throw new Exception("err on creat note by id");
            }

        }

        public void save()
        {
            try
            {
                if (_note_id != -1)
                {
                    string cmdstr = "update  [note] set word=@word where uer_id=" + _note_id;
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@word" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text };
                    input._par_val = new object[] {_word};
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);

                }
                else
                {
                    string cmdstr = "insert into [note] values(@word)";
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@word"};
                    input._par_type = new SqlDbType[] { SqlDbType.Text };
                    input._par_val = new object[] {_word };
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