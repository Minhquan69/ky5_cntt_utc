using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        

        private void btnLamlai_Click(object sender, EventArgs e)
        {
                // Xóa các dữ liệu nhập và kết quả
                txtThang.Clear();
                txtNam.Clear();
                labelKQ.Text = string.Empty;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã nhập đầy đủ tháng và năm
            if (string.IsNullOrWhiteSpace(txtThang.Text) || string.IsNullOrWhiteSpace(txtNam.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tháng và năm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dữ liệu nhập vào là số nguyên
            if (int.TryParse(txtThang.Text, out int thang) && int.TryParse(txtNam.Text, out int nam))
            {
                // Kiểm tra giá trị tháng và năm hợp lệ
                if (thang >= 1 && thang <= 12 && nam > 999 && nam < 10000)
                {
                    // Tính số ngày trong tháng và năm
                    int soNgay = DateTime.DaysInMonth(nam, thang);
                    labelKQ.Text = $"Số ngày của tháng {thang}/{nam} là: {soNgay} ngày.";
                }
                else
                {
                    MessageBox.Show("Tháng phải từ 1 đến 12 và năm phải gồm 4 chữ số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tháng và năm là số nguyên.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập vào không phải là một chữ số và không phải là phím backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số", txtThang, txtThang.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtThang);
            }
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu giá trị trong txtThang không phải là số
            if (!int.TryParse(txtNam.Text, out _))
            {
                MessageBox.Show("Vui lòng chỉ nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        
    }
}
