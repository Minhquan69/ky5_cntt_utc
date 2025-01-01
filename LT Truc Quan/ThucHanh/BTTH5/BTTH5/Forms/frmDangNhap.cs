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
            DataTable Login = dtBase.ReadData("Select * from tblUser");
        }

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            mainForm.Close();
            this.Close();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
           
            // Lấy thông tin từ TextBox
            string username = txtUserName.Text.Trim();
            string password = txtMK.Text.Trim();

            // Lấy tất cả dữ liệu từ bảng tblUser
            DataTable dtLogin = dtBase.ReadData("SELECT * FROM tblUser");

            // Kiểm tra xem có hàng nào trong DataTable khớp với thông tin đăng nhập
            bool isValidLogin = false;

            foreach (DataRow row in dtLogin.Rows)
            {
                // So sánh tên đăng nhập và mật khẩu
                if (row["Username"].ToString() == username && row["Password"].ToString() == password)
                {
                    isValidLogin = true;
                    break;  // Thoát khỏi vòng lặp khi tìm thấy thông tin khớp
                }
            }

            // Nếu thông tin đăng nhập đúng
            if (isValidLogin)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSanPham.userName = username;

                // Kích hoạt các menu hoặc tính năng khác trong form chính
                mainForm.EnableMenuItems();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
