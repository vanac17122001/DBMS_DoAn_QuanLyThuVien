using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using System.Data;
using DTO;

namespace BLLayer
{
    public class BLL_NhanVien
    {
        DAL_NhanVien nv = new DAL_NhanVien();
        public DataSet getNhanVien(string username, string pass)
        {
            return nv.getNhanVien(username,pass);
        }

        public bool suaNhanVien(string err, DTO_NhanVien a)
        {
            return nv.suaNhanVien(err, a);
        }
    }
}
