using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BLLayer;
using System.IO;

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
        BLL_ThongKeDocGia thongkedocgia = new BLL_ThongKeDocGia();
        BLL_ThongKeSach thongkesach = new BLL_ThongKeSach();

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

            this.txtTenDauSach.Enabled = false;
            this.txtTenTacGia.Enabled = false;
            this.txtNhaXuatBan.Enabled = false;
            this.txtNamXuatBan.Enabled = false;
            this.txtSoLuongDauSach.Enabled = false;
            this.txtSoLuongSachDaMuon.Enabled = false;
            this.txtViTriDauSach.Enabled = false;
            this.btnLuuDauSach.Enabled = false;
        }

        public void loadMuonSach()
        {
            ds = muon.getMuonSach();
            dvgDocGiaMuonSach.DataSource= ds.Tables[0];
        }
        public void loadTrasach()
        {
            ds = tra.getTraSach();
            dvgDocGiaTraSach.DataSource = ds.Tables[0];
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
            gbThongTinThuThu.Location = new System.Drawing.Point(252, 38);
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
            tcThongKeBaoCao.Location = new System.Drawing.Point(252, 38);
        }

        private void btnQuanLyDocGia_Click(object sender, EventArgs e)
        {
            tcQuanLyMuonTra.Visible = false;
            gbThongTinThuThu.Visible = false;
            tcThongTinSach.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcQuanLyDocGia.Size = new Size(965, 661);
            tcQuanLyDocGia.Location = new System.Drawing.Point(252, 38);
            loadDocGia();
            tcQuanLyDocGia.Visible = true;

        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            tcQuanLyMuonTra.Visible = false;
            gbThongTinThuThu.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcQuanLyDocGia.Visible = false;
            tcThongTinSach.Size = new Size(965, 661);
            tcThongTinSach.Location = new System.Drawing.Point(252, 38);
            loadDauSach();
            tcThongTinSach.Visible = true;
        }

        private void tcQuanLyMuonTra_Click(object sender, EventArgs e)
        {
            tcQuanLyDocGia.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcThongTinSach.Visible = false;
            gbThongTinThuThu.Visible = false;
            tcQuanLyMuonTra.Size = new Size(965, 661);
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
            int r = dagDanhSachDocGia.CurrentCell.RowIndex;

            string id = dagDanhSachDocGia.Rows[r].Cells[0].Value.ToString();
            int _id = int.Parse(id);
            string ho = dagDanhSachDocGia.Rows[r].Cells[1].Value.ToString();
            string ten = dagDanhSachDocGia.Rows[r].Cells[2].Value.ToString();

            Byte[] _anhDg = null;
            if (!(dagDanhSachDocGia.Rows[r].Cells[11].Value == DBNull.Value))
            {
                _anhDg = (Byte[])dagDanhSachDocGia.Rows[r].Cells[11].Value;
            }
            string ngaysinh = dagDanhSachDocGia.Rows[r].Cells[3].Value.ToString();

            DateTime _ngaysinh = Convert.ToDateTime(ngaysinh);

            string gioitinh = dagDanhSachDocGia.Rows[r].Cells[4].Value.ToString();
            string cmnd = dagDanhSachDocGia.Rows[r].Cells[5].Value.ToString();
            string diachi = dagDanhSachDocGia.Rows[r].Cells[6].Value.ToString();
            string sdt = dagDanhSachDocGia.Rows[r].Cells[7].Value.ToString();
            string email = dagDanhSachDocGia.Rows[r].Cells[8].Value.ToString();

            string sothe = dagDanhSachDocGia.Rows[r].Cells[10].Value.ToString();
            int _sothe = int.Parse(sothe);

            string ngaydk = dagDanhSachDocGia.Rows[r].Cells[9].Value.ToString();
            DateTime _ngaydk = Convert.ToDateTime(ngaydk);
            DTO_DocGia docgia = new DTO_DocGia(_id, ho, ten, _ngaysinh, gioitinh, cmnd, diachi, sdt, email, _ngaydk, _sothe, _anhDg);

            formChiTietDocGia formChiTietDocGia = new formChiTietDocGia();
            formChiTietDocGia.loadThongTinChiTietDG(docgia);

            /*Form formChiTietDocGia = new formChiTietDocGia();
            formChiTietDocGia.ShowDialog();*/
        }

        private void btnTimKiemDocGia_Click(object sender, EventArgs e)
        {
            if (rabTimKiemDocGiaTheoTen.Checked == true)
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
            string ten = txtTimKiemDauSach.Text.ToString();
            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm !");
                return;
            }
            if (rabTimKiemTenDauSach.Checked == true)
            {
                string tensach = txtTimKiemDauSach.Text.ToString();
                ds = dausach.timDauSach(tensach);
                dagDanhSachDauSach.DataSource = ds.Tables[0];
            }
            else
            {

                if (rabTimKiemDauSachTheoTG.Checked == true)
                {
                    string tentg = txtTimKiemDauSach.Text.ToString();
                    ds = dausach.timDauSachTheoTenTG(tentg);
                    dagDanhSachDauSach.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại tìm kiếm !");
                    return;
                }
            }
        }

        private void dagDanhSachDauSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dagDanhSachDauSach.CurrentCell.RowIndex;

            string tensach = dagDanhSachDauSach.Rows[r].Cells[1].Value.ToString();
            string tentg = dagDanhSachDauSach.Rows[r].Cells[2].Value.ToString();
            string nxb = dagDanhSachDauSach.Rows[r].Cells[3].Value.ToString(); ;
            string soluongsach = dagDanhSachDauSach.Rows[r].Cells[4].Value.ToString();
            string soluongsachmuon = dagDanhSachDauSach.Rows[r].Cells[5].Value.ToString();
            string namsb = dagDanhSachDauSach.Rows[r].Cells[6].Value.ToString();
            string vitri= dagDanhSachDauSach.Rows[r].Cells[7].Value.ToString();

            if (!(dagDanhSachDauSach.Rows[r].Cells[8].Value == DBNull.Value))
            {
                byte[] anhBiaSach = (byte[])dagDanhSachDauSach.Rows[r].Cells[8].Value;
                Image _anhBiaSach = ConvertByteArrayToImage(anhBiaSach);
                pibDauSach.Image = _anhBiaSach;
            }


            this.txtTenDauSach.Text = tensach;
            this.txtTenTacGia.Text = tentg;
            this.txtNhaXuatBan.Text = nxb;
            this.txtNamXuatBan.Text = namsb;
            this.txtSoLuongDauSach.Text = soluongsach;
            this.txtSoLuongSachDaMuon.Text = soluongsachmuon;
            this.txtViTriDauSach.Text = vitri;

        }
        //Them doc gia

        //Chuyen Image sang Bytes
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

        private void form_ThuThu_Load(object sender, EventArgs e)
        {

        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            string err = "Lỗi khi thêm !";
            BLL_DocGia bLL_DocGia = new BLL_DocGia();
            try
            {
                string ho = txtHoDG.Text;
                string ten = txtTenDG.Text;
                string ngaysinh = txtNgaySinhDG.Text;
                string gioitinh = txtGioiTinhDG.Text;
                string cmnd = txtCMNDDG.Text;
                string diachi = txtDiaChiDG.Text;
                string sdt = txtSDTDG.Text;
                string email = txtEmailDG.Text;
                string ngaydk = txtNgayDangKyDG.Text;
                byte[] anhdg = ConvertImageToBytes(picAnhDG.Image);

                // kiem tra thong tin nhap 
                if (!(gioitinh == "Nam" || gioitinh == "Nữ"))
                {
                    MessageBox.Show("Vui lòng nhập thông tin giới tính chỉ bao gồm Nam hoặc Nữ !");
                    return;
                }
                if (ho == "" || ten == "" || ngaysinh == "" || cmnd == "" || diachi == "" || email == "" || ngaydk == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !");
                    return;
                }
                if (CheckNumber(sdt) == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng số điện thoại !");
                    return;
                }
                DateTime _ngaysinh = Convert.ToDateTime(ngaysinh);
                DateTime _ngaydk = Convert.ToDateTime(ngaydk);
                //DateTime _ngaysinh = Convert.ToDateTime(ngaysinh);

                DTO_DocGia DTO = new DTO_DocGia();
                DTO_DocGia docgia = new DTO_DocGia();
                docgia = DTO.DTO_ThemDocGia(ho, ten, _ngaysinh, gioitinh, cmnd, diachi, sdt, email, _ngaydk, anhdg);
                if (bLL_DocGia.themDocGia(ref err, docgia))
                {
                    MessageBox.Show("Đăng ký Độc Giả Thành Công!!!" + err);
                }
                else
                {
                    MessageBox.Show("Đăng Ký không Thành Công\n Lỗi Dữ Liệu Nhập!!!" + err);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi");
                throw ex;
            }
        }
        // ham kt sdt
        static public bool CheckNumber(string pValue)
        {
            if (pValue == "")
            {
                return false;
            }
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
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

        private void picRefeshDocGia_Click(object sender, EventArgs e)
        {
            loadDocGia();
        }

        private void picRefeshDauSach_Click(object sender, EventArgs e)
        {
            loadDauSach();
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
            try
            {
                if (f == "them")
                {
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
            try
            {
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
            dvgDocGiaMuonSach.DataSource = ds.Tables[0];
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
                    if (tra.themTraSach("", dtotrasach))
                        MessageBox.Show("Thêm thành công");
                    else MessageBox.Show("Lỗi câu lệnh truy vấn");
                }
                else if (f == "sua")
                {
                    int idmuon = Convert.ToInt32(txtMuonTra_IdMuonTraSach.Text);
                    int idtra = Convert.ToInt32(txtMuonTra_IdTraTraSach.Text);
                    int idnhanvien = Convert.ToInt32(txtMuonTra_IdNhanVienTraSach.Text);
                    DateTime ngaytra = Convert.ToDateTime(txtMuonTra_NgayTraTraSach.Text);
                    DTO_TraSach dtotrasach = new DTO_TraSach(idtra, idmuon, ngaytra, idnhanvien);
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
                if (tra.xoaTraSach("", idtra))
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
            dvgDocGiaTraSach.DataSource = ds.Tables[0];
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

            /*private void picRefeshDocGia_Click(object sender, EventArgs e)
            {
                loadDocGia();
            }

            private void picRefeshDauSach_Click(object sender, EventArgs e)
            {
                loadDauSach();
            }*/
        }

        private void dvgDocGiaMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dvgDocGiaMuonSach.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMuonTra_IdMuonSach.Text = dvgDocGiaMuonSach.Rows[r].Cells[0].Value.ToString();
            this.txtMuonTra_IdSachMuonSach.Text = dvgDocGiaMuonSach.Rows[r].Cells[1].Value.ToString();
            this.txtMuonTra_TheDocGia.Text = dvgDocGiaMuonSach.Rows[r].Cells[2].Value.ToString();
            this.txtMuonTra_IdNhanVien.Text = dvgDocGiaMuonSach.Rows[r].Cells[3].Value.ToString();
            this.txtMuonTra_NgayMuon.Text = dvgDocGiaMuonSach.Rows[r].Cells[4].Value.ToString();
            this.txtMuonTra_HanTra.Text = dvgDocGiaMuonSach.Rows[r].Cells[5].Value.ToString();
        }


        private void dvgDocGiaTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dvgDocGiaTraSach.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMuonTra_IdTraTraSach.Text = dvgDocGiaTraSach.Rows[r].Cells[0].Value.ToString();
            this.txtMuonTra_IdMuonTraSach.Text = dvgDocGiaTraSach.Rows[r].Cells[1].Value.ToString();
            this.txtMuonTra_NgayTraTraSach.Text = dvgDocGiaTraSach.Rows[r].Cells[2].Value.ToString();
            this.txtMuonTra_IdNhanVienTraSach.Text = dvgDocGiaTraSach.Rows[r].Cells[3].Value.ToString();
        }

        private void btnThemSach_ChonHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;)|*.jpg;*.jpge", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Hien thi hinh anh toi picture
                    picThemAnhBia.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            string err = "Lỗi khi thêm !";
            BLL_DauSach bLL_DauSach = new BLL_DauSach();
            try
            {
                string tensach = this.txtThemTenSach.Text;
                string butdanh = this.txtThemTenTacGia.Text;
                string tennxb = this.txtThemTenNhaXuatBan.Text;
                string namxb = this.txtThemNamXuatBan.Text;
                string theloai = this.txtThemTheLoai.Text;
                string gia = this.txtThemGia.Text;
                string soluong = this.txtThemSoLuongSach.Text;
                string vitri = this.txtThemViTri.Text;

                byte[] anhDauSach = ConvertImageToBytes(picThemAnhBia.Image);

                if (tensach == "" || butdanh == "" || tennxb == "" || namxb == "" || theloai == "" || gia == "" || soluong == "" || vitri=="")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !");
                    return;
                }
                if (CheckNumber(gia) == false||CheckNumber(soluong)==false)
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số!");
                    return;
                }
                int _gia = Convert.ToInt32(gia);
                int _soluong = Convert.ToInt32(soluong);

                DateTime _namxb = Convert.ToDateTime(namxb);

                DTO_Sach dTO_Sach = new DTO_Sach(tensach, butdanh, tennxb, _namxb, theloai, _gia, _soluong, vitri, anhDauSach);

                if (bLL_DauSach.themDauSach(ref err, dTO_Sach))
                {
                    MessageBox.Show("Thêm đầu sách thành công!!!");
                }
                else
                {
                    MessageBox.Show("Thêm đầu sách không Thành Công\n Lỗi Dữ Liệu Nhập!!!" + err);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi");
                throw ex;
            }

        }

        private void btnSuaDauSach_Click_1(object sender, EventArgs e)
        {
            this.btnXoaDauSach.Enabled = false;
            this.btnSuaDauSach.Enabled = false;

            this.txtSoLuongSachDaMuon.Enabled = false;
            this.txtNamXuatBan.Enabled = false;
            this.txtNhaXuatBan.Enabled = false;
            this.txtThemTenNhaXuatBan.Enabled = false;

            this.txtTenDauSach.Enabled = true;
            this.txtSoLuongDauSach.Enabled = true;
            this.txtViTriDauSach.Enabled = true;
        }

        private void btnLuuDauSach_Click(object sender, EventArgs e)
        {
            string err = "Lỗi khi sửa !";
            BLL_DauSach bLL_DauSach = new BLL_DauSach();
            try
            {
                int r = dagDanhSachDauSach.CurrentCell.RowIndex;

                string idDauSach = dagDanhSachDauSach.Rows[r].Cells[0].Value.ToString();
                
                string tenDauSach = this.txtTenDauSach.Text;
                string vitri = this.txtViTriDauSach.Text;
                string soLuongDauSach = this.txtSoLuongDauSach.Text;
                

                if (tenDauSach == "" || vitri == "" || soLuongDauSach == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !");
                    return;
                }
                if (CheckNumber(soLuongDauSach)==false)
                {
                    MessageBox.Show("Vui lòng nhập đúng số lượng sách !");
                    return;
                }
                int _idDauSach = Convert.ToInt32(idDauSach);
                int _soLuongDauSach = Convert.ToInt32(soLuongDauSach);

                if (bLL_DauSach.suaDauSach(ref err,_idDauSach, tenDauSach, vitri, _soLuongDauSach))
                {
                    MessageBox.Show("Sửa đầu sách thành công!!!");
                }
                else
                {
                    MessageBox.Show("Sửa đầu sách không Thành Công\n Lỗi Dữ Liệu Nhập!!!" + err);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi");
                throw ex;
            }
        }

        private void btnXoaDauSach_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Xóa đầu sách", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int r = dagDanhSachDauSach.CurrentCell.RowIndex;

                string idDauSach = dagDanhSachDauSach.Rows[r].Cells[0].Value.ToString();
                int _idDauSach = Convert.ToInt32(idDauSach);

                string err = "Lỗi khi xóa !";
                BLL_DauSach bLL_DauSach = new BLL_DauSach();
                try
                {
                    if (bLL_DauSach.xoaDauSach(ref err, _idDauSach))
                    {
                        MessageBox.Show("Xóa đầu sách thành công!!!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa đầu sách không Thành Công\n Lỗi Dữ Liệu Nhập!!!" + err);
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi");
                    throw ex;
                }
                loadDauSach();
            } 
        }
       
        public void loadThongKeDocGia()
        {
            ds = thongkedocgia.getallDocGia();
            dagthongKeDocGia.DataSource = ds.Tables[0];

        }
        public void loadDocGiaTraTre()
        {
            ds = thongkedocgia.getDocGiaTraTre();
            dagthongKeDocGia.DataSource = ds.Tables[0];
        }

        public void loadDocGiaMuonSach1()
        {
            ds = thongkedocgia.getDocGiaMuonSach1();
            dagthongKeDocGia.DataSource = ds.Tables[0];

        }
        public void tienphat()
        {
            ds = thongkedocgia.getTongphat();
            this.txtTienPhat.Text = ds.Tables[0].Rows[0][0].ToString();
        }
        public void maxPhat()
        {
            ds = thongkedocgia.getmaxPhat();
            this.txtmaxphat.Text = ds.Tables[0].Rows[0][0].ToString();
        }
        public void loadDanhSachPhatTien()
        {
            ds = thongkedocgia.getDanhSachPhat();
            dagDanhSachPhatTien.DataSource = ds.Tables[0];

        }
        public void loadSachDaMuon()
        {
            ds = thongkesach.getSachDaDuocMuon();
            dagThongKeSachDaMuon.DataSource = ds.Tables[0];

        }
        public void loadSachChuaMuon()
        {
            ds = thongkesach.getSachChuaDuocMuon();
            dagThongKeSachChuaMuon.DataSource = ds.Tables[0];
        }
        public void sachMuonNhieuNhat()
        {
            ds = thongkesach.getSachMuonNhieuNhat();
            this.txtSachMuonNhieuNhat.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (tuychon.Text == "Tất cả độc giả")
            {
                loadThongKeDocGia();

            }
            else if (tuychon.Text == "Độc giả mượn sách")
            {
                loadDocGiaMuonSach();

            }
            else if (tuychon.Text == "Độc giả trả trễ")
            {
                loadDocGiaTraTre();

            }
        }

        private void dagthongKeDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dagthongKeDocGia.CurrentCell.RowIndex;
            string idDocGia = dagthongKeDocGia.Rows[r].Cells[0].Value.ToString();
            string Ho = dagthongKeDocGia.Rows[r].Cells[1].Value.ToString();
            string Ten = dagthongKeDocGia.Rows[r].Cells[2].Value.ToString();
            string ngaySinh = dagthongKeDocGia.Rows[r].Cells[3].Value.ToString();
            string gioiTinh = dagthongKeDocGia.Rows[r].Cells[4].Value.ToString();
            string CMND = dagthongKeDocGia.Rows[r].Cells[5].Value.ToString();
            string diaChi = dagthongKeDocGia.Rows[r].Cells[6].Value.ToString();
            string SDT = dagthongKeDocGia.Rows[r].Cells[7].Value.ToString();
            string email = dagthongKeDocGia.Rows[r].Cells[8].Value.ToString();
            string soThe = dagthongKeDocGia.Rows[r].Cells[10].Value.ToString();
            string ngayLap = dagthongKeDocGia.Rows[r].Cells[9].Value.ToString();
            txtID.Text = idDocGia;
            txtHo.Text = Ho;
            txtTen.Text = Ten;
            txtNgaySinh.Text = ngaySinh;
            txtGioiTinh.Text = gioiTinh;
            txtDiaChi.Text = diaChi;
            txtEmail.Text = email;
            txtSDT.Text = SDT;
            txtNgayLap.Text = ngayLap;
            txtSoThe.Text = soThe;
            txtCMND.Text = CMND;
        }

        private void dagDanhSachPhatTien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dagDanhSachPhatTien.CurrentCell.RowIndex;
            string id = dagDanhSachPhatTien.Rows[r].Cells[0].Value.ToString();
            string Ho = dagDanhSachPhatTien.Rows[r].Cells[1].Value.ToString();
            string Ten = dagDanhSachPhatTien.Rows[r].Cells[2].Value.ToString();
            string ngaysinh = dagDanhSachPhatTien.Rows[r].Cells[3].Value.ToString();
            string gioiTinh = dagDanhSachPhatTien.Rows[r].Cells[4].Value.ToString();
            string CMND = dagDanhSachPhatTien.Rows[r].Cells[5].Value.ToString();
            string soThe = dagDanhSachPhatTien.Rows[r].Cells[6].Value.ToString();
            string soNgayTre = dagDanhSachPhatTien.Rows[r].Cells[7].Value.ToString();
            string soTienPhat = dagDanhSachPhatTien.Rows[r].Cells[8].Value.ToString();

            txtIDtp.Text = id;
            txtHotp.Text = Ho;
            txtTentp.Text = Ten;
            txtNgaysinhtp.Text = ngaysinh;
            txtGioiTinhtp.Text = gioiTinh;
            txtCMNDtp.Text = CMND;
            txtSoThetp.Text = soThe;
            txttienPhattp.Text = soTienPhat;
            txtSoNgayTretp.Text = soNgayTre;
        }

        private void dagThongKeSachChuaMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dagThongKeSachChuaMuon.CurrentCell.RowIndex;
            string idSach = dagThongKeSachChuaMuon.Rows[r].Cells[0].Value.ToString();
            string idDauSach = dagThongKeSachChuaMuon.Rows[r].Cells[2].Value.ToString();
            string tenSach = dagThongKeSachChuaMuon.Rows[r].Cells[1].Value.ToString();
            string tenTheLoai = dagThongKeSachChuaMuon.Rows[r].Cells[3].Value.ToString();
            string Gia = dagThongKeSachChuaMuon.Rows[r].Cells[4].Value.ToString();
            string viTri = dagThongKeSachChuaMuon.Rows[r].Cells[5].Value.ToString();
            txtIDDauSachsach.Text = idDauSach;
            txtIDSachsach.Text = idSach;
            txtTenSachsach.Text = tenSach;
            txtTenTheLoaisach.Text = tenTheLoai;
            txtGiasach.Text = Gia;
            txtViTrisach.Text = viTri;
        }

        private void dagThongKeSachDaMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dagThongKeSachDaMuon.CurrentCell.RowIndex;
            string idSach = dagThongKeSachDaMuon.Rows[r].Cells[0].Value.ToString();
            string idDauSach = dagThongKeSachDaMuon.Rows[r].Cells[2].Value.ToString();
            string tenSach = dagThongKeSachDaMuon.Rows[r].Cells[1].Value.ToString();
            string tenTheLoai = dagThongKeSachDaMuon.Rows[r].Cells[3].Value.ToString();
            string Gia = dagThongKeSachDaMuon.Rows[r].Cells[4].Value.ToString();
            string viTri = dagThongKeSachDaMuon.Rows[r].Cells[5].Value.ToString();
            txtIDDauSachsach.Text = idDauSach;
            txtIDSachsach.Text = idSach;
            txtTenSachsach.Text = tenSach;
            txtTenTheLoaisach.Text = tenTheLoai;
            txtGiasach.Text = Gia;
            txtViTrisach.Text = viTri;
        }

        private void tcThongKeBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcThongKeBaoCao.SelectedIndex == 2)
            {
                tienphat();
                maxPhat();
                loadDanhSachPhatTien();
            }
            if (tcThongKeBaoCao.SelectedIndex == 1)
            {
                loadSachDaMuon();
                loadSachChuaMuon();
                sachMuonNhieuNhat();
            }
        }
    }
}
