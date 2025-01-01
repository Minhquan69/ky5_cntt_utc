using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTH5.Forms
{
    public partial class frmDangNhap : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        private frmMain mainForm;
        
        public frmDangNhap(frmMain main)
        {
            mainForm = main;
            InitializeComponent();
            DataTable Login = dtBase.ReadData("Select * from tblNhanVien");
        }

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            mainForm.Close();
            this.Close();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {

            if (txtMK.Text.Trim() == "" || txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ tên đăng nhập và mật khẩu");
                return;
            }

            DataTable dtnv = dtBase.ReadData("Select * from tblNhanVien where MaNhanVien ='" +
                txtUserName.Text + "' and MatKhau='" + txtMK.Text+"'");
            if (dtnv.Rows.Count>0)
            {
                mainForm.tenNhanVien = dtnv.Rows[0]["TenNhanVien"].ToString();

                Program.maNV = dtnv.Rows[0]["MaNhanVien"].ToString();
                mainForm.EnableMenuItems();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
