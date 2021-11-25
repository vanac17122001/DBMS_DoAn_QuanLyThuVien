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
   public class DAL_Admin
    {
        DBConnect db;
        public DAL_Admin(string username, string pass)
        {
            db = new DBConnect(username, pass);
        }
        public DataSet getAdmin(string username,string pass)
        {
            SqlParameter[] par =
            {
                    new SqlParameter("@username", username),
                    new SqlParameter("@pass", pass)
            };
            return db.ExecuteQueryDataset("select * from view_thongTinAdmin where userName = @username and pass = @pass",
                CommandType.Text, par);
        }
        public bool suaAdmin(string err, DTO_Admin ad)
        {
            SqlParameter[] par =
            {
                    new SqlParameter("@id", ad.Id),
                    new SqlParameter("@ho", ad.Ho),
                    new SqlParameter("@ten", ad.Ten),
                    new SqlParameter("@ngaysinh", ad.NgaySinh),
                    new SqlParameter("@cmnd", ad.CMND),
                    new SqlParameter("@diachi", ad.DiaChi),
                    new SqlParameter("@sodt", ad.SoDT),
                    new SqlParameter("@email", ad.Email),
                    new SqlParameter("@gioitinh", ad.GioiTinh),
                    new SqlParameter("@anh", ad.Anh)
            };
            return db.MyExecuteNonQuery("update QuanTri set ho = @ho, ten = @ten" +
                ", ngaySinh = @ngaysinh, diaChi = @diachi, CMND = @cmnd, email = @email," +
                "soDT = @sodt, gioiTinh = @gioitinh, anhAdmin = @anh where idAdmin = @id",
                CommandType.Text, ref err, par);
        }
    }
}
