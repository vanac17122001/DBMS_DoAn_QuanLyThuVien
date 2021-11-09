using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DALayer
{
    public class DAL_DauSach
    {
        DBConnect db;

        public DAL_DauSach()
        {
            db = new DBConnect();
        }
        public DataSet getDauSach()
        {
            return db.ExecuteQueryDataset("select * from DauSach;", CommandType.Text, null);
        }
        public DataSet timDauSach(string ten)
        {
            return db.ExecuteQueryDataset("select * from fu_timSach(@ten);",
            CommandType.Text, new SqlParameter("@ten", ten));
        }
    }
}
