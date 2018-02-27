using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public class CheckLogin
    {
        private Uer _uer;
        private Boolean _logined;

        public CheckLogin(Uer u)
        {
            if (u.Uexsit && u.Ustate)
            {
                _logined = true;
            }
            else
            {
                _logined = false;
            }
        }

        public Boolean Logined
            {
            get { return _logined; }
            }
        public Uer Cuer
        {
            get { return _uer; }
        }
    }
}