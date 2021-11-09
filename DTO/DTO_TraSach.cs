using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TraSach
    {
        private int _idTraSach;
        private int _idMuonSach;
        private DateTime _ngayTra;
        private int _idNhanVien;

        public DTO_TraSach()
        { }
        public DTO_TraSach(int idtrasach, int idmuonsach, DateTime ngaytra, int idnhanvien)
        {
            this._idTraSach = idtrasach;
            this._idMuonSach = idmuonsach;
            this._ngayTra = ngaytra;
            this._idNhanVien = idnhanvien;
        }
        public DTO_TraSach(int idmuonsach, int idnhanvien)
        {
            this._idMuonSach = idmuonsach;
            this._idNhanVien = idnhanvien;
        }

        public int IdTraSach { get => _idTraSach; set => _idTraSach = value; }
        public int IdMuonSach { get => _idMuonSach; set => _idMuonSach = value; }
        public DateTime NgayTra { get => _ngayTra; set => _ngayTra = value; }
        public int IdNhanVien { get => _idNhanVien; set => _idNhanVien = value; }
    }
}
