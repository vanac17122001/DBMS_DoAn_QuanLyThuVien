using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DALayer
{
    public class DAL_DangNhap
    {
        DBConnect db;
        public DAL_DangNhap(string username, string pass)
        {
            db = new DBConnect(username, pass);
        }

        public string DangNhap(user a)
         {
            try { 
                DataSet ds = new DataSet();
                ds = db.ExecuteQueryDataset("select * from fun_dangnhap(@username,@pass)", 
                    CommandType.Text, new SqlParameter("@username", a.Name), new SqlParameter("@pass", a.Pass));
                // string result = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                string result = ds.Tables[0].Rows[0][0].ToString();
                return result;
            }
            catch
            {
                return "err";
            }
        }
    }
}
