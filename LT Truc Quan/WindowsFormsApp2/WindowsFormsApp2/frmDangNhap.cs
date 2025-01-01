using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmDangNhap : Form
    {

        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        private bool isLogin = false;
        private HoaDon HoaDon;
        private string username = "", password = "";
        public frmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;  // Vô hiệu hóa nút Maximize
            this.StartPosition = FormStartPosition.CenterScreen;  // Căn giữa màn hình
        }

        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            // Lấy tất cả dữ liệu từ bảng tblUser
            DataTable dtLogin = dtBase.ReadData("SELECT * FROM tblNhanVien");
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                return;
            }
            // Kiểm tra xem có hàng nào trong DataTable khớp với thông tin đăng nhập
            bool isValidLogin = false;

            foreach (DataRow row in dtLogin.Rows)
            {
                // So sánh tên đăng nhập và mật khẩu
                if (row["MaNhanVien"].ToString() == username && row["MatKhau"].ToString() == password)
                {
                    isValidLogin = true;
                    break;  // Thoát khỏi vòng lặp khi tìm thấy thông tin khớp
                }
            }

            // Nếu thông tin đăng nhập đúng
            if (isValidLogin)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
                this.Hide();
                HoaDon = new HoaDon(username);
                isLogin = true;
                HoaDon.Show();

            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
