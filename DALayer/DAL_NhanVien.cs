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
                    new SqlParameter("@ngaybatdau", nv.NgayBatDau)
            };
            return conn.MyExecuteNonQuery("update NhanVien set ho = @ho, ten = @ten" +
                ", ngaySinh = @ngaysinh, diaChi = @diachi, ngayBatDau = @ngaybatdau, CMND = @cmnd, email = @email," +
                "soDT = @sodt where idNhanVien = @id",
                CommandType.Text,ref err ,par);
        }
    }
}
