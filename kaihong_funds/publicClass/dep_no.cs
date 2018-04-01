using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public class dep_no
    {
        string _no_name, _no, _summary;
        Boolean _status;
        int _dep_id;

        public dep_no(int id)
        {
            string cmd = "select * from depno where 1=1 and no_id=" + id;
            publicClass.Dosql ds = new Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled && ds.DtOut.Rows.Count >=1)
            {
                _no = ds.DtOut.Rows[0][2].ToString();
                _no_name= ds.DtOut.Rows[0][1].ToString();
                _summary= ds.DtOut.Rows[0][5].ToString();
                _status = Convert.ToBoolean(ds.DtOut.Rows[0][3].ToString());
                _dep_id = Convert.ToInt32(ds.DtOut.Rows[0][4].ToString());
            }
            else
            {
                throw new Exception("creat dep_no err!");
            }
            
        }

        public Boolean Status
        {
            get { return _status; }
        }

        public string No_name
        {
            get { return _no_name; }
        }

        public string No
        {
            get { return _no; }
        }

        public string Summary
        {
            get { return _summary; }
        }
    }
}