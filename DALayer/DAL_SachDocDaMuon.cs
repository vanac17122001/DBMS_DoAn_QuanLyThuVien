using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DALayer
{
    public class DAL_SachDocDaMuon
    {
        DBConnect db;
        public DAL_SachDocDaMuon(string username,string pass)
        {
            db = new DBConnect(username, pass);
        }
        public DataSet getThongTinSachDaMuon (string username, string pass)
        {
            return db.ExecuteQueryDataset("select * from fu_ThongTinMuonSachCuaDocGia(@username,@pass);",
                CommandType.Text, new SqlParameter("@username", username), new SqlParameter("@pass", pass));
        }
    }
}
