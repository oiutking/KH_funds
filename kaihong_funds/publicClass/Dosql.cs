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
        private string cnstr = System.Configuration.ConfigurationManager.AppSettings["cnstr"];
        private SqlConnection cn = new SqlConnection();
        private     Boolean sqled=false;
        private DataTable dtout = null;
        private SqlCommand command = new SqlCommand();

        public Dosql()
        {
            cn.ConnectionString = cnstr;
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
        }
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
            command.Connection = cn;
            command.CommandText = cmd;
            try
            {
                SqlDataReader dr = command.ExecuteReader();
                dtout = new DataTable();
                dtout.Load(dr);
                sqled = true;

            }
            catch(Exception ex)
            {
                sqled = false;
                dtout = null;
                throw new Exception("err on dore:"+ex.Message);
            }
            
        }



    }
}