using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VA2
{
    public partial class Form1 : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        public Form1()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            DataTable dtHang = dtBase.ReadData("SELECT * FROM tKhachHang");
            dgvdata.DataSource = dtHang;

            // Đặt tiêu đề cột
            dgvdata.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvdata.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvdata.Columns[2].HeaderText = "Địa Chỉ";
            dgvdata.Columns[3].HeaderText = "Ngày Chốt Sổ";
            dgvdata.Columns[4].HeaderText = "Số Tháng Trước";
            dgvdata.Columns[5].HeaderText = "Số Tháng Sau";
            dgvdata.Columns[6].HeaderText = "Tổng Tiền";
            ResetValue();
        }
        void ResetValue()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtThangTruoc.Clear();
            txtThangNay.Clear(); 
            txtNgay.Clear();
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnThemVao.Enabled = true;
        }
        
        private void btnThemVao_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô đầu vào xem có trống KhachHangông
            if (string.IsNullOrEmpty(txtMa.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtDiaChi.Text)
                || string.IsNullOrEmpty(txtThangTruoc.Text) || string.IsNullOrEmpty(txtThangNay.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu.");
                return;
            }

            if (txtMa.Text.Length != 6)
            {
                MessageBox.Show("Mã Khách hàng phải có đúng 6 ký tự.");
                return;
            }
            DateTime ngayChotSo;
            if (!DateTime.TryParse(txtNgay.Text, out ngayChotSo))
            {
                MessageBox.Show("Ngày chốt số Không đúng định dạng. Vui lòng nhập lại.");
                return;
            }
            decimal soThangTruoc, soThangSau;
            if (!decimal.TryParse(txtThangTruoc.Text, out soThangTruoc) || !decimal.TryParse(txtThangNay.Text, out soThangSau))
            {
                MessageBox.Show("Số điện tháng trước và tháng này phải là số hợp lệ.");
                return;
            }

            if (soThangTruoc >= soThangSau)
            {
                MessageBox.Show("Số điện tháng trước phải nhỏ hơn số điện tháng này.");
                return;
            }
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["MaKhachHang"].Value != null && row.Cells["MaKhachHang"].Value.ToString() == txtMa.Text)
                {
                    MessageBox.Show("Mã KhachHang đã tồn tại. Vui lòng nhập mã Khác.");
                    return;
                }
            }
            // Tính số tiền điện
            decimal soDienTieuThu = soThangSau - soThangTruoc;
            decimal tongTien = 0;

            if (soDienTieuThu <= 50)
            {
                tongTien = soDienTieuThu * 100;
            }
            else if (soDienTieuThu <= 100)
            {
                tongTien = (50 * 100) + ((soDienTieuThu - 50) * 200);
            }
            else if (soDienTieuThu <= 200)
            {
                tongTien = (50 * 100) + (50 * 200) + ((soDienTieuThu - 100) * 300);
            }
            else
            {
                tongTien = (50 * 100) + (50 * 200) + (100 * 300) + ((soDienTieuThu - 200) * 400);
            }

            // Cộng thêm thuế VAT 10%
            tongTien *= 1.1m;
            // Sửa lỗi ở vòng lặp này để duyệt qua DataGridViewRow thay vì DataRow


            // Chuẩn bị câu lệnh SQL để thêm dữ liệu vào bảng
            string sql = $"INSERT INTO tKhachHang (MaKhachHang, TenKhachHang, DiaChi, NgayChotSo, SoThangTruoc, SoThangSau, TongTien) " +
                 $"VALUES (N'{txtMa.Text.Trim()}', N'{txtTen.Text.Trim()}', N'{txtDiaChi.Text.Trim()}', '{ngayChotSo:yyyy-MM-dd}', {soThangTruoc}, {soThangSau}, {tongTien})";

            try
            {
                // Thực hiện câu lệnh SQL để thay đổi dữ liệu trong cơ sở dữ liệu
                dtBase.ChangeData(sql);

                // Tải lại dữ liệu để cập nhật DataGridView
                loadData();

                // Đặt lại các ô nhập về giá trị mặc định
                ResetValue();

                // Thông báo thêm KhachHangách hàng thành công
                MessageBox.Show("Thêm Khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHang = dgvdata.CurrentRow.Cells[0].Value.ToString();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa KhachHang có mã hàng '{maHang}' Không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM tKhachHang WHERE MaKhachHang = '{maHang}'";
                try
                {
                    dtBase.ChangeData(sqlDelete);
                    loadData();
                    ResetValue();
                    MessageBox.Show("Xóa KhachHang thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValue();
                    // Cập nhật lại trạng thái nút
                    btnCapNhat.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThemMoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdata.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtTen.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtNgay.Text = row.Cells["NgayChotSo"].Value.ToString();
                txtThangTruoc.Text = row.Cells["SoThangTruoc"].Value.ToString();
                txtThangNay.Text= row.Cells["SoThangSau"].Value.ToString();
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThemVao.Enabled = false;
                txtMa.Enabled = false;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có muốn thoát Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtThangTruoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtThangTruoc, txtThangTruoc.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtThangTruoc);
            }
        }

        private void txtThangNay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtThangNay, txtThangNay.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtThangNay);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtNgay.Text)
                || string.IsNullOrEmpty(txtThangTruoc.Text) || string.IsNullOrEmpty(txtThangNay.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu.");
                return;
            }
            DateTime ngayChotSo;
            if (!DateTime.TryParse(txtNgay.Text, out ngayChotSo))
            {
                MessageBox.Show("Ngày chốt số Không đúng định dạng. Vui lòng nhập lại.");
                return;
            }
            decimal soThangTruoc, soThangSau;
            if (!decimal.TryParse(txtThangTruoc.Text, out soThangTruoc) || !decimal.TryParse(txtThangNay.Text, out soThangSau))
            {
                MessageBox.Show("Số điện tháng trước và tháng này phải là số hợp lệ.");
                return;
            }
            if (soThangTruoc >= soThangSau)
            {
                MessageBox.Show("Số điện tháng trước phải nhỏ hơn số điện tháng này.");
                return;
            }

            // Xác nhận trước khi cập nhật
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin khách hàng?",
                                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No)
            {
                return; // Nếu người dùng chọn No, thoát khỏi hàm
            }

            // Tính số tiền điện
            decimal soDienTieuThu = soThangSau - soThangTruoc;
            decimal tongTien = 0;

            if (soDienTieuThu <= 50)
            {
                tongTien = soDienTieuThu * 100;
            }
            else if (soDienTieuThu <= 100)
            {
                tongTien = (50 * 100) + ((soDienTieuThu - 50) * 200);
            }
            else if (soDienTieuThu <= 200)
            {
                tongTien = (50 * 100) + (50 * 200) + ((soDienTieuThu - 100) * 300);
            }
            else
            {
                tongTien = (50 * 100) + (50 * 200) + (100 * 300) + ((soDienTieuThu - 200) * 400);
            }
            // Cộng thêm thuế VAT 10%
            tongTien *= 1.1m;

            // Chuẩn bị câu lệnh SQL để thêm dữ liệu vào bảng
            string sql = $"UPDATE tKhachHang SET " +
                               $"TenKhachHang = N'{txtTen.Text}', " +
                               $"DiaChi = N'{txtDiaChi.Text}', " +
                               $"NgayChotSo = '{ngayChotSo:yyyy-MM-dd}', " +
                               $"SoThangTruoc =  {txtThangTruoc.Text}, " +
                               $"SoThangSau = {txtThangNay.Text}, " +
                               $"TongTien = '{tongTien}' " +
                               $"WHERE MaKhachHang = '{txtMa.Text.Trim()}'";

            try
            {
                // Thực hiện câu lệnh SQL để thay đổi dữ liệu trong cơ sở dữ liệu
                dtBase.ChangeData(sql);
                // Tải lại dữ liệu để cập nhật DataGridView
                loadData();
                // Đặt lại các ô nhập về giá trị mặc định
                ResetValue();
                // Thông báo cập nhật thành công
                MessageBox.Show("Cập nhật Khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count > 0)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DanhSachMatHang");

                    // Thêm tiêu đề
                    worksheet.Cell("B1").Value = "Đào Minh Quân";
                    worksheet.Range("B1:H1").Merge();
                    worksheet.Range("B1:H1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Range("B1:H1").Style.Font.FontColor = XLColor.Blue;

                    worksheet.Cell("B2").Value = "Địa Chỉ: VIETNAMESE";
                    worksheet.Range("B2:H2").Merge();
                    worksheet.Range("B2:H2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell("B4").Value = "DANH SÁCH KHÁCH HÀNG SỬ DỤNG ĐIỆN";
                    worksheet.Range("B4:H4").Merge();
                    worksheet.Range("B4:H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Range("B4:H4").Style.Font.FontColor = XLColor.Red;

                    // Thêm tiêu đề cột
                    worksheet.Cell("B6").Value = "STT";
                    worksheet.Cell("C6").Value = "Mã Khách Hàng";
                    worksheet.Cell("D6").Value = "Tên Khách Hàng";
                    worksheet.Cell("E6").Value = "Địa Chỉ";
                    worksheet.Cell("F6").Value = "Ngày Chốt Sổ";
                    worksheet.Cell("G6").Value = "Số Tháng Trước";
                    worksheet.Cell("H6").Value = "Số Tháng Sau";
                    worksheet.Cell("I6").Value = "Tổng Tiền";
                    worksheet.Range("B6:I6").Style.Font.Bold = true;
                    worksheet.Range("B6:I6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Điền dữ liệu từ DataGridView
                    decimal totalAmount = 0;
                    int row = 9;
                    for (int i = 0; i < dgvdata.Rows.Count - 1; i++)
                    {
                        worksheet.Cell(row, 2).Value = (i + 1).ToString();
                        worksheet.Cell(row, 3).Value = dgvdata.Rows[i].Cells["MaKhachHang"].Value?.ToString();
                        worksheet.Cell(row, 4).Value = dgvdata.Rows[i].Cells["TenKhachHang"].Value?.ToString();
                        worksheet.Cell(row, 5).Value = dgvdata.Rows[i].Cells["DiaChi"].Value?.ToString();
                        worksheet.Cell(row, 6).Value = dgvdata.Rows[i].Cells["NgayChotSo"].Value?.ToString();
                        worksheet.Cell(row, 7).Value = dgvdata.Rows[i].Cells["SoThangTruoc"].Value?.ToString();
                        worksheet.Cell(row, 8).Value = dgvdata.Rows[i].Cells["SoThangSau"].Value?.ToString();
                        worksheet.Cell(row, 9).Value = dgvdata.Rows[i].Cells["TongTien"].Value?.ToString();
                        worksheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";
                        if (decimal.TryParse(dgvdata.Rows[i].Cells["TongTien"].Value?.ToString(), out decimal tongTien))
                        {
                            totalAmount += tongTien;
                        }

                        row++;
                    }

                    // Tính tổng tiền
                    worksheet.Cell(row, 8).Value = "TỔNG TIỀN:";
                    worksheet.Cell(row, 9).Value = totalAmount;
                    worksheet.Cell(row, 9).Style.Font.Bold = true;

                    // Tự động điều chỉnh độ rộng cột
                    worksheet.Columns().AdjustToContents();

                    // Lưu file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Title = "Lưu file Danh sách Mặt Hàng",
                        Filter = "Excel Files|*.xlsx",
                        FileName = "KhacHangSuDungDien.xlsx"
                    })
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;
                            string fileName = Path.GetFileNameWithoutExtension(filePath);
                            string fileExtension = Path.GetExtension(filePath);
                            string directory = Path.GetDirectoryName(filePath);

                            int count = 1;
                            string newFilePath = filePath;

                            // Kiểm tra nếu file đã tồn tại thì thêm số vào tên file
                            while (File.Exists(newFilePath))
                            {
                                newFilePath = Path.Combine(directory, $"{fileName}_{count}{fileExtension}");
                                count++;
                            }

                            workbook.SaveAs(newFilePath);
                            MessageBox.Show("Xuất dữ liệu ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có danh sách hàng để in.");
            }
        }
    }
}
