using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private int _idNhanVien;
        private string _ho;
        private string _ten;
        private DateTime _ngaySinh;
        private string _gioiTinh;
        private string _CMND;
        private string _diaChi;
        private string _soDT;
        private string _email;
        private DateTime _ngayBatDau;
        private string _anhNhanVien;

        public DTO_NhanVien()
        { }

        public DTO_NhanVien(string ho, string ten, DateTime ngaysinh, string gioitinh, string cmnd, string diachi, string sodt,
                string email, DateTime ngaybatdau, string anh)
        {
            this._ho = ho;
            this._ten = ten;
            this._ngayBatDau = ngaybatdau;
            this._gioiTinh = gioitinh;
            this._CMND = cmnd;
            this._diaChi = diachi;
            this._soDT = sodt;
            this._email = email;
            this._ngaySinh = ngaysinh;
            this._anhNhanVien = anh;
        }

        public int IdNhanVien { get => _idNhanVien; set => _idNhanVien = value; }
        public string Ho { get => _ho; set => _ho = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string CMND { get => _CMND; set => _CMND = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SoDT { get => _soDT; set => _soDT = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime NgayBatDau { get => _ngayBatDau; set => _ngayBatDau = value; }
        public string AnhNhanVien { get => _anhNhanVien; set => _anhNhanVien = value; }
    }
}
