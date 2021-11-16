﻿using System;
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
        BLL_DauSach dausach;
        BLL_DocGia BLL_DocGia;
        BLL_SachDocGiaDaMuon BLL_SachDocGiaDaMuon;
        DataSet ds = new DataSet();
        public string _username;
        public string _pass;

        public formDocGia(string username, string password)
        {
            _username = username;
            _pass = password;

            dausach = new BLL_DauSach(_username, _pass);
            BLL_DocGia = new BLL_DocGia(_username, _pass);
            BLL_SachDocGiaDaMuon = new BLL_SachDocGiaDaMuon(_username, _pass);

            InitializeComponent();
            formDocGia_Load(null, null);
        }
        public formDocGia()
        {
            InitializeComponent();
            formDocGia_Load(null, null);
        }
        public void loadSachDocGia()
        {
            ds = dausach.getDauSach();
            dagDanhSachDauSach.DataSource = ds.Tables[0];
        }

        private void formDocGia_Load(object sender, EventArgs e)
        {
            this.txtTenDauSach.Enabled = false;
            this.txtTenTacGia.Enabled = false;
            this.txtNhaXuatBan.Enabled = false;
            this.txtSoLuongDauSach.Enabled = false;
            this.txtSoLuongMuon.Enabled = false;
            this.txtNamXuatBan.Enabled = false;
            this.txtViTri.Enabled = false;

            loadSachDocGia();
        }

        private void btnTimKiemDauSach_Click(object sender, EventArgs e)
        {
            string ten = txtTimKiemDauSach.Text.ToString();
            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm !");
                return;
            }
            if (rabTimKiemSachTheoTenDauSach.Checked == true)
            {
                string tensach = txtTimKiemDauSach.Text.ToString();
                ds = dausach.timDauSach(tensach);
                dagDanhSachDauSach.DataSource = ds.Tables[0];
            }
            else
            {

                if (rabTimKiemSachTheoTacGiaDauSach.Checked == true)
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
            string vitri = dagDanhSachDauSach.Rows[r].Cells[7].Value.ToString();

            this.txtTenDauSach.Text = tensach;
            this.txtTenTacGia.Text = tentg;
            this.txtNhaXuatBan.Text = nxb;
            this.txtSoLuongDauSach.Text = soluongsach;
            this.txtSoLuongMuon.Text = soluongsachmuon;
            this.txtNamXuatBan.Text = namsb;
            this.txtViTri.Text = vitri;

            form_ThuThu form_ThuThu = new form_ThuThu(this._username,this._pass);

            if (!(dagDanhSachDauSach.Rows[r].Cells[8].Value == DBNull.Value))
            {
                byte[] anhBiaSach = (byte[])dagDanhSachDauSach.Rows[r].Cells[8].Value;
                Image _anhBiaSach = form_ThuThu.ConvertByteArrayToImage(anhBiaSach);
                pibDauSach.Image = _anhBiaSach;
            }
        }

        private void picRefeshDauSach_Click(object sender, EventArgs e)
        {
            loadSachDocGia();
        }

        private void formDocGia_Load_1(object sender, EventArgs e)
        {

        }

        private void tcDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string err = "Lỗi khi load dữ liệu !";
            if (tcDocGia.SelectedIndex == 2)
            {
                DataSet thongtindocgia = new DataSet();
                thongtindocgia = BLL_DocGia.timDocGiaTheoUsernamePass(ref err, _username, _pass);

                this.txtHoDG.Text = thongtindocgia.Tables[0].Rows[0][0].ToString();
                this.txtTenDG.Text = thongtindocgia.Tables[0].Rows[0][1].ToString();
                this.txtNgaySinh.Text = thongtindocgia.Tables[0].Rows[0][2].ToString();
                this.txtCMND.Text = thongtindocgia.Tables[0].Rows[0][3].ToString();
                this.txtDiaChi.Text = thongtindocgia.Tables[0].Rows[0][4].ToString();
                this.txtSDT.Text = thongtindocgia.Tables[0].Rows[0][5].ToString();
                this.txtEmail.Text = thongtindocgia.Tables[0].Rows[0][6].ToString();
                this.txtNgayLamThe.Text = thongtindocgia.Tables[0].Rows[0][7].ToString();
                this.txtSoThe.Text = thongtindocgia.Tables[0].Rows[0][8].ToString();

                this.txtHoDG.Enabled = false;
                this.txtTenDG.Enabled = false;
                this.txtNgaySinh.Enabled = false;
                this.txtCMND.Enabled = false;
                this.txtDiaChi.Enabled = false;
                this.txtSDT.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtNgayLamThe.Enabled = false;
                this.txtSoThe.Enabled = false;

                /* if (!(docgia.AnhDG == null))
                 {
                     picAnhDG.Image = form_ThuThu.ConvertByteArrayToImage(docgia.AnhDG);
                 }*/
                form_ThuThu form_ThuThu = new form_ThuThu(this._username, this._pass);
                Byte[] _anhDg = null;
                if (!(thongtindocgia.Tables[0].Rows[0][9] == DBNull.Value))
                {
                    _anhDg = (Byte[])thongtindocgia.Tables[0].Rows[0][9];
                }
                if (!(_anhDg == null))
                {
                    picAnhDG.Image = form_ThuThu.ConvertByteArrayToImage(_anhDg);
                }
            }
            else
            {
                if (tcDocGia.SelectedIndex == 1)
                {
                    DataSet thongtinsachdocgiadamuon = new DataSet();
                    thongtinsachdocgiadamuon = BLL_SachDocGiaDaMuon.getThingTinSachDaMuon(_username, _pass);
                    dagSachDocGiaDaMuon.DataSource = thongtinsachdocgiadamuon.Tables[0];
                }
            }
        }

        private void dagSachDocGiaDaMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dagSachDocGiaDaMuon.CurrentCell.RowIndex;

            this.txtIdMuon.Text = dagSachDocGiaDaMuon.Rows[r].Cells[0].Value.ToString();
            this.txtIdSach.Text = dagSachDocGiaDaMuon.Rows[r].Cells[1].Value.ToString();
            this.txtNgayMuon.Text = dagSachDocGiaDaMuon.Rows[r].Cells[2].Value.ToString();
            this.txtHanTra.Text = dagSachDocGiaDaMuon.Rows[r].Cells[3].Value.ToString();
            this.txtTenSach.Text = dagSachDocGiaDaMuon.Rows[r].Cells[4].Value.ToString();

            this.txtIdMuon.Enabled = false;
            this.txtIdSach.Enabled = false;
            this.txtNgayMuon.Enabled = false;
            this.txtHanTra.Enabled = false;
            this.txtTenSach.Enabled = false;
        }
    }
}
