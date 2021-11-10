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
    public class BLL_DauSach
    {
        DAL_DauSach sach = new DAL_DauSach();

        public DataSet getDauSach()
        {
            return sach.getDauSach();
        }
        public DataSet timDauSach(string ten)
        {
            return sach.timDauSach(ten);
        }
        public DataSet timDauSachTheoTenTG(String tentg)
        {
            return sach.timDauSachTheoTenTG(tentg);
        }
        public bool themDauSach(ref string err, DTO_Sach dTO_Sach)
        {
            return sach.ThemDauSach(ref err, dTO_Sach);
        }
        public bool suaDauSach (ref string err, int iddausach, string tensach, string vitri, int soluong)
        {
            return sach.SuaDauSach(ref err, iddausach, tensach, vitri, soluong);
        }
        public bool xoaDauSach(ref string err, int iddausach)
        {
            return sach.XoaDauSach(ref err, iddausach);
        }
    }
}
