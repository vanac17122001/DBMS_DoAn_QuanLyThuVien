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

namespace QuanLyThuVien
{
    public partial class formDocGia : Form
    {
        BLL_DauSach dausach = new BLL_DauSach();
        DataSet ds = new DataSet();
        public formDocGia()
        {
            InitializeComponent();
        }
        public void loadSachDocGia()
        {
            ds = dausach.getDauSach();
            dagDanhSachDauSach.DataSource = ds.Tables[0];
        }

        private void formDocGia_Load(object sender, EventArgs e)
        {

        }

        private void dagDanhSachDauSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dagDanhSachDauSach.CurrentCell.RowIndex;
            this.txtTenDauSach.Text = dagDanhSachDauSach.Rows[r].Cells[0].Value.ToString();
            this.txtTenTacGia.Text = dagDanhSachDauSach.Rows[r].Cells[1].Value.ToString();
            this.txtNhaXuatBan.Text = dagDanhSachDauSach.Rows[r].Cells[2].Value.ToString();
            this.txtNamXuatBan.Text = dagDanhSachDauSach.Rows[r].Cells[3].Value.ToString();
            this.txtSoLuongDauSach.Text = dagDanhSachDauSach.Rows[r].Cells[4].Value.ToString();
            this.txtSoLuongSachDaMuon.Text = dagDanhSachDauSach.Rows[r].Cells[5].Value.ToString();
            
        }

        private void btnTimKiemDauSach_Click(object sender, EventArgs e)
        {
            if (rabTimKiemTenDauSach.Checked == true)
            {
                string ten = txtTimKiemDauSach.Text.ToString();
                ds = dausach.timDauSach(ten);
                dagDanhSachDauSach.DataSource = ds.Tables[0];
            }
            if (rabTimKiemTacGiaDauSach.Checked == true)
            {
                string ten = txtTimKiemDauSach.Text.ToString();
                ds = dausach.timDauSachTheoTenTG(ten);
                dagDanhSachDauSach.DataSource = ds.Tables[0];
            }
        }

        private void formDocGia_Load_1(object sender, EventArgs e)
        {
            loadSachDocGia();
        }
    }
}
