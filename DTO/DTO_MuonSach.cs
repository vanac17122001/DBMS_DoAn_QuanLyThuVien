using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTO_MuonSach
    {
        private int _idMuon;
        private int _idSach;
        private int _idSoThe;
        private int _idNhanVien;
        private DateTime _ngayMuon;
        private DateTime _ngayTra;

        public DTO_MuonSach()
        { }
        public DTO_MuonSach(int idmuon, int idsach, int sothe, int idnhanvien, DateTime ngaymuon, DateTime ngaytra)
        {
            this._idMuon = idmuon;
            this._idSach = idsach;
            this._idSoThe = sothe;
            this._idNhanVien = idnhanvien;
            this._ngayTra = ngaytra;
            this._ngayMuon = ngaymuon;
        }
        public DTO_MuonSach(int idsach, int sothe, int idnhanvien)
        {
            this._idSach = idsach;
            this._idSoThe = sothe;
            this._idNhanVien = idnhanvien;
        }

        public int IdMuon { get => _idMuon; set => _idMuon = value; }
        public int IdSach { get => _idSach; set => _idSach = value; }
        public int IdSoThe { get => _idSoThe; set => _idSoThe = value; }
        public int IdNhanVien { get => _idNhanVien; set => _idNhanVien = value; }
        public DateTime NgayMuon { get => _ngayMuon; set => _ngayMuon = value; }
        public DateTime NgayTra { get => _ngayTra; set => _ngayTra = value; }
    }
}
