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
            return db.ExecuteQueryDataset("select * from InforOfBook", CommandType.Text, null);
        }
        public DataSet timDauSach(string ten)
        {
            return db.ExecuteQueryDataset("select * from fu_timSach(@ten);",
            CommandType.Text, new SqlParameter("@ten", ten));
        }
        public DataSet timDauSachTheoTenTG(string tentg)
        {
            return db.ExecuteQueryDataset("select * from [dbo].fu_timSachTheoTenTG(@tentg);",
            CommandType.Text, new SqlParameter("@tentg", tentg));
        }
    }
}
