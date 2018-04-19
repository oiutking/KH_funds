using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public static class str2base64
    {
        public static string tostr(String base64)
        {
            byte[] c = Convert.FromBase64String(base64);
            string a = System.Text.Encoding.Default.GetString(c);
            return(a);
        }

        public static string to64(string str)
        {
            
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            string a = Convert.ToBase64String(b);
            return(a);
        }
    }
}