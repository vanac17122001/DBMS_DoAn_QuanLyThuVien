using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace BLLayer
{
    public class BLL_ThongKeDocGia
    {
        DAL_ThongKeDocGia dg;

        public BLL_ThongKeDocGia(string username, string pass)
        {
            dg = new DAL_ThongKeDocGia(username, pass);
        }
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
        public DataSet getthongtin(string from, string to)
        {
            return dg.getthongtin(from, to);
        }
        public DataSet gettongphattheongay(string from, string to)
        {
            return dg.gettongphattheongay(from, to);
        }
        public DataSet getTienThang12(string year)
        {
            return dg.getTienThang12(year);
        }
        public DataSet getTienThang1(string year)
        {
            return dg.getTienThang1(year);
        }
        public DataSet getTienThang2(string year)
        {
            return dg.getTienThang2(year);
        }
        public DataSet getTienThang3(string year)
        {
            return dg.getTienThang3(year);
        }
        public DataSet getTienThang4(string year)
        {
            return dg.getTienThang4(year);
        }
        public DataSet getTienThang5(string year)
        {
            return dg.getTienThang5(year);
        }
        public DataSet getTienThang6(string year)
        {
            return dg.getTienThang6(year);
        }
        public DataSet getTienThang7(string year)
        {
            return dg.getTienThang7(year);
        }
        public DataSet getTienThang8(string year)
        {
            return dg.getTienThang8(year);
        }
        public DataSet getTienThang9(string year)
        {
            return dg.getTienThang9(year);
        }
        public DataSet getTienThang10(string year)
        {
            return dg.getTienThang10(year);
        }
        public DataSet getTienThang11(string year)
        {
            return dg.getTienThang11(year);
        }
    }

}
