using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_DocGia
    {
        private int _idDocGia;
        private string _ho;
        private string _ten;
        private DateTime _ngaysinh;
        private string _gioitinh;
        private string _CMND;
        private string _diachi;
        private string _sdt;
        private string _email;
        private DateTime _ngaydk;
        private int _sothe;

        public DTO_DocGia()
        { }

        public DTO_DocGia(int id, string ho, string ten, DateTime ngaysinh, string gt, string cmnd,
            string diachi, string sdt, string email, DateTime ngaydk, int sothe)
        {
            this._idDocGia = id;
            this._ho = ho;
            this._ten = ten;
            this._ngaysinh = ngaysinh;
            this._gioitinh = gt;
            this._CMND = cmnd;
            this._diachi = diachi;
            this._sdt = sdt;
            this._email = email;
            this._ngaydk = ngaydk;
            this._sothe = sothe;

        }

        public int IdDocGia { get => _idDocGia; set => _idDocGia = value; }
        public string Ho { get => _ho; set => _ho = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public DateTime Ngaysinh { get => _ngaysinh; set => _ngaysinh = value; }
        public string Gioitinh { get => _gioitinh; set => _gioitinh = value; }
        public string CMND { get => _CMND; set => _CMND = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Sdt { get => _sdt; set => _sdt = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime Ngaydk { get => _ngaydk; set => _ngaydk = value; }
        public int Sothe { get => _sothe; set => _sothe = value; }
    }
}
