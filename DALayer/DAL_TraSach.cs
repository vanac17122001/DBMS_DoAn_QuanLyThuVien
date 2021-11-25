using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DALayer
{
   public class DAL_TraSach
    {
        DBConnect conn;

        public DAL_TraSach(string username, string pass)
        {
            conn = new DBConnect(username, pass);
        }

        public DataSet getTraSach()
        {
            return conn.ExecuteQueryDataset("select * from TraSach", CommandType.Text, null);
        }

        public bool themTraSach(string err, DTO_TraSach tra)
        {
            SqlParameter[] par =
            {
                    new SqlParameter("@idmuonsach", tra.IdMuonSach),
                    new SqlParameter("@idnhanvien", tra.IdNhanVien)
            };
            return conn.MyExecuteNonQuery("exec proc_themTraSach @idmuonsach, @idnhanvien",
                CommandType.Text, ref err, par);
        }
        public bool suaTraSach(string err, DTO_TraSach Tra)
        {
            SqlParameter[] par =
                {
                    new SqlParameter("@idmuon", Tra.IdMuonSach),
                    new SqlParameter("@ngaytra", Tra.NgayTra),
                    new SqlParameter("@idnhanvien", Tra.IdNhanVien),
                    new SqlParameter("@idtra", Tra.IdTraSach)
            };
            return conn.MyExecuteNonQuery("update TraSach set idMuon = @idmuon, ngayTra = @ngaytra, idNhanVien = @idnhanvien" +"where idTraSach=@idtra",
                CommandType.Text, ref err, par);
        }
        public bool xoaTraSach(string err, int id)
        {
            return conn.MyExecuteNonQuery("delete from TraSach where idMuon = @id", CommandType.Text, ref err, new SqlParameter("@id", id));
        }
        public DataSet timTraSach(int id)
        {
            return conn.ExecuteQueryDataset("select * from TraSach where idMuon = @id", CommandType.Text, new SqlParameter("@id", id));
        }
    }
}
