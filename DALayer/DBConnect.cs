using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DALayer
{
    public class DBConnect
    {
        public SqlConnection conn = null;
        public SqlCommand comm = null;
        public SqlDataAdapter da = null;

        public DBConnect(string username, string pass)
        {
            string ConnStr = "Data Source=" + "localhost" + ";Initial Catalog="
                        + "Database_CNPM" + ";Persist Security Info=True;User ID=" + username + ";Password=" + pass; 
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }
        public DataSet ExecuteQueryDataset(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            comm.Parameters.Clear();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            if (p != null)
            {
                foreach (SqlParameter x in p)
                    comm.Parameters.Add(x);
            }
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            comm.Parameters.Clear();
            return ds;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
    }
}
