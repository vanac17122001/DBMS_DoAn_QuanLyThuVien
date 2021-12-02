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
    public class BLL_DocGia
    {
        DAL_DocGia dg;

        public BLL_DocGia(string username, string pass)
        {
            dg = new DAL_DocGia(username, pass);
        }

        public DataSet getDocGia()
        {
            return dg.getDocGia();
        }
        public DataSet timDocGia(string ten)
        {
            return dg.timDocGia(ten);
        }
        public DataSet timDocGiaTheoSoThe(int sothe)
        {
            return dg.timDocGiaTheoSoThe(sothe);
        }
        public bool themDocGia(ref string err,DTO_DocGia DTO)
        {
            return dg.ThemDocGia(ref err, DTO);
        }
        public bool suaDocGia(ref string err, DTO_DocGia DTO)
        {
            return dg.SuaDocGia(ref err, DTO);
        }
        public bool xoaDocGia (ref string err, string idDocGia)
        {
            return dg.XoaDocGia(ref err, idDocGia);
        }
        public DataSet timDocGiaTheoUsernamePass (ref string err, string username, string pass)
        {
            return dg.TimDocGiaTheoUsernamePass(ref err, username, pass);
        }
        public bool muonSach(ref string err, string idDauSach, string soThe)
        {
            return dg.muonSach(ref err, idDauSach, soThe);
        }
        public DataSet sachChuaTra(ref string err, string username, string pass)
        {
            return dg.sachChuaTra(ref err, username, pass);
        }
        public DataSet sachDaTra(ref string err, string username, string pass)
        {
            return dg.sachDaTra(ref err, username, pass);
        }
        public bool traSach(ref string err, string idmuon, int idnhanvien)
        {
            return dg.traSach(ref err, idmuon, idnhanvien);
        }
    }
}
