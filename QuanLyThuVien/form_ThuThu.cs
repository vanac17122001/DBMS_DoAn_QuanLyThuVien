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
        DataSet ds = new DataSet();
        public form_ThuThu()
        {
            InitializeComponent();
            btnQuanLySach_Click(null, null);
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

        private void btnThongTinThuThu_Click(object sender, EventArgs e)
        {
            tcQuanLyDocGia.Visible = false;
            tcThongKeBaoCao.Visible = false;
            tcThongTinSach.Visible = false;
            tcQuanLyMuonTra.Visible = false;
            gbThongTinThuThu.Size = new Size(965, 661);
            gbThongTinThuThu.Visible = true;
            gbThongTinThuThu.Location= new System.Drawing.Point(252, 38);
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
        }

        private void btnXemChiTietDocGia_Click(object sender, EventArgs e)
        {
            int r = dagDanhSachDocGia.CurrentCell.RowIndex;

            string id= dagDanhSachDocGia.Rows[r].Cells[0].Value.ToString();
            int _id = int.Parse(id);
            string ho=dagDanhSachDocGia.Rows[r].Cells[1].Value.ToString();
            string ten=dagDanhSachDocGia.Rows[r].Cells[2].Value.ToString();

            Byte[] _anhDg = null;
            if (!(dagDanhSachDocGia.Rows[r].Cells[11].Value == DBNull.Value))
            {
                _anhDg = (Byte[])dagDanhSachDocGia.Rows[r].Cells[11].Value;
            }
            string ngaysinh =dagDanhSachDocGia.Rows[r].Cells[3].Value.ToString();

            DateTime _ngaysinh = Convert.ToDateTime(ngaysinh);

            string gioitinh=dagDanhSachDocGia.Rows[r].Cells[4].Value.ToString();
            string cmnd=dagDanhSachDocGia.Rows[r].Cells[5].Value.ToString();
            string diachi=dagDanhSachDocGia.Rows[r].Cells[6].Value.ToString();
            string sdt=dagDanhSachDocGia.Rows[r].Cells[7].Value.ToString();
            string email=dagDanhSachDocGia.Rows[r].Cells[8].Value.ToString();

            string sothe=dagDanhSachDocGia.Rows[r].Cells[10].Value.ToString();
            int _sothe= int.Parse(sothe);

            string ngaydk=dagDanhSachDocGia.Rows[r].Cells[9].Value.ToString();
            DateTime _ngaydk = Convert.ToDateTime(ngaydk);
            DTO_DocGia docgia = new DTO_DocGia(_id,ho,ten,_ngaysinh,gioitinh,cmnd,diachi,sdt,email,_ngaydk,_sothe, _anhDg);

            formChiTietDocGia formChiTietDocGia = new formChiTietDocGia();
            formChiTietDocGia.loadThongTinChiTietDG(docgia);

            /*Form formChiTietDocGia = new formChiTietDocGia();
            formChiTietDocGia.ShowDialog();*/
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
            string ten = txtTimKiemDauSach.Text.ToString();
            if (ten=="")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm !");
                return;
            }
            if (rabTimKiemTenDauSach.Checked == true)
            {
                string tensach = txtTimKiemDauSach.Text.ToString();
                ds = dausach.timDauSach(tensach);
                dagDanhSachDauSach.DataSource = ds.Tables[0];
            } else
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

            string tensach = dagDanhSachDauSach.Rows[r].Cells[0].Value.ToString();
            string tentg = dagDanhSachDauSach.Rows[r].Cells[1].Value.ToString();
            string nxb = dagDanhSachDauSach.Rows[r].Cells[2].Value.ToString(); ;
            string soluongsach= dagDanhSachDauSach.Rows[r].Cells[3].Value.ToString();
            string soluongsachmuon= dagDanhSachDauSach.Rows[r].Cells[4].Value.ToString();
            string namsb = dagDanhSachDauSach.Rows[r].Cells[5].Value.ToString();

            if (!(dagDanhSachDauSach.Rows[r].Cells[6].Value== DBNull.Value))
            {
                byte[] anhBiaSach = (byte[])dagDanhSachDauSach.Rows[r].Cells[6].Value;
                Image _anhBiaSach = ConvertByteArrayToImage(anhBiaSach);
                pibDauSach.Image = _anhBiaSach;
            }


            this.txtTenDauSach.Text = tensach;
            this.txtTenTacGia.Text = tentg;
            this.txtNhaXuatBan.Text = nxb;
            this.txtNamXuatBan.Text = namsb;
            this.txtSoLuongDauSach.Text = soluongsach;
            this.txtSoLuongSachDaMuon.Text = soluongsachmuon;
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
            using (MemoryStream ms=new MemoryStream(data))
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
                if (ho==""|| ten=="" || ngaysinh=="" ||cmnd=="" ||diachi==""||email==""||ngaydk=="")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !");
                    return;
                }
                if (CheckNumber(sdt) == false)
                {
                    MessageBox.Show("Vui lòng nhập đúng số điện thoại !");
                    return;
                }
                DateTime _ngaysinh= Convert.ToDateTime(ngaysinh);
                DateTime _ngaydk = Convert.ToDateTime(ngaydk);
                //DateTime _ngaysinh = Convert.ToDateTime(ngaysinh);

                DTO_DocGia DTO = new DTO_DocGia();
                DTO_DocGia docgia = new DTO_DocGia();
                docgia=DTO.DTO_ThemDocGia(ho, ten, _ngaysinh, gioitinh, cmnd, diachi, sdt, email, _ngaydk, anhdg);
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
            using (OpenFileDialog ofd= new OpenFileDialog() {Filter="Image files(*.jpg;*.jpeg;)|*.jpg;*.jpge", Multiselect = false })
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
    }
}
