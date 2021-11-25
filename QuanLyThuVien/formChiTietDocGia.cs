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
using BLLayer;
using System.IO;

namespace QuanLyThuVien
{
    public partial class formChiTietDocGia : Form
    {
        BLL_DocGia BLL_DocGia;
        private string username;
        private string pass;
        public formChiTietDocGia(string username, string pass)
        {
            this.username = username;
            this.pass = pass;
            BLL_DocGia = new BLL_DocGia(username, pass);
            InitializeComponent();
            
        }

        public void loadThongTinChiTietDG(DTO_DocGia docgia)
        {
            form_ThuThu form_ThuThu = new form_ThuThu(username, pass);
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

            this.txtHoDG.Enabled = false;
            this.txtTenDG.Enabled = false;
            this.txtGioiTinh.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtDiaChi.Enabled = false;
            this.txtCMND.Enabled = false;
            this.txtNgayDK.Enabled = false;
            this.txtSDT.Enabled = false;
            this.txtNgaySinh.Enabled = false;
            this.btnLuuDocGia.Enabled = false;
            this.ShowDialog();
        }

        private void formChiTietDocGia_Load(object sender, EventArgs e)
        {

        }

        private void btnSuaDocGia_Click(object sender, EventArgs e)
        {
            this.txtHoDG.Enabled = true;
            this.txtTenDG.Enabled = true;
            this.txtGioiTinh.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtDiaChi.Enabled = true;
            this.txtCMND.Enabled = true;
            this.txtNgayDK.Enabled = true;
            this.txtSDT.Enabled = true;
            this.txtNgaySinh.Enabled = true;
            this.btnLuuDocGia.Enabled = true;

            this.btnXoaDG.Enabled = false;
        }

        private void btnLuuDocGia_Click(object sender, EventArgs e)
        {
            string idDocGia = txtIdDG.Text;
            int _idDocGia = int.Parse(idDocGia);
            string ho = txtHoDG.Text;
            string ten = txtTenDG.Text;

            string ngaysinh = txtNgaySinh.Text;
            DateTime _ngaysinh = Convert.ToDateTime(ngaysinh);

            string gioitinh = txtGioiTinh.Text;
            string cmnd = txtCMND.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;

            string ngaydk = txtNgaySinh.Text;
            DateTime _ngaydk = Convert.ToDateTime(ngaydk);

            string sothe = txtSoThe.Text;
            int _sothe = int.Parse(sothe);

            byte[] anhdg = ConvertImageToBytes(picAnhDG.Image);

            DTO_DocGia DTO = new DTO_DocGia(_idDocGia, ho, ten, _ngaysinh, gioitinh, cmnd,
            diachi, sdt, email, _ngaydk, _sothe, anhdg);
            //DTO_DocGia docgia = new DTO_DocGia();
            //DTO.(ho, ten, _ngaysinh, gioitinh, cmnd, diachi, sdt, email, _ngaydk, anhdg);
            string err = "Lỗi khi thêm !";
            if (BLL_DocGia.suaDocGia(ref err, DTO))
            {
                MessageBox.Show("Sửa Độc Giả Thành Công!!!");
            }
            else
            {
                MessageBox.Show("Sửa không Thành Công\n Lỗi Dữ Liệu Nhập!!!");
            }

            this.btnXoaDG.Enabled = true;
            this.btnLuuDocGia.Enabled = false;
        }

        private void btnChonHinhDG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;)|*.jpg;*.jpge", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Hien thi hinh anh toi picture
                    picAnhDG.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            string idDocGia = this.txtIdDG.Text;

            string err = "Lỗi khi thêm !";
            if (BLL_DocGia.xoaDocGia(ref err, idDocGia))
            {
                MessageBox.Show("Xóa Độc Giả Thành Công!!!");
            }
            else
            {
                MessageBox.Show("Xóa không Thành Công\n Lỗi Dữ Liệu!!!");
            }
            this.Close();
        }
        public byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        // Chuyen kieu byte sang Image
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
