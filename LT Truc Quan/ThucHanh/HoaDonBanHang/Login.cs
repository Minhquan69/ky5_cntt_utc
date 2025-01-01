using HoaDonBanHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoaDonBanHang
{
    public partial class Login : Form
    {
        private bool isLogin = false;
        private HoaDon  HoaDon ;
        private string username = "", password = "";
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;  // Vô hiệu hóa nút Maximize
            this.StartPosition = FormStartPosition.CenterScreen;  // Căn giữa màn hình
            mk.PasswordChar = '*';
        }
        private void login_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                DataProcesser dataProcesser = new DataProcesser();
                string username = tk.Text;
                string password = mk.Text;

                // Kiểm tra nếu tên đăng nhập hoặc mật khẩu để tránh truy vấn sai
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                    return;
                }

                // Gọi hàm CheckLogin với username và password
                if (dataProcesser.CheckLogin(username, password))
                {
                    
                    this.Hide();
                    HoaDon = new HoaDon(username);
                    isLogin = true;
                    HoaDon.Show();
                }
                else
                {
                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác.");
                }
            }
        }


        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
