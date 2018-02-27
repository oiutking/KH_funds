using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public class Dep
    {
        int _dep_id=-1;
        string _dep_name, _dep_no, _dep_summary, _dep_short;

        public Boolean DeSave()
        {
            if (_dep_id == -1)
            {

            }
            else
            {

            }
            //do sql
            return false;
        }

        public Dep(int id)
        {
            string cmd = "select * from dep where 1=1 and dep_id=" + id;
            //do sql
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