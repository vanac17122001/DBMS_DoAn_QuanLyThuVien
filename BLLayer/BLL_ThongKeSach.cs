using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DALayer;
using System.Data;

namespace BLLayer
{
    public class BLL_ThongKeSach
    {
        DAL_ThongKeSach dg = new DAL_ThongKeSach();
        public DataSet getSachDaDuocMuon()
        {
            return dg.getSachDaDuocMuon();
        }
        public DataSet getSachChuaDuocMuon()
        {
            return dg.getSachChuaDuocMuon();
        }
        public DataSet getSachMuonNhieuNhat()
        {
            return dg.getSachMuonNhieuNhat();
        }
    }
}
