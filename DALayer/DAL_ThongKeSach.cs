using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DALayer
{
    public class DAL_ThongKeSach
    {
        DBConnect db;
        public DAL_ThongKeSach(string username, string pass)
        {
            db = new DBConnect(username, pass);
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
        public DataSet getSoLuongSachTheoTheLoai()
        {
            return db.ExecuteQueryDataset("select sum(soLuong) as 'SoLuong',tenTheLoai from DauSach " +
                                    "inner join TheLoaiSach on DauSach.idTheLoai=TheLoaiSach.idTheLoai " +"group by(tenTheLoai)", 
                CommandType.Text, null);
        }
        public DataSet getSachMuonTheoTheLoai(String time1, String time2)
        {
            return db.ExecuteQueryDataset("select * from fn_SachMuonTheoLoai(@time1,@time2);", CommandType.Text,
                new SqlParameter("@time1", time1), new SqlParameter("@time2", time2));
        }
    }
}
