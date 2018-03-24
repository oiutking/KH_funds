using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public class MSE
    {
        private DateTime _s, _e;

        public DateTime S
        {
            get { return _s; }
        }
        public DateTime E
        {
            get { return _e; }
        }

        public MSE(DateTime indate)
        {
            _s =Convert.ToDateTime(indate.Year+"年"+indate.Month+"月1日");           
            int M = indate.Month;
            int year = indate.Year;
            if (M == 2)
            {
                if ((year % 400 == 0) || (year % 4 == 0) && (year % 100 != 0))
                {
                     _e = Convert.ToDateTime(indate.Year + "年" + indate.Month + "月29日");
                }
                else
                {
                    _e = Convert.ToDateTime(indate.Year + "年" + indate.Month + "月28日");
                }

            }
            else
            {
                switch (M)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        _e = Convert.ToDateTime(indate.Year + "年" + indate.Month + "月31日");
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        _e = Convert.ToDateTime(indate.Year + "年" + indate.Month + "月30日");
                        break;
                }
            }
        }

    }
}