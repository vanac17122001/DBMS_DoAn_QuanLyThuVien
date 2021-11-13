using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using System.Data;

namespace BLLayer
{
    public class BLL_DocGiaMuonSach
    {
        DAL_DocGiaMuonSach dg;
        public BLL_DocGiaMuonSach(string username, string pass)
        {
            dg = new DAL_DocGiaMuonSach(username, pass);
        }

        public DataSet getDocGiaMuonSach()
        {
            return dg.getDocGiaMuonSach();
        }
        public DataSet timDocGiaMuonSach(int id)
        {
            return dg.timDocGiaMuonSach( id);
        }
    }
}
