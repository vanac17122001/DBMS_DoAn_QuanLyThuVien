
namespace QuanLyThuVien
{
    partial class DocGia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormDocGia = new System.Windows.Forms.DataGridView();
            this.idDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soThe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FormDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // FormDocGia
            // 
            this.FormDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FormDocGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocGia,
            this.Ho,
            this.Ten,
            this.ngaySinh,
            this.gioiTinh,
            this.CMND,
            this.diaChi,
            this.soDT,
            this.Email,
            this.ngayDK,
            this.soThe});
            this.FormDocGia.Location = new System.Drawing.Point(38, 83);
            this.FormDocGia.Name = "FormDocGia";
            this.FormDocGia.RowHeadersWidth = 51;
            this.FormDocGia.RowTemplate.Height = 24;
            this.FormDocGia.Size = new System.Drawing.Size(844, 314);
            this.FormDocGia.TabIndex = 0;
            // 
            // idDocGia
            // 
            this.idDocGia.DataPropertyName = "idDocGia";
            this.idDocGia.HeaderText = "ID";
            this.idDocGia.MinimumWidth = 6;
            this.idDocGia.Name = "idDocGia";
            this.idDocGia.Width = 50;
            // 
            // Ho
            // 
            this.Ho.DataPropertyName = "Ho";
            this.Ho.HeaderText = "Họ";
            this.Ho.MinimumWidth = 6;
            this.Ho.Name = "Ho";
            this.Ho.Width = 125;
            // 
            // Ten
            // 
            this.Ten.DataPropertyName = "Ten";
            this.Ten.HeaderText = "Tên";
            this.Ten.MinimumWidth = 6;
            this.Ten.Name = "Ten";
            this.Ten.Width = 125;
            // 
            // ngaySinh
            // 
            this.ngaySinh.DataPropertyName = "ngaySinh";
            this.ngaySinh.HeaderText = "Ngày Sinh";
            this.ngaySinh.MinimumWidth = 6;
            this.ngaySinh.Name = "ngaySinh";
            this.ngaySinh.Width = 125;
            // 
            // gioiTinh
            // 
            this.gioiTinh.DataPropertyName = "gioiTinh";
            this.gioiTinh.HeaderText = "Giới Tính";
            this.gioiTinh.MinimumWidth = 6;
            this.gioiTinh.Name = "gioiTinh";
            this.gioiTinh.Width = 125;
            // 
            // CMND
            // 
            this.CMND.DataPropertyName = "CMND";
            this.CMND.HeaderText = "CCCD";
            this.CMND.MinimumWidth = 6;
            this.CMND.Name = "CMND";
            this.CMND.Width = 125;
            // 
            // diaChi
            // 
            this.diaChi.DataPropertyName = "diaChi";
            this.diaChi.HeaderText = "Địa chỉ";
            this.diaChi.MinimumWidth = 6;
            this.diaChi.Name = "diaChi";
            this.diaChi.Width = 200;
            // 
            // soDT
            // 
            this.soDT.DataPropertyName = "soDT";
            this.soDT.HeaderText = "SĐT";
            this.soDT.MinimumWidth = 6;
            this.soDT.Name = "soDT";
            this.soDT.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // ngayDK
            // 
            this.ngayDK.DataPropertyName = "ngayDK";
            this.ngayDK.HeaderText = "Ngày lập thẻ";
            this.ngayDK.MinimumWidth = 6;
            this.ngayDK.Name = "ngayDK";
            this.ngayDK.Width = 125;
            // 
            // soThe
            // 
            this.soThe.DataPropertyName = "soThe";
            this.soThe.HeaderText = "Mã thẻ";
            this.soThe.MinimumWidth = 6;
            this.soThe.Name = "soThe";
            this.soThe.Width = 125;
            // 
            // DocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.FormDocGia);
            this.Name = "DocGia";
            this.Text = "DocGia";
            this.Load += new System.EventHandler(this.DocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormDocGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FormDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn soThe;
    }
}