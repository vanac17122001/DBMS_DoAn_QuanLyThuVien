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
            return db.ExecuteQueryDataset("select idDocGia,ho,ten,ngaySinh,gioiTinh,CMND,diaChi,soDT,email,ngayDK,soThe from DocGia;", CommandType.Text, null);
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
        public DataSet getthongtin(string from, string to)
        {
            return db.ExecuteQueryDataset("select * from fun_danhsachphattien() where ngayTra >= '" + from + "' and ngayTra <='" + to + "'", CommandType.Text, null);
        }
        public DataSet gettongphattheongay(string from, string to)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat) as 'TongTienPhat' from fun_danhsachphattien() where ngayTra >= '" + from + "' and ngayTra <='" + to + "'", CommandType.Text, null);
        }
        //Thống kê tiền phạt theo năm (12 tháng)
        public DataSet getTienThang12(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='12') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang1(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='1') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang2(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='2') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang3(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='3') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang4(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='4') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang5(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='5') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang6(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='6') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang7(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='7') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang8(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='8') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang9(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='9') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang10(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='10') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getTienThang11(string year)
        {
            return db.ExecuteQueryDataset("select sum(soTienPhat)  from fun_danhsachphattien() where (month(ngayTra)='11') and (YEAR(ngayTra)='" + year + "');", CommandType.Text, null);
        }
        public DataSet getDocGiaChuaTraSach()
        {
            return db.ExecuteQueryDataset("select DISTINCT * from fun_docGiaDangMuonSach()", CommandType.Text, null);
        }
    }
}
