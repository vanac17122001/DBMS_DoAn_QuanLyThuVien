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
    public class DAL_NhanVien
    {
        DBConnect conn;
        public DAL_NhanVien(string username, string pass)
        {
            conn = new DBConnect(username, pass);
        }
        public DataSet getNhanVien(string username, string pass)
        {
            SqlParameter[] par =
            {
                    new SqlParameter("@username", username),
                    new SqlParameter("@pass", pass)
            };
            return conn.ExecuteQueryDataset("select * from view_thongTinNhanVien where userName = @username and pass = @pass", 
                CommandType.Text, par);
        }
        public DataSet getNhanVien()
        {
            return conn.ExecuteQueryDataset("select * from NhanVien",
                CommandType.Text, null);
        }
        public DataSet getNhanVien(int id)
        {
            return conn.ExecuteQueryDataset("select * from NhanVien where idNhanVien = @id",
                CommandType.Text, new SqlParameter("@id",id));
        }

        public bool suaNhanVien(string err, DTO_NhanVien nv)
        {
            SqlParameter[] par =
            {
                    new SqlParameter("@id", nv.IdNhanVien),
                    new SqlParameter("@ho", nv.Ho),
                    new SqlParameter("@ten", nv.Ten),
                    new SqlParameter("@ngaysinh", nv.NgaySinh),
                    new SqlParameter("@cmnd", nv.CMND),
                    new SqlParameter("@diachi", nv.DiaChi),
                    new SqlParameter("@sodt", nv.SoDT),
                    new SqlParameter("@email", nv.Email),
                    new SqlParameter("@ngaybatdau", nv.NgayBatDau),
                    new SqlParameter("@gioitinh", nv.GioiTinh),
                    new SqlParameter("@anh", nv.AnhNhanVien)
            };
            return conn.MyExecuteNonQuery("update NhanVien set ho = @ho, ten = @ten" +
                ", ngaySinh = @ngaysinh, diaChi = @diachi, ngayBatDau = @ngaybatdau, CMND = @cmnd, email = @email," +
                "soDT = @sodt, gioiTinh = @gioitinh, anhNV = @anh where idNhanVien = @id",
                CommandType.Text,ref err ,par);
        }
        public DataSet timNhanVienTheoTen(string ten)
        {
            return conn.ExecuteQueryDataset("select * from fu_timTenNhanVien(@ten);",
            CommandType.Text, new SqlParameter("@ten", ten));
        }
        public DataSet timNhanVienTheoSDT(string sdt)
        {
            return conn.ExecuteQueryDataset("select * from fu_timSDTNhanVien(@sdt);",
            CommandType.Text, new SqlParameter("@sdt", sdt));
        }
        public bool themNhanVien( string err, DTO_NhanVien DTO)
        {
            return conn.MyExecuteNonQuery("sp_ThemNhanVien", CommandType.StoredProcedure, ref err,
                new SqlParameter { ParameterName = "@ho", Value = DTO.Ho },
                new SqlParameter { ParameterName = "@ten", Value = DTO.Ten },
                new SqlParameter { ParameterName = "@ngaySinh", Value = DTO.NgaySinh },
                new SqlParameter { ParameterName = "@gioiTinh", Value = DTO.GioiTinh },
                new SqlParameter { ParameterName = "@CMND", Value = DTO.CMND },
                new SqlParameter { ParameterName = "@diaChi", Value = DTO.DiaChi },
                new SqlParameter { ParameterName = "@soDT", Value = DTO.SoDT },
                new SqlParameter { ParameterName = "@email", Value = DTO.Email },
                new SqlParameter { ParameterName = "@anh", Value = DTO.AnhNhanVien }
                );
        }
        public bool xoaNhanVien(string err , int id)
        {
            return conn.MyExecuteNonQuery("delete from NhanVien where idNhanVien = @id", CommandType.Text, ref err, new SqlParameter("@id",id));
        }
    }
}
