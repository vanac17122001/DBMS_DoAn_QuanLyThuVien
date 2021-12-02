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
using QuanLyThuVien.Properties;

namespace QuanLyThuVien
{
    public partial class formChiTietSachMuon : Form
    {
        private int rowindex;
        private int _idnhanvien;
        private string _tennhanvien;
        BLL_SachDocGiaDaMuon sachDocGiaMuon;
        BLL_DocGia BLL_DocGia;
        BLL_DauSach dausach;
        DataSet ds;
        private string _sdt;
        public formChiTietSachMuon()
        {
            InitializeComponent();
        }
        public formChiTietSachMuon(string sdt, int idnhanvien, string tennhanvien)
        {
            this._sdt = sdt;
            this._idnhanvien = idnhanvien;
            this._tennhanvien = tennhanvien;
            BLL_DocGia = new BLL_DocGia(sdt, sdt);
            InitializeComponent();
            sachDocGiaMuon = new BLL_SachDocGiaDaMuon(sdt, sdt);
            dausach = new BLL_DauSach(sdt, sdt);
        }

        private void formChiTietSachMuon_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            string err = "Lỗi load dữ liệu";
            ds = BLL_DocGia.sachChuaTra(ref err,_sdt, _sdt);
            dagSachDocGiaMuon.DataSource = ds.Tables[0];

            this.txtTenSach_SachDaMuon.Enabled = false;
            this.txtTacGia_SachDaMuon.Enabled = false;
            this.txtNgayMuon_SachDaMuon.Enabled = false;
            this.txtHanTra_SachDaMuon.Enabled = false;
            this.txtSoNgayTre_SachDaMuon.Enabled = false;
            this.txtIdSach_SachDaMuon.Enabled = false;
            this.txtTienPhat_SachDaMuon.Enabled = false;
        }

        private void dagSachDocGiaMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtTenSach_SachDaMuon.Clear();
            this.txtTacGia_SachDaMuon.Clear();
            this.txtNgayMuon_SachDaMuon.Clear();
            this.txtHanTra_SachDaMuon.Clear();

            this.txtIdSach_SachDaMuon.Clear();

            int r = dagSachDocGiaMuon.CurrentCell.RowIndex;
            this.rowindex = r;

            this.txtTenSach_SachDaMuon.Text = dagSachDocGiaMuon.Rows[r].Cells[0].Value.ToString();
            this.txtTacGia_SachDaMuon.Text = dagSachDocGiaMuon.Rows[r].Cells[1].Value.ToString();
            this.txtNgayMuon_SachDaMuon.Text = dagSachDocGiaMuon.Rows[r].Cells[2].Value.ToString();
            this.txtHanTra_SachDaMuon.Text = dagSachDocGiaMuon.Rows[r].Cells[3].Value.ToString();
            this.txtSoNgayTre_SachDaMuon.Text = dagSachDocGiaMuon.Rows[r].Cells[4].Value.ToString();
            this.txtIdSach_SachDaMuon.Text = dagSachDocGiaMuon.Rows[r].Cells[7].Value.ToString();
            try
            {
                if (Convert.ToInt32(dagSachDocGiaMuon.Rows[r].Cells[4].Value) <= 0)
                {
                    this.txtSoNgayTre_SachDaMuon.Text = "0";
                }
            }
            catch
            {

            }
            try
            {
                this.txtTienPhat_SachDaMuon.Text = (Convert.ToInt32(txtSoNgayTre_SachDaMuon.Text) * 5000).ToString();
            }
            catch
            {

            }
            btnTraSach.Enabled = true;
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if(dagSachDocGiaMuon.Rows[rowindex].Cells[5].Value != null) { 
            string idmuon = dagSachDocGiaMuon.Rows[rowindex].Cells[5].Value.ToString();
            string err = "Lỗi không mượng được";
            int tienphat = Convert.ToInt32(txtTienPhat_SachDaMuon.Text);
            if(tienphat > 0)
            {
                DialogResult dlr = MessageBox.Show("Độc giả trả trễ, bạn có muốn in hóa đơn ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
            }

            if (BLL_DocGia.traSach(ref err, idmuon, _idnhanvien))
            {
                MessageBox.Show("Trả sách thành công");
            }
            else
                MessageBox.Show("Trả sách thất bại");
            }
            load();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image img = Resources.head;
            string err = "Lỗi không thực hiện được";
            DataSet ds = BLL_DocGia.timDocGiaTheoUsernamePass(ref err,_sdt, _sdt);
            string tendocgia = ds.Tables[0].Rows[0][0].ToString()+" "+ ds.Tables[0].Rows[0][1].ToString();
            e.Graphics.DrawImage(img, 145, 100, img.Width, img.Height);

            e.Graphics.DrawString("Ngày trả :" + DateTime.Now.ToShortDateString(), new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Tên độc giả :" + tendocgia, new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(25, 250));
            e.Graphics.DrawString("Tên nhân viên :" + _tennhanvien, new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(25, 280));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------" +
                "--------------",new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(25, 310));


            e.Graphics.DrawString("ID Sách :", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(70, 340));
            e.Graphics.DrawString(txtIdSach_SachDaMuon.Text.ToString(), new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(300, 340));


            e.Graphics.DrawString("Tên Sách :", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(70, 370));
            e.Graphics.DrawString(txtTenSach_SachDaMuon.Text.ToString(), new Font("Arial", 16, FontStyle.Regular),
            Brushes.Black, new Point(300, 370));


            e.Graphics.DrawString("Tác Giả :", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(70, 400));
            e.Graphics.DrawString(txtTacGia_SachDaMuon.Text.ToString(), new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(300, 400));


            e.Graphics.DrawString("Ngày Mượn :", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(70, 430));
            e.Graphics.DrawString(txtNgayMuon_SachDaMuon.Text.ToString(), new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(300, 430));


            e.Graphics.DrawString("Hạn Trả :", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(70, 460));
            e.Graphics.DrawString(txtHanTra_SachDaMuon.Text.ToString(), new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(300, 460));


            e.Graphics.DrawString("Số Ngày Trễ :", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(70, 490));
            e.Graphics.DrawString(txtSoNgayTre_SachDaMuon.Text.ToString(), new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(300, 490));


            e.Graphics.DrawString("Tiền Phạt :", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(70, 520));
            e.Graphics.DrawString(txtTienPhat_SachDaMuon.Text.ToString(), new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(300, 520));


            e.Graphics.DrawString("--------------------------------------------------------------------------------------------" +
                "--------------", new Font("Arial", 16, FontStyle.Regular),
                Brushes.Black, new Point(25, 550));
        }
    }
}
