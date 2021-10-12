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
    public class BLL
    {
        DAL db;

        public BLL()
        {
            db = new DAL();
        }

        public DataSet getDocGia()
        {
            return db.ExecuteQueryDataset("select * from DocGia;", CommandType.Text, null);
        }
    }
}
