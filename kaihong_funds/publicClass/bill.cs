using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kaihong_funds.publicClass
{
    public class bill
    {
        private int _bill_id, _bill_id_body, _bill_type, _payfrom, _payto, _maker, _prnt, _op, _dep_id;
        private decimal _amount;
        private string _bill_id_head, _summary, _secret;
        private Boolean _isdel, _iscx;
        private DateTime _make_date;

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
    }
}