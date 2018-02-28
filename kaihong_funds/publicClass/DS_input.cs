using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class DS_input
    {
        public string _cmd;
        public string[] _par_name;
        public SqlDbType[] _par_type;
        public object[] _par_val;
    }
}