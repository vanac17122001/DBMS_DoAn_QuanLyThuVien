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

        }

        private void btnTimKiemDauSach_Click(object sender, EventArgs e)
        {
            if (rabTimKiemTenDauSach.Checked == true)
            {
                string ten = txtTimKiemDauSach.Text.ToString();
                ds = dausach.timDauSach(ten);
                dagDanhSachDauSach.DataSource = ds.Tables[0];
            }
        }

        private void formDocGia_Load_1(object sender, EventArgs e)
        {
            loadSachDocGia();
        }
    }
}
