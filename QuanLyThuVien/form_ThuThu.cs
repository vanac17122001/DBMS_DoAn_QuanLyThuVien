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
    }
}
