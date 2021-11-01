using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using System.Data;

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
    }
}
