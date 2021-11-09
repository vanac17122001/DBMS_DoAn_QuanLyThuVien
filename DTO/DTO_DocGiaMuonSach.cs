using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DocGiaMuonSach
    {
        private string _hoTen;
        private int _idMuonMuon;
        private int _idSach;
        private int _idNhanVienMuon;
        private DateTime _ngayMuon;
        private int _idTraSach;
        private DateTime _ngayTra;
        private int _idNhanVienTra;

        public DTO_DocGiaMuonSach()
        { }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public int IdMuonMuon { get => _idMuonMuon; set => _idMuonMuon = value; }
        public int IdSach { get => _idSach; set => _idSach = value; }
        public int IdNhanVienMuon { get => _idNhanVienMuon; set => _idNhanVienMuon = value; }
        public DateTime NgayMuon { get => _ngayMuon; set => _ngayMuon = value; }
        public int IdTraSach { get => _idTraSach; set => _idTraSach = value; }
        public DateTime NgayTra { get => _ngayTra; set => _ngayTra = value; }
        public int IdNhanVienTra { get => _idNhanVienTra; set => _idNhanVienTra = value; }
    }
}
