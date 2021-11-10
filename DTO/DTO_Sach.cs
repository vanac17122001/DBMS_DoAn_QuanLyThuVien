using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Sach
    {
        private string _tensach;
        private string _butdanh;
        private string _tenNXB;
        private DateTime _namXB;
        private string _theloai;
        private int _gia;
        private int _soluong;
        private string _vitri;
        private byte[] _anhDS;

        public DTO_Sach ()
        { }

        public DTO_Sach (string tensach, string butdanh,
            string tenNXB, DateTime namXB, string theloai, int gia, int soluong, string vitri,byte[] anhDS)
        {
            this._tensach = tensach;
            this._butdanh = butdanh;
            this._tenNXB = tenNXB;
            this._namXB = namXB;
            this._theloai = theloai;
            this._gia = gia;
            this._soluong = soluong;
            this._vitri = vitri;
            this._anhDS = anhDS;
        }

        public string Tensach { get => _tensach; set => _tensach = value; }
        public string Butdanh { get => _butdanh; set => _butdanh = value; }
        public string TenNXB { get => _tenNXB; set => _tenNXB = value; }
        public DateTime NamXB { get => _namXB; set => _namXB = value; }
        public string Theloai { get => _theloai; set => _theloai = value; }
        public int Gia { get => _gia; set => _gia = value; }
        public int Soluong { get => _soluong; set => _soluong = value; }
        public string Vitri { get => _vitri; set => _vitri = value; }
        public byte[] AnhDS { get => _anhDS; set => _anhDS = value; }
    }
}
