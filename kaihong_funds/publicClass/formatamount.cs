using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public static class formatamount
    {
        public static string format(decimal x )
        {
            string str = x.ToString();
            string[] han = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string[] jiez = { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾" };
            string[] jiex = { "角", "分" };
            string tmpz = "";
            string tmpx = "";
            string outcome = "";
            if (str.Length > 0)
            {
                string[] temp = str.Split('.');

                for (int i = 0; i < temp[0].Length; i++)
                {
                    tmpz += (han[Convert.ToInt16(temp[0].Substring(i, 1))] + jiez[temp[0].Length - i - 1]);
                }
                if (temp.Length > 1)
                {
                    for (int i = 0; i < temp[1].Length; i++)
                    {
                        tmpx += (han[Convert.ToInt16(temp[1].Substring(i, 1))] + jiex[i]);
                    }
                    outcome = tmpz + tmpx;
                }
                else
                {
                    outcome = tmpz + "整";
                }

            }
            else
            {
                outcome = "";
            }

            outcome = outcome.Replace("零拾", "零");
            outcome = outcome.Replace("零佰", "零");
            outcome = outcome.Replace("零仟", "零");

            outcome = outcome.Replace("零零零零零零零零", "零");
            outcome = outcome.Replace("零零零零零零零", "零");
            outcome = outcome.Replace("零零零零零零", "零");
            outcome = outcome.Replace("零零零零零", "零");
            outcome = outcome.Replace("零零零零", "零");
            outcome = outcome.Replace("零零零", "零");
            outcome = outcome.Replace("零零", "零");
            outcome = outcome.Replace("零万", "万");
            outcome = outcome.Replace("零亿", "亿");
            outcome = outcome.Replace("亿万", "亿");
            outcome = outcome.Replace("零元", "元");
            outcome = outcome.Replace("零角零分", "整");
            outcome = outcome.Replace("零角", "");
            outcome = outcome.Replace("零分", "");
            return outcome;

        }

    }
}
