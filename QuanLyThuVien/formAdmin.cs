using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLayer;
using System.IO;
using DTO;

namespace QuanLyThuVien
{
    public partial class formAdmin : Form
    {
        BLL_NhanVien nv;
        BLL_Admin ad;
        DataSet ds = new DataSet();

        string f = "";

        private string username;
        private string pass;

        public string Username { get => username; set => username = value; }
        public string Pass { get => pass; set => pass = value; }

        public formAdmin(string username, string pass)
        {
            this.username = username;
            this.pass = pass;
            nv = new BLL_NhanVien(this.username, this.pass);
            ad = new BLL_Admin(username, pass);
            InitializeComponent();
        }
        public formAdmin()
        {
            nv = new BLL_NhanVien(this.username, this.pass);
            ad = new BLL_Admin(username, pass);
            InitializeComponent();
        }
        public void loadAdmin()
        {
            ds = ad.getAdmin(username, pass);
            txtIdAdmin.Text = ds.Tables[0].Rows[0][0].ToString();
            txtHoAdmin.Text = ds.Tables[0].Rows[0][1].ToString();
            txtTenAdmin.Text = ds.Tables[0].Rows[0][2].ToString();
            txtNgaySinhAdmin.Text = ds.Tables[0].Rows[0][3].ToString();
            txtGioiTinhAdmin.Text = ds.Tables[0].Rows[0][4].ToString();
            txtCMNDAdmin.Text = ds.Tables[0].Rows[0][5].ToString();
            txtDiaChiAdmin.Text = ds.Tables[0].Rows[0][6].ToString();
            txtSDTAdmin.Text = ds.Tables[0].Rows[0][7].ToString();
            txtEmailAdmin.Text = ds.Tables[0].Rows[0][8].ToString();
            btnSuaAnhAdmin.Enabled = false;
            bntLuuAdmin.Enabled = false;
            if (!(ds.Tables[0].Rows[0][9] == DBNull.Value))
            {
                picAdmin.Image = ConvertByteArrayToImage((byte[])ds.Tables[0].Rows[0][9]);
            }

        }
        public void loadNhanVien()
        {
            ds = nv.getNhanVien();
            dgvDanhSachNhanVien.DataSource = ds.Tables[0];
        }
        private void formAdmin_Load_1(object sender, EventArgs e)
        {
            loadNhanVien();
            tcQuanLyNhanVien.Size = new Size(965, 661);
            tcQuanLyNhanVien.Location = new System.Drawing.Point(208, 12);
            tcQuanLyNhanVien.Visible = true;
            gbThongTinAdmin.Visible = false;
        }

        private void btnQuanLyNhanVien_Huy_Click(object sender, EventArgs e)
        {
            loadNhanVien();
        }
        private void btnChonHinhDG_Click(object sender, EventArgs e)
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

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            loadNhanVien();
            tcQuanLyNhanVien.Size = new Size(965, 630);
            tcQuanLyNhanVien.Location = new System.Drawing.Point(208, 12);
            tcQuanLyNhanVien.Visible = true;
            gbThongTinAdmin.Visible = false;
        }

        private void btnThongTinAdmin_Click(object sender, EventArgs e)
        {
            btnSuaAnhAdmin.Enabled = false;
            bntLuuAdmin.Enabled = false;

            txtCMNDAdmin.Enabled = false;
            txtDiaChiAdmin.Enabled = false;
            txtIdAdmin.Enabled = false;
            txtHoAdmin.Enabled = false;
            txtTenAdmin.Enabled = false;
            txtSDTAdmin.Enabled = false;
            txtNgaySinhAdmin.Enabled = false;
            txtEmailAdmin.Enabled = false;
            txtGioiTinhAdmin.Enabled = false;

            gbThongTinAdmin.Size = new Size(965, 630);
            gbThongTinAdmin.Location = new System.Drawing.Point(208, 12);
            gbThongTinAdmin.Visible = true;
            tcQuanLyNhanVien.Visible = false;

            loadAdmin();
        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            string text = txtTiemKiemNhanVien.Text.ToString();
            if(rabTimKiemNhanVienTheoTen.Checked == true)
            {
                try
                {
                    ds = nv.timNhanVienTheoTen(text);
                    dgvDanhSachNhanVien.DataSource = ds.Tables[0]; 
                }
                catch
                {
                    MessageBox.Show("Lỗi trong quá trình tìm kiếm");
                }
            }
            else if (rabTimKiemNhanVienTheoSDT.Checked == true)
            {
                try
                {
                    ds = nv.timNhanVienTheoSDT(text);
                    dgvDanhSachNhanVien.DataSource = ds.Tables[0]; ;
                }
                catch
                {
                    MessageBox.Show("Lỗi trong quá trình tìm kiếm");
                }
            }
        }

        private void btnXemChiTietNhanVien_Click(object sender, EventArgs e)
        {
            int r = dgvDanhSachNhanVien.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvDanhSachNhanVien.Rows[r].Cells[0].Value);
            formChiTietNhanVien ctnv = new formChiTietNhanVien(id, this.username, this.pass);
            ctnv.ShowDialog();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            int id = 0;
            string ho = txtHoNV.Text.ToString();
            string ten = txtTenNV.Text.ToString();

            DateTime ngaysinh = Convert.ToDateTime(txtNgaySinhNV.Text);

            string gioitinh = txtGioiTinhNV.Text.ToString();
            string cmnd = txtCMNDNV.Text.ToString();
            string diachi = txtDiaChiNV.Text.ToString();
            string sdt = txtSDTNV.Text.ToString();
            string email = txtEmailNV.Text.ToString();
            DateTime ngayBatDau = Convert.ToDateTime(txtNgaySinhNV.Text);
            byte[] anhdg = null;
            if(picAnhNV.Image != null)
            { 
                anhdg = ConvertImageToBytes(picAnhNV.Image); 
            }    
            

            DTO_NhanVien DTO = new DTO_NhanVien(id, ho, ten, ngaysinh, gioitinh, cmnd,
            diachi, sdt, email, ngayBatDau, anhdg);

            string err = "Lỗi khi thêm !";
            if (nv.themNhanVien(err, DTO))
            {
                MessageBox.Show("Thêm Nhân Viên Thành Công!!!");
            }
            else
            {
                MessageBox.Show("Thêm không Thành Công\n Lỗi Dữ Liệu Nhập!!!");
            }
        }

        private void btnSuaAdmin_Click(object sender, EventArgs e)
        {
            btnSuaAnhAdmin.Enabled = true;
            bntLuuAdmin.Enabled = true;

            btnSuaAnhAdmin.Enabled = true;
            bntLuuAdmin.Enabled = true;

            txtCMNDAdmin.Enabled = true;
            txtDiaChiAdmin.Enabled = true;
            txtIdAdmin.Enabled = true;
            txtHoAdmin.Enabled = true;
            txtTenAdmin.Enabled = true;
            txtSDTAdmin.Enabled = true;
            txtNgaySinhAdmin.Enabled = true;
            txtEmailAdmin.Enabled = true;
            txtGioiTinhAdmin.Enabled = true;
        }

        private void bntLuuAdmin_Click(object sender, EventArgs e)
        {
            btnSuaAnhAdmin.Enabled = false;
            bntLuuAdmin.Enabled = false;

            txtCMNDAdmin.Enabled = false;
            txtDiaChiAdmin.Enabled = false;
            txtIdAdmin.Enabled = false;
            txtHoAdmin.Enabled = false;
            txtTenAdmin.Enabled = false;
            txtSDTAdmin.Enabled = false;
            txtNgaySinhAdmin.Enabled = false;
            txtEmailAdmin.Enabled = false;
            txtGioiTinhAdmin.Enabled = false;

            int id = Convert.ToInt32(txtIdAdmin.Text);
            string ho = txtHoAdmin.Text.ToString();
            string ten = txtTenAdmin.Text.ToString();
            DateTime ngaysinh = Convert.ToDateTime( txtNgaySinhAdmin.Text.ToString());
            string cmnd = txtCMNDAdmin.Text.ToString();
            string diachi = txtDiaChiAdmin.Text.ToString();
            string sodt = txtSDTAdmin.Text.ToString();
            string email = txtEmailAdmin.Text.ToString();
            string gioitinh = txtGioiTinhAdmin.Text.ToString();

            byte[] anhad = null;
            if (picAdmin.Image != null)
            {
                anhad = ConvertImageToBytes(picAdmin.Image);
            }
            DTO_Admin add = new DTO_Admin(id, ho,ten,ngaysinh,gioitinh,cmnd,diachi,sodt,email,anhad);
            if (ad.suaAdmin("", add))
                MessageBox.Show("Sửa thành công");
            else
                MessageBox.Show("Lõi không sửa được");
        }

        private void btnSuaAnhAdmin_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;)|*.jpg;*.jpge", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Hien thi hinh anh toi picture
                    picAdmin.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void picLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            formDangNhap formDangNhap = new formDangNhap();
            formDangNhap.ShowDialog();
            this.Close();
        }
    }
}
