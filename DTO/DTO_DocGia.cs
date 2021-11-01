using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DocGia
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
        private byte[] _anhDG;

        public DTO_DocGia()
        { }

        public DTO_DocGia(int id, string ho, string ten, DateTime ngaysinh, string gt, string cmnd,
            string diachi, string sdt, string email, DateTime ngaydk, int sothe, byte[] anhDG)
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
            this._anhDG = anhDG;

        }
        public DTO_DocGia DTO_ThemDocGia(string ho, string ten, DateTime ngaysinh, string gt, string cmnd,
           string diachi, string sdt, string email, DateTime ngaydk,byte[] anhDG)
        {
            DTO_DocGia dTO_DocGia = new DTO_DocGia();
            //this._idDocGia = id;
            dTO_DocGia._ho = ho;
            dTO_DocGia._ten = ten;
            dTO_DocGia._ngaysinh = ngaysinh;
            dTO_DocGia._gioitinh = gt;
            dTO_DocGia._CMND = cmnd;
            dTO_DocGia._diachi = diachi;
            dTO_DocGia._sdt = sdt;
            dTO_DocGia._email = email;
            dTO_DocGia._ngaydk = ngaydk;
            //this._sothe = sothe;
            dTO_DocGia._anhDG = anhDG;

            return dTO_DocGia;

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
        public byte[] AnhDG { get => _anhDG; set => _anhDG = value; }
    }
}
