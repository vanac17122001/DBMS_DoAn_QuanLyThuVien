using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;


namespace DALayer
{
    public class DAL_DocGiaMuonSach
    {
        DBConnect conn = new DBConnect();
        public DataSet getDocGiaMuonSach()
        {
            return conn.ExecuteQueryDataset("select * from view_DocGiaMuonSach", CommandType.Text, null);
        }
        public DataSet timDocGiaMuonSach(int id)
        {
            return conn.ExecuteQueryDataset("select * from view_DocGiaMuonSach where idDocGia = @id", CommandType.Text,
                new SqlParameter("@id", id));
        }
    }
}
