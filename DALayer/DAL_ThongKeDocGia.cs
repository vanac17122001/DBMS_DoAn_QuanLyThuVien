using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class DAL_ThongKeDocGia
    {
        DBConnect db;

        public DAL_ThongKeDocGia(string usernme, string pass)
        {
            db = new DBConnect(usernme,pass);
        }
        public DataSet getallDocGia()
        {
            return db.ExecuteQueryDataset("select * from DocGia;", CommandType.Text, null);
        }
        public DataSet getDocGiaMuonSach1()
        {
            return db.ExecuteQueryDataset("select DISTINCT * from fun_docgiamuonsach()", CommandType.Text, null);
        }
        public DataSet getTongphat()
        {
            return db.ExecuteQueryDataset("proc_tongphat", CommandType.StoredProcedure, null);
        }
        public DataSet getDocGiaTraTre()
        {
            return db.ExecuteQueryDataset("select DISTINCT * from fun_docgiatrasachtre()", CommandType.Text, null);
        }
        public DataSet getDanhSachPhat()
        {
            return db.ExecuteQueryDataset("select * from fun_danhsachphattien ();", CommandType.Text, null);
        }
        public DataSet getmaxPhat()
        {
            return db.ExecuteQueryDataset("proc_maxphat", CommandType.StoredProcedure, null);
        }
    }
}
