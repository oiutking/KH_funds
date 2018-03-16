using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace kaihong_funds.publicClass
{
    public class bill
    {
        private int _bill_id=-1, _bill_id_body, _bill_type, _payfrom, _payto, _maker, _prnt, _op, _dep_id,_payfrom_no,_payto_no;
        private decimal _amount;
        private string _bill_id_head, _summary, _secret;
        private Boolean _isdel, _iscx;
        private DateTime _make_date;


        public void save()
        {
            try
            {
                if (_bill_id != -1)
                {
                    string cmdstr = "update  [bill] set bill_id_head=@bill_id_head";
                           cmdstr += ",bill_id_body=@bill_id_body";
                           cmdstr += ",bill_type=@bill_type";
                           cmdstr += ",payfrom=@payfrom";
                           cmdstr += ",payto=@payto";
                           cmdstr += ",amount=@amount";
                           cmdstr += ",summary=@summary";
                           cmdstr += ",maker=@maker";
                           cmdstr += ",make_date=@make_date";
                           cmdstr += ",isdel=@isdel";
                           cmdstr += ",iscx=@iscx";
                           cmdstr += ",prnt=@prnt";
                           cmdstr += ",op=@op";
                           cmdstr += ",dep_id=@depid";
                           cmdstr += ",secret=@secret";
                           cmdstr += ",payfrom_no=@payfrom_no";
                           cmdstr += ",payto_no=@payto_no";
                           cmdstr +=" where bill_id=" + _bill_id;
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@bill_id_head", "@bill_id_body", "@bill_type", "@payfrom","@payto","@amount" ,"@summary","@maker","@make_date","@isdel","@iscx","@prnt","@op","@dep_id","@secret","@payfrom_no","@payto_no"};
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Int, SqlDbType.Int, SqlDbType.BigInt, SqlDbType.BigInt, SqlDbType.Decimal, SqlDbType.Text, SqlDbType.BigInt, SqlDbType.Date, SqlDbType.Bit, SqlDbType.Bit, SqlDbType.Int, SqlDbType.BigInt, SqlDbType.BigInt, SqlDbType.Text ,SqlDbType.BigInt,SqlDbType.BigInt};
                    input._par_val = new object[] { _bill_id_head,_bill_id_body,_bill_type,_payfrom,_payto,_amount,_summary,_maker,_make_date,_isdel,_iscx,_prnt,_op,_dep_id,_secret,_payfrom_no,_payto_no };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);

                }
                else
                {
                    string cmdstr = "insert into [bill] values(@bill_id_head,@bill_id_body,@bill_type, @payfrom,@payto,@amount,@summary,@maker,@make_date,@isdel,@iscx,@prnt,@op,@dep_id,@secret,@payfrom_no,@payto_no)";
                    Dosql ds = new Dosql();
                    DS_input input = new DS_input();
                    input._cmd = cmdstr;
                    input._par_name = new string[] { "@bill_id_head", "@bill_id_body", "@bill_type", "@payfrom", "@payto", "@amount", "@summary", "@maker", "@make_date", "@isdel", "@iscx", "@prnt", "@op", "@dep_id", "@secret","@payfrom_no","@payto_no" };
                    input._par_type = new SqlDbType[] { SqlDbType.Text, SqlDbType.Int, SqlDbType.Int, SqlDbType.BigInt, SqlDbType.BigInt, SqlDbType.Decimal, SqlDbType.Text, SqlDbType.BigInt, SqlDbType.Date, SqlDbType.Bit, SqlDbType.Bit, SqlDbType.Int, SqlDbType.BigInt, SqlDbType.BigInt, SqlDbType.Text,SqlDbType.BigInt,SqlDbType.BigInt };
                    input._par_val = new object[] { _bill_id_head, _bill_id_body, _bill_type, _payfrom, _payto, _amount, _summary, _maker, _make_date, _isdel, _iscx, _prnt, _op, _dep_id, _secret,_payfrom_no,_payto_no };
                    DS_input[] iii = { input };
                    ds.DoNoRe(iii);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bill() { }

        public bill(int id)
        {
            string cmd = "select * from bill where 1=1 and bill_id=" + id;
            Dosql ds = new Dosql();
            ds.DoRe(cmd);
            if (ds.Sqled)
            {
                DataTable _dtuser = ds.DtOut;
                if (_dtuser.Rows.Count == 1)
                {
                    //int 9
                    _bill_id = Convert.ToInt32(_dtuser.Rows[0]["bill_id"]);
                    _bill_id_body = Convert.ToInt32(_dtuser.Rows[0]["bill_id_body"]);
                    _bill_type = Convert.ToInt32(_dtuser.Rows[0]["bill_type"]);
                    _payfrom = Convert.ToInt32(_dtuser.Rows[0]["payfrom"]);
                    _payto= Convert.ToInt32(_dtuser.Rows[0]["payto"]);
                    _prnt= Convert.ToInt32(_dtuser.Rows[0]["prnt"]);
                    _op = Convert.ToInt32(_dtuser.Rows[0]["op"]);
                    _dep_id = Convert.ToInt32(_dtuser.Rows[0]["dep_id"]);
                    _payfrom_no = Convert.ToInt32(_dtuser.Rows[0]["payfrom_no"]);
                    _payfrom_no = Convert.ToInt32(_dtuser.Rows[0]["payto_no"]);

                    // decimal 1
                    _amount = Convert.ToDecimal(_dtuser.Rows[0]["amount"]);

                    //string 3
                    _bill_id_head = _dtuser.Rows[0]["dep_id"].ToString();
                    _summary = _dtuser.Rows[0]["summary"].ToString();
                    _secret= _dtuser.Rows[0]["secret"].ToString();

                    //boolean 2
                    _isdel = Convert.ToBoolean(_dtuser.Rows[0]["isdel"]);
                    _iscx = Convert.ToBoolean(_dtuser.Rows[0]["iscx"]);

                    //datetime 1
                    _make_date = Convert.ToDateTime(_dtuser.Rows[0]["isdel"]);

                }
            }
            else
            {
                throw new Exception("err on creat sig by id");
            }
        }


        public int Bill_id
        {
            get { return _bill_id; }
        }

        public int Bill_id_body
        {
            get { return _bill_id_body; }
            set { _bill_id_body = value; }
        }

        public int Bill_type
        {
            get { return _bill_type; }
            set { _bill_type = value; }
        }

        public int Payfrom
        {
            get { return _payfrom; }
            set { _payfrom = value; }
        }

        public int Payto
        {
            get { return _payto; }
            set { _payto = value; }
        }

        public int Maker
        {
            get { return _maker; }
            set { _maker = value; }
        }

        public int Prnt
        {
            get { return _prnt; }
            set { _prnt = value; }
        }

        public int Op
        {
            get { return _op; }
            set { _op = value; }
        }

        public int Dep_id
        {
            get { return _dep_id; }
            set { _dep_id = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Summary
        { get { return _summary; } set { _summary = value; } }

        public string Bill_id_head
        { get { return _bill_id_head; } set { _bill_id_head = value; } }

        public string Secret
        {            get { return _secret; }            set { _secret = value; }        }

        public Boolean Isdel
        { get { return _isdel; } set { _isdel = value; }  }

        public Boolean Iscx
        { get { return _iscx; } set { _iscx = value; } }

        public DateTime Make_date
        { get { return _make_date; } set { _make_date = value; } }

        public Int32 Payfrom_no
        {
            get { return _payfrom_no; }
            set { _payfrom_no = value; }
        }
        public Int32 Payto_no
        {
            get { return _payto_no; }
            set { _payto_no = value; }
        }
    }
}