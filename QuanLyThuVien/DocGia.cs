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
using DALayer;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien
{

    public partial class DocGia : Form
    {
        DAL da = new DAL();
        DataSet ds = new DataSet();
        BLL docgia = new BLL();

        private void DataBind()
        {
            ds = docgia.getDocGia();
            FormDocGia.DataSource = ds.Tables[0];
        }

        public DocGia()
        {
            InitializeComponent();
        }

        private void DocGia_Load(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}
