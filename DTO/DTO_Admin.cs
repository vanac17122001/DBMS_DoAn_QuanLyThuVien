using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTO_Admin
    {
        private int _id;
        private string _ho;
        private string _ten;
        private DateTime _ngaySinh;
        private string _gioiTinh;
        private string _CMND;
        private string _diaChi;
        private string _soDT;
        private string _email;
        private byte[] _anh;

        public DTO_Admin(int id, string ho, string ten, DateTime ngaysinh, string gioitinh, string cmnd, string diachi, string sodt, string email,
            byte[] anh)
        {
            this._id = id;
            this._ho = ho;
            this._ten = ten;
            this._ngaySinh = ngaysinh;
            this._gioiTinh = gioitinh;
            this._CMND = cmnd;
            this._diaChi = diachi;
            this._soDT = sodt;
            this._email = email;
            this._anh = anh;
        }
        public DTO_Admin(string ho, string ten, DateTime ngaysinh, string gioitinh, string cmnd, string diachi, string sodt, string email,
    byte[] anh)
        {
            this._ho = ho;
            this._ten = ten;
            this._ngaySinh = ngaysinh;
            this._gioiTinh = gioitinh;
            this._CMND = cmnd;
            this._diaChi = diachi;
            this._soDT = sodt;
            this._email = email;
            this._anh = anh;
        }

        public int Id { get => _id; set => _id = value; }
        public string Ho { get => _ho; set => _ho = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string CMND { get => _CMND; set => _CMND = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SoDT { get => _soDT; set => _soDT = value; }
        public string Email { get => _email; set => _email = value; }
        public byte[] Anh { get => _anh; set => _anh = value; }
    }
}
