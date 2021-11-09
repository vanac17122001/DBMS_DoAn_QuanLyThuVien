using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace BLLayer
{
    public class BLL_MuonSach
    {
        DAL_MuonSach muonsach = new DAL_MuonSach();
        public DataSet getMuonSach()
        {
            return muonsach.getMuonSach();
        }
        public bool suaMuonSach(string err, DTO_MuonSach dtomuon)
        {
            return muonsach.suaMuonSach(err, dtomuon);
        }
        public bool themMuonSach(string err, DTO_MuonSach dtomuon)
        {
            return muonsach.themMuonSach(err, dtomuon);
        }
        public bool xoaMuonSach(string err, int id)
        {
            return muonsach.xoaMuonSach(err, id);
        }
        public DataSet timMuonSach(int id)
        {
            return muonsach.timMuonSach(id);
        }
    }
}
