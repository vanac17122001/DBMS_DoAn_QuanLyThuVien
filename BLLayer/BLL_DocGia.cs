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
        DAL_DocGia dg = new DAL_DocGia();

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
    }
}
