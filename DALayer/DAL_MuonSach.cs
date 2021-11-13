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
    public class DAL_MuonSach
    {
        DBConnect db;
        public DAL_MuonSach(string username, string pass)
        {
            db = new DBConnect(username, pass);
        }

        public DataSet getMuonSach()
        {
            return db.ExecuteQueryDataset("select * from MuonSach", CommandType.Text, null);
        }

        public bool themMuonSach(string err, DTO_MuonSach muon)
        {
            SqlParameter[] par =
    {
                    new SqlParameter("@idsach", muon.IdSach),
                    new SqlParameter("@sothedocgia", muon.IdSoThe),
                    new SqlParameter("@idnhanvien", muon.IdNhanVien)
            };
            return db.MyExecuteNonQuery("exec proc_themMuonSach @idsach, @sothedocgia, @idnhanvien",
                CommandType.Text, ref err, par);
        }
        public bool suaMuonSach(string err, DTO_MuonSach muon)
        {
            SqlParameter[] par = 
                {
                    new SqlParameter("@idmuon", muon.IdMuon),
                    new SqlParameter("@idsach", muon.IdSach),
                    new SqlParameter("@sothedocgia", muon.IdSoThe),
                    new SqlParameter("@idnhanvien", muon.IdNhanVien),
                    new SqlParameter("@ngaymuon", muon.NgayMuon)
            };
            return db.MyExecuteNonQuery("update MuonSach set idSach = @idsach, soThe = @sothedocgia, idNhanVien = @idnhanvien, " +
                "ngayMuon = @ngaymuon where idMuon = @idmuon",
                CommandType.Text, ref err, par);
        }
        public bool xoaMuonSach(string err, int id)
        {
            return db.MyExecuteNonQuery("delete from MuonSach where idMuon = @id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public DataSet timMuonSach(int id)
        {
            return db.ExecuteQueryDataset("select * from MuonSach where idMuon = @id", CommandType.Text, new SqlParameter("@id", id));
        }
    }
}
