using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DALayer;
namespace BLLayer
{
    public class BLL_ThongKeDocGia
    {
        DAL_ThongKeDocGia dg = new DAL_ThongKeDocGia();

        public DataSet getallDocGia()
        {
            return dg.getallDocGia();
        }
        public DataSet getDocGiaMuonSach1()
        {
            return dg.getDocGiaMuonSach1();
        }
        public DataSet getTongphat()
        {
            return dg.getTongphat();
        }
        public DataSet getDocGiaTraTre()
        {
            return dg.getDocGiaTraTre();
        }
        public DataSet getDanhSachPhat()
        {
            return dg.getDanhSachPhat();
        }
        public DataSet getmaxPhat()
        {
            return dg.getmaxPhat();
        }
    }

}
