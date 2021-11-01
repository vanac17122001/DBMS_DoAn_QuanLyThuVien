using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QuanLyThuVien
{
    public partial class formChiTietDocGia : Form
    {
        public formChiTietDocGia()
        {
            InitializeComponent();
        }
        public void loadThongTinChiTietDG(DTO_DocGia docgia)
        {
            form_ThuThu form_ThuThu = new form_ThuThu();
            /*Form formChiTietDocGia = new formChiTietDocGia();
            formChiTietDocGia.ShowDialog();*/
            //InitializeComponent();

            int id = docgia.IdDocGia;
            string _id=Convert.ToString(id);

            string ho = docgia.Ho;
            string ten = docgia.Ten;

            DateTime ngaysinh = docgia.Ngaysinh;
            string _ngaysinh=ngaysinh.ToString();

            string gioitinh = docgia.Gioitinh;
            string cmnd = docgia.CMND;
            string diachi = docgia.Diachi;
            string sdt = docgia.Sdt;
            string email = docgia.Email;

            DateTime ngaydk = docgia.Ngaydk;
            string _ngaydk = ngaydk.ToString();

            int sothe = docgia.Sothe;
            string _sothe = Convert.ToString(sothe);

            this.txtIdDG.Text = _id;
            this.txtHoDG.Text = ho;
            this.txtTenDG.Text = ten;
            this.txtNgaySinh.Text = _ngaysinh;
            this.txtGioiTinh.Text = gioitinh;
            this.txtCMND.Text = cmnd;
            this.txtDiaChi.Text = diachi;
            this.txtSDT.Text = sdt;
            this.txtEmail.Text = email;
            this.txtNgayDK.Text= _ngaydk;
            this.txtSoThe.Text = _sothe;

            if (!(docgia.AnhDG==null))
            {
                picAnhDG.Image = form_ThuThu.ConvertByteArrayToImage(docgia.AnhDG);
            }    
            this.ShowDialog();
        }

        private void formChiTietDocGia_Load(object sender, EventArgs e)
        {

        }
    }
}
