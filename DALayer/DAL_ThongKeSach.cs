using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DALayer
{
    public class DAL_ThongKeSach
    {
        DBConnect db;
        public DAL_ThongKeSach()
        {
            db = new DBConnect();
        }
        public DataSet getSachDaDuocMuon()
        {
            return db.ExecuteQueryDataset("select * from fun_sachdaduocmuon()", CommandType.Text, null);
        }
        public DataSet getSachChuaDuocMuon()
        {
            return db.ExecuteQueryDataset("select * from fun_sachchuaduocmuon()", CommandType.Text, null);
        }
        public DataSet getSachMuonNhieuNhat()
        {
            return db.ExecuteQueryDataset("proc_sachmuonnhiunhat", CommandType.StoredProcedure, null);
        }
    }
}
