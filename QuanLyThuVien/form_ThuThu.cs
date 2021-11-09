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


namespace QuanLyThuVien
{
    public partial class form_ThuThu : Form
    {
        BLL_DocGia docgia = new BLL_DocGia();
        BLL_DauSach dausach = new BLL_DauSach();
        BLL_MuonSach muon = new BLL_MuonSach();
        BLL_TraSach tra = new BLL_TraSach();
        BLL_DocGiaMuonSach dgmuon = new BLL_DocGiaMuonSach();
        BLL_NhanVien nv = new BLL_NhanVien();
        DataSet ds = new DataSet();
        string f = "";

        private string username;
        private string pass;

        public string Username { get => username; set => username = value; }
        public string Pass { get => pass; set => pass = value; }

        public form_ThuThu()
        {
            InitializeComponent();
            btnQuanLySach_Click(null, null);
        }
        public form_ThuThu(string username, string pass)
        {
            InitializeComponent();
            btnQuanLySach_Click(null, null);
            this.username = username;
            this.pass = pass;
        }
        public void loadDocGia()
        {
            ds = docgia.getDocGia();
            dagDanhSachDocGia.DataSource = ds.Tables[0];
        }
        public void loadDauSach()
        {
            ds = dausach.getDauSach();
            dagDanhSachDauSach.DataSource = ds.Tables[0];
        }

        public void loadMuonSach()
        {
            ds = muon.getMuonSach();
            dgvMuonSach.DataSource = ds.Tables[0];
        }
        public void loadTrasach()
        {
            ds = tra.getTraSach();
            dgvMuonTra_TraSach.DataSource = ds.Tables[0];
        }
        public void loadDocGiaMuonSach()
        {
            ds = dgmuon.getDocGiaMuonSach();
            dgvMuonTra_DocGiaMuonSachDocGia.DataSource = ds.Tables[0];
        }
        public void loadNhanVien(string username, string pass)
        {
            ds = nv.getNhanVien(username, pass);
            txtThuThu_IdNhanVien.Text = ds.Tables[0].Rows[0][0].ToString();
            txtThuThu_HoNhanVien.Text = ds.Tables[0].Rows[0][1].ToString();
            txtThuThu_TenNhanVien.Text = ds.Tables[0].Rows[0][2].ToString();
            txtThuThu_NgaySinhNhanVien.Text = ds.Tables[0].Rows[0][3].ToString();
            txtThuThu_CMNDNhanVien.Text = ds.Tables[0].Rows[0][5].ToString();
            txtThuThu_DiaChiNhanVien.Text = ds.Tables[0].Rows[0][6].ToString();
            txtThuThu_SDTNhanVien.Text = ds.Tables[0].Rows[0][7].ToString();
            txtThuThu_EmailNhanVien.Text = ds.Tables[0].Rows[0][8].ToString();
            txtThuThu_NgayLamNhanVien.Text = ds.Tables[0].Rows[0][9].ToString();
        }
        private void btnThongTinThuThu_Click(object sender, EventArgs e)
        {
            tcQuanLyDocGia.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcThongTinSach.Visible = false;
            tcQuanLyMuonTra.Visible = false;
            gbThongTinThuThu.Size = new Size(965, 661);
            gbThongTinThuThu.Visible = true;
            gbThongTinThuThu.Location= new System.Drawing.Point(252, 38);
            loadNhanVien(this.username, this.pass);

            txtThuThu_IdNhanVien.Enabled = false;
            txtThuThu_HoNhanVien.Enabled = false;
            txtThuThu_TenNhanVien.Enabled = false;
            txtThuThu_NgaySinhNhanVien.Enabled = false;
            txtThuThu_CMNDNhanVien.Enabled = false;
            txtThuThu_DiaChiNhanVien.Enabled = false;
            txtThuThu_SDTNhanVien.Enabled = false;
            txtThuThu_EmailNhanVien.Enabled = false;
            txtThuThu_NgayLamNhanVien.Enabled = false;
        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            tcQuanLyDocGia.Visible = false;
            tcThongTinSach.Visible = false;
            tcQuanLyMuonTra.Visible = false;
            gbThongTinThuThu.Visible = false;
            tcThongKeBaoCao.Size = new Size(965, 661);
            tcThongKeBaoCao.Visible = true;
            tcThongKeBaoCao.Location= new System.Drawing.Point(252, 38);
        }

        private void btnQuanLyDocGia_Click(object sender, EventArgs e)
        {
            tcQuanLyMuonTra.Visible = false;
            gbThongTinThuThu.Visible = false;
            tcThongTinSach.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcQuanLyDocGia.Size = new Size(965, 661);
            tcQuanLyDocGia.Location= new System.Drawing.Point(252, 38);
            loadDocGia();
            tcQuanLyDocGia.Visible = true;



            //lấy thông tin độc giả

        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            tcQuanLyMuonTra.Visible = false;
            gbThongTinThuThu.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcQuanLyDocGia.Visible = false;
            tcThongTinSach.Size = new Size(965, 661);
            tcThongTinSach.Location= new System.Drawing.Point(252, 38);
            loadDauSach();
            tcThongTinSach.Visible = true;
        }

        private void tcQuanLyMuonTra_Click(object sender, EventArgs e)
        {
            tcQuanLyDocGia.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcThongTinSach.Visible = false;
            gbThongTinThuThu.Visible = false;
            tcQuanLyMuonTra.Size= new Size(965, 661);
            tcQuanLyMuonTra.Location = new System.Drawing.Point(252, 38);
            tcQuanLyMuonTra.Visible = true;
            loadMuonSach();
            txtMuonTra_IdMuonTraSach.Enabled = false;
            txtMuonTra_IdTraTraSach.Enabled = false;
            txtMuonTra_NgayTraTraSach.Enabled = false;
            txtMuonTra_IdNhanVienTraSach.Enabled = false;
            loadTrasach();
            txtMuonTra_IdMuonSach.Enabled = false;
            txtMuonTra_IdNhanVien.Enabled = false;
            txtMuonTra_NgayMuon.Enabled = false;
            txtMuonTra_IdSachMuonSach.Enabled = false;
            txtMuonTra_HanTra.Enabled = false;
            txtMuonTra_IdSachMuonSach.Enabled = false;
            txtMuonTra_TheDocGia.Enabled = false;
            loadDocGiaMuonSach();
        }

        private void btnXemChiTietDocGia_Click(object sender, EventArgs e)
        {
            Form formChiTietDocGia = new formChiTietDocGia();
            formChiTietDocGia.ShowDialog();
        }

        private void btnTimKiemDocGia_Click(object sender, EventArgs e)
        {
            if(rabTimKiemDocGiaTheoTen.Checked == true) 
            { 
                string ten = txtTiemKiemDocGia.Text.ToString();
                ds = docgia.timDocGia(ten);
                dagDanhSachDocGia.DataSource = ds.Tables[0];
            }
            else if (rabTimKiemDocGiaTheoSoThe.Checked == true)
            {
                int sothe = int.Parse(txtTiemKiemDocGia.Text);
                ds = docgia.timDocGiaTheoSoThe(sothe);
                dagDanhSachDocGia.DataSource = ds.Tables[0];
            }
        }

        private void btnTimKiemDauSach_Click(object sender, EventArgs e)
        {
            if(rabTimKiemTenDauSach.Checked == true)
            {
                string ten = txtTimKiemDauSach.Text.ToString();
                ds = dausach.timDauSach(ten);
                dagDanhSachDauSach.DataSource = ds.Tables[0];
            }
        }
        // xử lý phần bảng mượn sách
        private void dgvMuonSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvMuonSach.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMuonTra_IdMuonSach.Text = dgvMuonSach.Rows[r].Cells[0].Value.ToString();
            this.txtMuonTra_IdSachMuonSach.Text = dgvMuonSach.Rows[r].Cells[1].Value.ToString();
            this.txtMuonTra_TheDocGia.Text = dgvMuonSach.Rows[r].Cells[2].Value.ToString();
            this.txtMuonTra_IdNhanVien.Text = dgvMuonSach.Rows[r].Cells[3].Value.ToString();
            this.txtMuonTra_NgayMuon.Text = dgvMuonSach.Rows[r].Cells[4].Value.ToString();
            this.txtMuonTra_HanTra.Text = dgvMuonSach.Rows[r].Cells[5].Value.ToString();
        }

        private void btnMuonTra_ThemMuonSach_Click(object sender, EventArgs e)
        {
            txtMuonTra_IdMuonSach.Enabled = false;
            txtMuonTra_IdNhanVien.Enabled = true;
            txtMuonTra_NgayMuon.Enabled = false;
            txtMuonTra_IdSachMuonSach.Enabled = true;
            txtMuonTra_HanTra.Enabled = false;
            txtMuonTra_TheDocGia.Enabled = true;
            this.btnMuonTra_SuaMuonSach.Enabled = false;
            this.btnMuonTra_XoaMuonSach.Enabled = false;
            f = "them";
        }

        private void btnThemTra_HuyMuonSach_Click(object sender, EventArgs e)
        {
            txtMuonTra_IdMuonSach.Enabled = false;
            txtMuonTra_TheDocGia.Enabled = false;
            txtMuonTra_IdNhanVien.Enabled = false;
            txtMuonTra_NgayMuon.Enabled = false;
            txtMuonTra_IdSachMuonSach.Enabled = false;
            txtMuonTra_HanTra.Enabled = false;
            this.btnMuonTra_SuaMuonSach.Enabled = true;
            this.btnMuonTra_XoaMuonSach.Enabled = true;
            this.btnMuonTra_ThemMuonSach.Enabled = true;
            f = "";
            loadMuonSach();
        }

        private void btnMuonTra_LuuMuonSach_Click(object sender, EventArgs e)
        {
            try {
                if(f == "them") {
                    int thedocgia = Convert.ToInt32(txtMuonTra_TheDocGia.Text);
                    int idsach = Convert.ToInt32(txtMuonTra_IdSachMuonSach.Text);
                    int idnhanvien = Convert.ToInt32(txtMuonTra_IdNhanVien.Text);
                    DTO_MuonSach dtomuonsach = new DTO_MuonSach(idsach, thedocgia, idnhanvien);
                    muon.themMuonSach("", dtomuonsach);
                    MessageBox.Show("Thêm thành công");
                }
                else if (f == "sua")
                {
                    int thedocgia = Convert.ToInt32(txtMuonTra_TheDocGia.Text);
                    int idsach = Convert.ToInt32(txtMuonTra_IdSachMuonSach.Text);
                    int idnhanvien = Convert.ToInt32(txtMuonTra_IdNhanVien.Text);
                    int idmuon = Convert.ToInt32(txtMuonTra_IdMuonSach.Text);
                    DateTime ngaymuon = Convert.ToDateTime(txtMuonTra_NgayMuon.Text);
                    DateTime hantra = Convert.ToDateTime(txtMuonTra_HanTra.Text);
                    DTO_MuonSach dtomuonsach = new DTO_MuonSach(idmuon, idsach, thedocgia, idnhanvien, ngaymuon, hantra);
                    muon.suaMuonSach("", dtomuonsach);
                    MessageBox.Show("Sửa thành công");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi không thực hiện được");
            }
            loadMuonSach();
            
        }

        private void btnMuonTra_SuaMuonSach_Click(object sender, EventArgs e)
        {
            txtMuonTra_IdMuonSach.Enabled = false;
            txtMuonTra_IdNhanVien.Enabled = true;
            txtMuonTra_NgayMuon.Enabled = true;
            txtMuonTra_IdSachMuonSach.Enabled = true;
            txtMuonTra_HanTra.Enabled = true;
            txtMuonTra_TheDocGia.Enabled = true;
            this.btnMuonTra_ThemMuonSach.Enabled = false;
            btnMuonTra_XoaMuonSach.Enabled = false;
            f = "sua";
        }

        private void btnMuonTra_XoaMuonSach_Click(object sender, EventArgs e)
        {
            int idmuon = Convert.ToInt32(txtMuonTra_IdMuonSach.Text);
            try { 
                muon.xoaMuonSach("", idmuon);
                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi không xóa được");
            }
            loadMuonSach();
        }

        private void btnMuonTra_TimMuonSach_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMuonTra_TimMuonSach.Text);
            ds = muon.timMuonSach(id);
            dgvMuonSach.DataSource = ds.Tables[0];
        }
 //Sử lý phần thông tin mượn trả, trả sách

        private void btnMuonTra_ThemTraSach_Click(object sender, EventArgs e)
        {
            txtMuonTra_IdMuonTraSach.Enabled = true;
            txtMuonTra_NgayTraTraSach.Enabled = false;
            txtMuonTra_IdNhanVienTraSach.Enabled = true;
            this.btnMuonTra_SuaMuonTra.Enabled = false;
            this.btnMuonTra_XoaMuonTra.Enabled = false;
            f = "them";
        }

        private void dgvMuonTra_TraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvMuonTra_TraSach.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMuonTra_IdTraTraSach.Text = dgvMuonTra_TraSach.Rows[r].Cells[0].Value.ToString();
            this.txtMuonTra_IdMuonTraSach.Text = dgvMuonTra_TraSach.Rows[r].Cells[1].Value.ToString();
            this.txtMuonTra_NgayTraTraSach.Text = dgvMuonTra_TraSach.Rows[r].Cells[2].Value.ToString();
            this.txtMuonTra_IdNhanVienTraSach.Text = dgvMuonTra_TraSach.Rows[r].Cells[3].Value.ToString();
        }

        private void btnMuonTra_HuyTraSach_Click(object sender, EventArgs e)
        {
            txtMuonTra_IdTraTraSach.Enabled = false;
            txtMuonTra_IdMuonTraSach.Enabled = false;
            txtMuonTra_NgayTraTraSach.Enabled = false;
            txtMuonTra_IdNhanVienTraSach.Enabled = false;
            this.btnMuonTra_ThemTraSach.Enabled = true;
            this.btnMuonTra_SuaMuonTra.Enabled = true;
            this.btnMuonTra_XoaMuonTra.Enabled = true;
            f = "";
            loadTrasach();
        }

        private void btnMuonTra_SuaMuonTra_Click(object sender, EventArgs e)
        {
            txtMuonTra_IdMuonTraSach.Enabled = true;
            txtMuonTra_NgayTraTraSach.Enabled = true;
            txtMuonTra_IdNhanVienTraSach.Enabled = true;
            this.btnMuonTra_XoaMuonTra.Enabled = false;
            this.btnMuonTra_ThemTraSach.Enabled = false;
            f = "sua";
        }

        private void btnMuonTra_LuuTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (f == "them")
                {
                    int idmuon = Convert.ToInt32(txtMuonTra_IdMuonTraSach.Text);
                    int idnhanvien = Convert.ToInt32(txtMuonTra_IdNhanVienTraSach.Text);
                    DTO_TraSach dtotrasach = new DTO_TraSach(idmuon, idnhanvien);
                    if( tra.themTraSach("", dtotrasach))
                        MessageBox.Show("Thêm thành công");
                    else MessageBox.Show("Lỗi câu lệnh truy vấn");
                }
                else if (f == "sua")
                {
                    int idmuon = Convert.ToInt32(txtMuonTra_IdMuonTraSach.Text);
                    int idtra = Convert.ToInt32(txtMuonTra_IdTraTraSach.Text);
                    int idnhanvien = Convert.ToInt32(txtMuonTra_IdNhanVienTraSach.Text);
                    DateTime ngaytra = Convert.ToDateTime(txtMuonTra_NgayTraTraSach.Text);
                    DTO_TraSach dtotrasach = new DTO_TraSach(idtra,idmuon, ngaytra,idnhanvien);
                    if (tra.suaTraSach("", dtotrasach))
                        MessageBox.Show("Sửa thành công");
                    else MessageBox.Show("Lỗi truy vấn");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi không thực hiện được");
            }
            loadTrasach();
        }

        private void btnMuonTra_XoaMuonTra_Click(object sender, EventArgs e)
        {
            int idtra = Convert.ToInt32(txtMuonTra_IdMuonTraSach.Text);
            try
            {
               if( tra.xoaTraSach("", idtra))
                    MessageBox.Show("Xóa thành công");
               else MessageBox.Show("Lỗi truy vấn");
            }
            catch
            {
                MessageBox.Show("Lỗi không xóa được");
            }
            loadTrasach();
        }

        private void btnMuonTra_TimTraSach_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMuonTra_TimTraSach.Text);
            ds = tra.timTraSach(id);
            dgvMuonTra_TraSach.DataSource = ds.Tables[0];
        }

        // Xử lý phần đôc giả mượn sách của quản lý mượn trả

        private void dgvMuonTra_DocGiaMuonSachDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvMuonTra_DocGiaMuonSachDocGia.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMuonTra_TenDocGiaDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[1].Value.ToString();
            this.txtMuonTra_IdMuonDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[0].Value.ToString();
            this.txtMuonTra_IdSachDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[2].Value.ToString();
            this.txtMuonTra_IdNhanVienMuonGiaDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[3].Value.ToString();
            this.txtMuonTra_NgayMuonGiaDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[4].Value.ToString();
            this.txtMuonTra_NgayTraGiaDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[5].Value.ToString();
            this.txtMuonTra_NgayTraDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[6].Value.ToString();
            this.txtMuonTra_IdNhanVienTraDocGia.Text = dgvMuonTra_DocGiaMuonSachDocGia.Rows[r].Cells[7].Value.ToString();
        }

        private void btnMuonTra_TimDocGia_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMuonTra_IdDocGiaDocGia.Text);
            ds = dgmuon.timDocGiaMuonSach(id);
            dgvMuonTra_DocGiaMuonSachDocGia.DataSource = ds.Tables[0];
        }

        private void btnMuonTra_HuyDocGia_Click(object sender, EventArgs e)
        {
            loadDocGiaMuonSach();
        }

        // xử lý phần thông tin thủ thư
        private void btnThuThu_SuaNhanVien_Click(object sender, EventArgs e)
        {
            txtThuThu_IdNhanVien.Enabled = false;
            txtThuThu_HoNhanVien.Enabled = true;
            txtThuThu_TenNhanVien.Enabled = true;
            txtThuThu_NgaySinhNhanVien.Enabled = true;
            txtThuThu_CMNDNhanVien.Enabled = true;
            txtThuThu_DiaChiNhanVien.Enabled = true;
            txtThuThu_SDTNhanVien.Enabled = true;
            txtThuThu_EmailNhanVien.Enabled = true;
            txtThuThu_NgayLamNhanVien.Enabled = true;

            f = "sua";

        }

        private void btnThuThu_LuuNhanVien_Click(object sender, EventArgs e)
        {
            DTO_NhanVien dtonv = new DTO_NhanVien();
            try
            {
                if (f == "sua")
                {
                    dtonv.IdNhanVien = Convert.ToInt32(txtThuThu_IdNhanVien.Text);
                    dtonv.Ho = txtThuThu_HoNhanVien.Text.ToString();
                    dtonv.Ten = txtThuThu_TenNhanVien.Text.ToString();
                    dtonv.NgaySinh = Convert.ToDateTime(txtThuThu_NgaySinhNhanVien.Text);
                    dtonv.CMND = txtThuThu_CMNDNhanVien.Text.ToString();
                    dtonv.DiaChi = txtThuThu_DiaChiNhanVien.Text.ToString();
                    dtonv.SoDT = txtThuThu_SDTNhanVien.Text.ToString();
                    dtonv.Email = txtThuThu_EmailNhanVien.Text.ToString();
                    dtonv.NgayBatDau = Convert.ToDateTime(txtThuThu_NgayLamNhanVien.Text);

                    if (nv.suaNhanVien("", dtonv))
                        MessageBox.Show("Sửa thành công");
                    else MessageBox.Show("Lỗi truy vấn");

                }
            }
            catch
            {
                MessageBox.Show("Lỗi không thực hiện được");
            }
            loadNhanVien(this.username, this.pass);
            f = "";
            txtThuThu_IdNhanVien.Enabled = false;
            txtThuThu_HoNhanVien.Enabled = false;
            txtThuThu_TenNhanVien.Enabled = false;
            txtThuThu_NgaySinhNhanVien.Enabled = false;
            txtThuThu_CMNDNhanVien.Enabled = false;
            txtThuThu_DiaChiNhanVien.Enabled = false;
            txtThuThu_SDTNhanVien.Enabled = false;
            txtThuThu_EmailNhanVien.Enabled = false;
            txtThuThu_NgayLamNhanVien.Enabled = false;
        }
    }
}
