using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMenu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            listBox1.Items.AddRange(new string[]
            {
                "Kỹ thuật lập trình C#",
                "Tự học Visual C# trong 21 ngày",
                ".NET toàn tập - tập 1",
                ".NET toàn tập - tập 2",
                ".NET toàn tập - tập 3",
                ".NET toàn tập - tập 4",
                ".NET toàn tập - tập 5",
                ".NET toàn tập - tập 6",
                "Tin học căn bản SQL server",
                "Cơ bản về XML",
                "Phân tích thiết kế hệ thống",
                "Sử dụng Dreamweaver 8.0",
                "Đèn với word 2003"
            });
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                if (!listBox2.Items.Contains(selectedItem)) // Kiểm tra nếu mặt hàng chưa được chọn
                {
                    listBox2.Items.Add(selectedItem);
                }
                else
                {
                    MessageBox.Show("Bạn đã chọn mặt hàng này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btndy_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin đã nhập
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBox2.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một mặt hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin từ các điều khiển
            string hoTen = txtHoTen.Text;
            string dienThoai = txtDienThoai.Text;

            // Lấy danh sách các mặt hàng đã chọn
            string danhSachMatHang = "";
            foreach (var item in listBox2.Items)
            {
                danhSachMatHang += item.ToString() + "\n";
            }

            // Lấy phương thức thanh toán
            string phuongThucThanhToan = "";
            if (rdoTienMat.Checked)
            {
                phuongThucThanhToan = "Tiền mặt";
            }
            else if (rdoSec.Checked)
            {
                phuongThucThanhToan = "Sec";
            }
            else if (rdoTheTinDung.Checked)
            {
                phuongThucThanhToan = "Thẻ tín dụng";
            }

            // Lấy hình thức liên lạc
            string hinhThucLienLac = "";
            if (rdoDienThoai.Checked)
            {
                hinhThucLienLac = "Điện thoại";
            }
            else if (rdoFax.Checked)
            {
                hinhThucLienLac = "Fax";
            }
            else if (rdoEmail.Checked)
            {
                hinhThucLienLac = "Email";
            }

            // Hiển thị thông tin đơn hàng
            string thongTin = $"Tên khách: {hoTen}\n" +
                              $"Điện thoại: {dienThoai}\n" +
                              $"Danh sách mặt hàng đã mua:\n{danhSachMatHang}" +
                              $"Phương thức thanh toán: {phuongThucThanhToan}\n" +
                              $"Hình thức liên lạc: {hinhThucLienLac}";

            MessageBox.Show(thongTin, "Thông tin đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa {selectedItem} không?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    listBox2.Items.Remove(selectedItem); // Xóa mặt hàng nếu người dùng chọn "Yes"
                }
            }
        }
    }
}
