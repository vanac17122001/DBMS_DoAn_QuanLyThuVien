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
   public class BLL_Admin
    {
        DBConnect db;
        DAL_Admin ad;

        public BLL_Admin(string username, string pass)
        {
            db = new DBConnect(username, pass);
            ad = new DAL_Admin(username, pass);
        }
        public DataSet getAdmin(string username, string pass)
        {
            return ad.getAdmin(username, pass);
        }
        public bool suaAdmin(string err, DTO_Admin add)
        {
            return ad.suaAdmin(err, add);
        }
    }
}
