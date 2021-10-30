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
    public class DAL_DocGia
    {
        DBConnect db;

        public DAL_DocGia()
        {
            db = new DBConnect();
        }
        public DataSet getDocGia()
        {
            return db.ExecuteQueryDataset("select * from DocGia;", CommandType.Text, null);
        }
        public DataSet timDocGia(string ten)
        {
            return db.ExecuteQueryDataset("select * from fu_timTenDocGia(@ten);",
            CommandType.Text, new SqlParameter("@ten", ten));
        }
        public DataSet timDocGiaTheoSoThe(int sothe)
        {
            return db.ExecuteQueryDataset("select * from fu_timTheDocGia(@sothe);",
            CommandType.Text, new SqlParameter("@sothe", sothe));
        }
    }
}
