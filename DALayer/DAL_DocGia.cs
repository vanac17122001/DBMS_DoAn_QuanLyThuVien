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
    public class DAL_DocGia
    {
        DBConnect db;

        public DAL_DocGia(string username, string pass)
        {
            db = new DBConnect(username, pass);
        }
        public DataSet getDocGia()
        {
            return db.ExecuteQueryDataset("select * from DocGia;", CommandType.Text, null);
        }
        public DataSet timDocGia(string ten)
        {
            return db.ExecuteQueryDataset("select * from fu_timTenDocGia(@ten);",
            CommandType.Text, new SqlParameter("@ten", ten));
        }
        public DataSet timDocGiaTheoSoThe(int sothe)
        {
            return db.ExecuteQueryDataset("select * from fu_timTheDocGia(@sothe);",
            CommandType.Text, new SqlParameter("@sothe", sothe));
        }
        public bool ThemDocGia(ref string err,DTO_DocGia DTO)
        {
            return db.MyExecuteNonQuery("sp_ThemDocGia", CommandType.StoredProcedure, ref err,
                new SqlParameter { ParameterName = "@ho", Value = DTO.Ho},
                new SqlParameter { ParameterName = "@ten", Value = DTO.Ten },
                new SqlParameter { ParameterName = "@ngaySinh", Value = DTO.Ngaysinh},
                new SqlParameter { ParameterName = "@gioiTinh", Value = DTO.Gioitinh},
                new SqlParameter { ParameterName = "@CMND", Value = DTO.CMND },
                new SqlParameter { ParameterName = "@diaChi", Value = DTO.Diachi },
                new SqlParameter { ParameterName = "@soDT", Value = DTO.Sdt },
                new SqlParameter { ParameterName = "@email", Value = DTO.Email},
                new SqlParameter { ParameterName = "@anhDG", Value = DTO.AnhDG }
                );
        }
        public bool SuaDocGia (ref string err, DTO_DocGia DTO)
        {
            return db.MyExecuteNonQuery("sp_SuaDocGia", CommandType.StoredProcedure, ref err,
                new SqlParameter { ParameterName = "@idDocGia", Value = DTO.IdDocGia},
                new SqlParameter { ParameterName = "@ho", Value = DTO.Ho },
                new SqlParameter { ParameterName = "@ten", Value = DTO.Ten },
                new SqlParameter { ParameterName = "@ngaySinh", Value = DTO.Ngaysinh },
                new SqlParameter { ParameterName = "@gioiTinh", Value = DTO.Gioitinh },
                new SqlParameter { ParameterName = "@CMND", Value = DTO.CMND },
                new SqlParameter { ParameterName = "@diaChi", Value = DTO.Diachi },
                new SqlParameter { ParameterName = "@soDT", Value = DTO.Sdt },
                new SqlParameter { ParameterName = "@email", Value = DTO.Email },
                new SqlParameter { ParameterName = "@ngayDK", Value = DTO.Ngaydk },
                new SqlParameter { ParameterName = "@soThe", Value = DTO.Sothe },
                new SqlParameter { ParameterName = "@anhDG", Value = DTO.AnhDG }
                );
        }
        public bool XoaDocGia(ref string err, string idDocGia)
        {
            return db.MyExecuteNonQuery("sp_XoaDocGia", CommandType.StoredProcedure, ref err,
                new SqlParameter { ParameterName = "@idDocGia", Value = idDocGia });
        }
        public DataSet TimDocGiaTheoUsernamePass(ref string err, string username, string pass)
        {
            return db.ExecuteQueryDataset("select * from fu_ThongTinDocGiaDangNhap(@username,@pass);",
                CommandType.Text, new SqlParameter("@username", username), new SqlParameter("@pass", pass));
        }
        public bool muonSach(ref string err, string idDauSach, string sothe)
        {
            return db.MyExecuteNonQuery("proc_docGiaMuonSach", CommandType.StoredProcedure, ref err,
                new SqlParameter { ParameterName = "@idDauSach", Value = idDauSach },
                new SqlParameter { ParameterName = "@soThe", Value = sothe });
        }
        public DataSet sachChuaTra(ref string err, string username, string pass)
        {
            return db.ExecuteQueryDataset("select * from fu_sachChuaTra(@username,@pass);",
                CommandType.Text, new SqlParameter("@username", username), new SqlParameter("@pass", pass));
        }
        public DataSet sachDaTra(ref string err, string username, string pass)
        {
            return db.ExecuteQueryDataset("select * from fu_sachDaTra(@username,@pass);",
                CommandType.Text, new SqlParameter("@username", username), new SqlParameter("@pass", pass));
        }
        public bool traSach(ref string err, string idmuon, int idnhanvien)
        {
            SqlParameter[] par =
            {
                    new SqlParameter("@idmuonsach", idmuon),
                    new SqlParameter("@idnhanvien", idnhanvien)
            };
            return db.MyExecuteNonQuery("exec proc_themTraSach @idmuonsach, @idnhanvien",
                CommandType.Text, ref err, par);
        }
    }
}
