using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using System.Data;
using System.Data.SqlClient;

namespace BLLayer
{
    public class BLL_SachDocGiaDaMuon
    {
        DAL_SachDocDaMuon dg;

        public BLL_SachDocGiaDaMuon(string username, string pass)
        {
            dg = new DAL_SachDocDaMuon(username, pass);
        }

        public DataSet getThingTinSachDaMuon (string username, string pass)
        {
            return dg.getThongTinSachDaMuon(username, pass);
        }
    }
}
