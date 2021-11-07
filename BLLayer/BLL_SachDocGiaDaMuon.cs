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
        DAL_SachDocDaMuon DAL_SachDocDaMuon = new DAL_SachDocDaMuon();

        public DataSet getThingTinSachDaMuon (string username, string pass)
        {
            return DAL_SachDocDaMuon.getThongTinSachDaMuon(username, pass);
        }
    }
}
