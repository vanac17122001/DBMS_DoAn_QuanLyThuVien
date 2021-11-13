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
    public class DAL_DauSach
    {
        DBConnect db;

        public DAL_DauSach(string username, string pass)
        {
            db = new DBConnect(username,pass);
        }
        public DataSet getDauSach()
        {
            return db.ExecuteQueryDataset("select * from InforOfBook", CommandType.Text, null);
        }
        public DataSet timDauSach(string ten)
        {
            return db.ExecuteQueryDataset("select * from fu_timSach(@ten);",
            CommandType.Text, new SqlParameter("@ten", ten));
        }
        public DataSet timDauSachTheoTenTG(string tentg)
        {
            return db.ExecuteQueryDataset("select * from [dbo].fu_timSachTheoTenTG(@tentg);",
            CommandType.Text, new SqlParameter("@tentg", tentg));
        }
        public bool ThemDauSach(ref string err,DTO_Sach dTO_Sach)
        {
            return db.MyExecuteNonQuery("sp_Insert_Sach", CommandType.StoredProcedure, ref err,
                new SqlParameter { ParameterName = "@tenSach", Value = dTO_Sach.Tensach},
                new SqlParameter { ParameterName = "@butDanh", Value = dTO_Sach.Butdanh },
                new SqlParameter { ParameterName = "@tenNXB", Value = dTO_Sach.TenNXB },
                new SqlParameter { ParameterName = "@namXB", Value = dTO_Sach.NamXB },
                new SqlParameter { ParameterName = "@theLoai", Value = dTO_Sach.Theloai },
                new SqlParameter { ParameterName = "@gia", Value = dTO_Sach.Gia },
                new SqlParameter { ParameterName = "@soLuong", Value = dTO_Sach.Soluong },
                new SqlParameter { ParameterName = "@vitri", Value = dTO_Sach.Vitri },
                new SqlParameter { ParameterName = "@anhDS", Value = dTO_Sach.AnhDS }
                );
        }

        public bool SuaDauSach (ref string err, int iddausach, string tensach, string vitri, int soluong)
        {
            return db.MyExecuteNonQuery("sp_UpdateBook", CommandType.StoredProcedure, ref err,
                new SqlParameter { ParameterName = "@idDauSach", Value = iddausach},
                new SqlParameter { ParameterName = "@tenSach", Value = tensach},
                new SqlParameter { ParameterName = "@vitri", Value = vitri},
                new SqlParameter { ParameterName = "@soLuong", Value = soluong}
                );
        }
        public bool XoaDauSach (ref string err, int iddausach)
        {
            return db.MyExecuteNonQuery("sp_XoDauSach", CommandType.StoredProcedure, ref err,
                 new SqlParameter { ParameterName = "@idDauSach", Value = iddausach });
        }
    }
}
