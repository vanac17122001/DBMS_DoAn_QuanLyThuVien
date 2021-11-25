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
        DAL_NhanVien nv;

        public BLL_NhanVien(string username, string pass)
        {
            nv = new DAL_NhanVien(username, pass);
        }

        public DataSet getNhanVien(string username, string pass)
        {
            return nv.getNhanVien(username,pass);
        }
        public DataSet getNhanVien()
        {
            return nv.getNhanVien();
        }
        public DataSet getNhanVien(int id)
        {
            return nv.getNhanVien(id);
        }
        public bool suaNhanVien(string err, DTO_NhanVien a)
        {
            return nv.suaNhanVien(err, a);
        }
        public DataSet timNhanVienTheoTen(string ten)
        {
            return nv.timNhanVienTheoTen(ten);
        }
        public DataSet timNhanVienTheoSDT(string sdt)
        {
            return nv.timNhanVienTheoSDT(sdt);
        }
        public bool themNhanVien(string err, DTO_NhanVien a)
        {
            return nv.themNhanVien(err, a);
        }
        public bool xoaNhanVien(string err, int id)
        {
            return nv.xoaNhanVien(err, id);
        }
    }
}
