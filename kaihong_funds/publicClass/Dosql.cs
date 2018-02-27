using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace kaihong_funds.publicClass
{

    public class Dosql
    {
        string cnstr = System.Configuration.ConfigurationManager.AppSettings["cnstr"];
        SqlConnection cn = new SqlConnection();
        Boolean sqled=false;
        DataTable dtout = null;
        SqlCommand command = new SqlCommand();
        public Boolean Sqled
        {
            get { return sqled; }
        }

        public DataTable DtOut
        {
            get { return dtout; }
        }

        public void DoNoRe(string[] cmd)
        {
            cn.Open();
            command.Connection = cn;
            SqlTransaction Tran = cn.BeginTransaction();
            command.Transaction = Tran;
            try
            {
                foreach (string i in cmd)
                {
                    command.CommandText = i;
                    command.ExecuteNonQuery();
                }
                Tran.Commit();
                sqled = true;
            }
            catch
            {
                Tran.Rollback();
                sqled = false;
                throw new Exception("Err on DoNore");
            }
        }

        public void DoRe(string cmd)
        {
            cn.Open();
            command.Connection = cn;
            command.CommandText = cmd;
            try
            {
                SqlDataReader dr = command.ExecuteReader();
                dtout.Load(dr);
                sqled = true;

            }
            catch
            {
                sqled = false;
                dtout = null;
                throw new Exception("err on dore");
            }
            
        }



    }
}