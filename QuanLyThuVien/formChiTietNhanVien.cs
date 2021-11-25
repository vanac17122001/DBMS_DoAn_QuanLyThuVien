using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BLLayer;
using DTO;
using System.IO;

namespace QuanLyThuVien
{
    public partial class formChiTietNhanVien : Form
    {
        BLL_NhanVien nv;
        private int id;
        private string username;
        private string pass;
        string f = "";

        DataSet ds = new DataSet();
        public formChiTietNhanVien()
        {
            InitializeComponent();
        }
        public formChiTietNhanVien(int id, string username, string pass)
        {
            this.id = id;
            this.username = username;
            this.pass = pass;
            nv = new BLL_NhanVien(this.username, this.pass);
            InitializeComponent();
        }

        public void loadNhanVien()
        {
            ds = nv.getNhanVien(this.id);
            this.txtIdNV.Text = ds.Tables[0].Rows[0][0].ToString();
            this.txtHoNV.Text = ds.Tables[0].Rows[0][1].ToString();
            this.txtTenNV.Text = ds.Tables[0].Rows[0][2].ToString();
            this.txtNgaySinhNV.Text = ds.Tables[0].Rows[0][3].ToString();
            this.txtGioiTinhNV.Text = ds.Tables[0].Rows[0][4].ToString();
            this.txtCMNDNV.Text = ds.Tables[0].Rows[0][5].ToString();
            this.txtDiaChiNV.Text = ds.Tables[0].Rows[0][6].ToString();
            this.txtSDTNV.Text = ds.Tables[0].Rows[0][7].ToString();
            this.txtEmailNV.Text = ds.Tables[0].Rows[0][8].ToString();
            this.txtNgayBDNV.Text = ds.Tables[0].Rows[0][9].ToString();

            if (!(ds.Tables[0].Rows[0][10] == DBNull.Value))
            {
                picAnhNV.Image = ConvertByteArrayToImage( (byte[])ds.Tables[0].Rows[0][10]);
            }

            txtIdNV.Enabled = false;
            txtHoNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtNgaySinhNV.Enabled = false;
            txtGioiTinhNV.Enabled = false;
            txtCMNDNV.Enabled = false;
            txtDiaChiNV.Enabled = false;
            txtSDTNV.Enabled = false;
            txtNgayBDNV.Enabled = false;
            txtEmailNV.Enabled = false;

            btnLuuNV.Enabled = false;
        }

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            if (nv.xoaNhanVien("", id))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
                MessageBox.Show("Không xóa được");
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            f = "sua";
            btnXoaNV.Enabled = false;
            txtIdNV.Enabled = true;
            txtHoNV.Enabled = true;
            txtTenNV.Enabled = true;
            txtNgaySinhNV.Enabled = true;
            txtGioiTinhNV.Enabled = true;
            txtCMNDNV.Enabled = true;
            txtDiaChiNV.Enabled = true;
            txtSDTNV.Enabled = true;
            txtNgayBDNV.Enabled = true;
            txtEmailNV.Enabled = true;

            btnXoaNV.Enabled = false;
            btnLuuNV.Enabled = true;

        }

        private void formChiTietNhanVien_Load(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        private void btnChonHinhNV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;)|*.jpg;*.jpge", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Hien thi hinh anh toi picture
                    picAnhNV.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {

            int idNV = Convert.ToInt32(txtIdNV.Text.ToString());
            string ho = txtHoNV.Text.ToString();
            string ten = txtTenNV.Text.ToString();

            DateTime ngaysinh = Convert.ToDateTime( txtNgaySinhNV.Text);

            string gioitinh = txtGioiTinhNV.Text.ToString();
            string cmnd = txtCMNDNV.Text.ToString();
            string diachi = txtDiaChiNV.Text.ToString();
            string sdt = txtSDTNV.Text.ToString();
            string email = txtEmailNV.Text.ToString();
            DateTime ngayBatDau = Convert.ToDateTime( txtNgaySinhNV.Text);

            byte[] anhdg = null; 
            if( picAnhNV.Image != null) { 
                 anhdg = ConvertImageToBytes(picAnhNV.Image); 
            }
            

            DTO_NhanVien DTO = new DTO_NhanVien(idNV, ho, ten, ngaysinh, gioitinh, cmnd,
            diachi, sdt, email, ngayBatDau, anhdg);
            //DTO_DocGia docgia = new DTO_DocGia();
            //DTO.(ho, ten, _ngaysinh, gioitinh, cmnd, diachi, sdt, email, _ngaydk, anhdg);
            string err = "Lỗi khi sửa !";
            if (nv.suaNhanVien(err, DTO))
            {
                MessageBox.Show("Sửa Nhân Viên Thành Công!!!");
            }
            else
            {
                MessageBox.Show("Sửa không Thành Công\n Lỗi Dữ Liệu Nhập!!!");
            }
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

        private void btnHuyNV_Click(object sender, EventArgs e)
        {
            btnLuuNV.Enabled = false;
            btnXoaNV.Enabled = true;
            btnSuaNV.Enabled = true;

            txtIdNV.Enabled = false;
            txtHoNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtNgaySinhNV.Enabled = false;
            txtGioiTinhNV.Enabled = false;
            txtCMNDNV.Enabled = false;
            txtDiaChiNV.Enabled = false;
            txtSDTNV.Enabled = false;
            txtNgayBDNV.Enabled = false;
            txtEmailNV.Enabled = false;
        }
    }
}
