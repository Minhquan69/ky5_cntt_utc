using ClosedXML.Excel;
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

namespace dektracntt4
{
    public partial class frmNhanVien : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        string imageName = "";
        public frmNhanVien()
        {
            InitializeComponent();
            LoadMaterialComboBox();
            loadData();
        }
        private void LoadMaterialComboBox()
        {
            DataTable dtCL = dtBase.ReadData("SELECT * FROM PhongBan");
            txtPhongBan.DataSource = dtCL;
            txtPhongBan.DisplayMember = "TenPhongBan";  // Hiển thị tên chất liệu
            txtPhongBan.ValueMember = "MaPhongBan";     // Lưu trữ mã chất liệu khi chọn
            txtPhongBan.SelectedIndex = -1;              // Đặt mặc định là không chọn gì
        }
        private void loadData()
        {
            DataTable dtNV = dtBase.ReadData("SELECT MaNV, TenNV," +
                "SoDT, GioiTinh, TenPhongBan, MucLuong, Anh FROM NhanVien " +
                "join PhongBan on NhanVien.MaPhongBan = PhongBan.MaPhongBan");
            dgvdata.DataSource = dtNV;

            // Đặt tiêu đề cột
            dgvdata.Columns[0].HeaderText = "Mã NV";
            dgvdata.Columns[1].HeaderText = "Tên NV";
            dgvdata.Columns[2].HeaderText = "Số DT";
            dgvdata.Columns[3].HeaderText = "Giới Tính";
            dgvdata.Columns[4].HeaderText = "Phòng Ban";
            dgvdata.Columns[5].HeaderText = "Mức lương";
            dgvdata.Columns[6].HeaderText = "Ảnh";

            ResetValue();
        }
        void ResetValue()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtLuong.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count > 0)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DanhSachMatHang");

                    // Thêm tiêu đề
                    worksheet.Cell("B1").Value = "CTY Đào Minh Quân";
                    worksheet.Range("B1:H1").Merge();
                    worksheet.Range("B1:H1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Range("B1:H1").Style.Font.FontColor = XLColor.Blue;

                    worksheet.Cell("B2").Value = "Địa Chỉ: VIETNAMESE";
                    worksheet.Range("B2:H2").Merge();
                    worksheet.Range("B2:H2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell("B4").Value = "DSNhanVien";
                    worksheet.Range("B4:H4").Merge();
                    worksheet.Range("B4:H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Range("B4:H4").Style.Font.FontColor = XLColor.Red;

                    // Thêm tiêu đề cột
                    worksheet.Cell("B6").Value = "STT";
                    worksheet.Cell("C6").Value = "Mã NV";
                    worksheet.Cell("D6").Value = "Tên NV";
                    worksheet.Cell("E6").Value = "Số DT";
                    worksheet.Cell("F6").Value = "Giới tính";
                    worksheet.Cell("G6").Value = "Phòng ban";
                    worksheet.Cell("H6").Value = "MucLuong";
                    worksheet.Range("B6:H6").Style.Font.Bold = true;
                    worksheet.Range("B6:H6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Điền dữ liệu từ DataGridView
                    decimal totalAmount = 0;
                    int row = 7;
                    for (int i = 0; i < dgvdata.Rows.Count - 1; i++)
                    {
                        worksheet.Cell(row, 2).Value = (i + 1).ToString();
                        worksheet.Cell(row, 3).Value = dgvdata.Rows[i].Cells["MaNV"].Value?.ToString();
                        worksheet.Cell(row, 4).Value = dgvdata.Rows[i].Cells["TenNV"].Value?.ToString();
                        worksheet.Cell(row, 5).Value = dgvdata.Rows[i].Cells["SoDT"].Value?.ToString();
                        worksheet.Cell(row, 6).Value = dgvdata.Rows[i].Cells["GioiTinh"].Value?.ToString();
                        worksheet.Cell(row, 7).Value = dgvdata.Rows[i].Cells["TenPhongBan"].Value?.ToString();  // Để trống cho ghi chú nếu cần
                        worksheet.Cell(row, 8).Value = dgvdata.Rows[i].Cells["MucLuong"].Value?.ToString();
                        worksheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";

                        // Tính toán "Thành Tiền"

                        decimal tien = Convert.ToDecimal(dgvdata.Rows[i].Cells["MucLuong"].Value);
                        totalAmount += tien;

                        row++;
                    }

                    // Tính tổng tiền
                    worksheet.Cell(row, 7).Value = "TỔNG Lương:";
                    worksheet.Cell(row, 8).Value = totalAmount;
                    worksheet.Cell(row, 8).Style.Font.Bold = true;
                    worksheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";

                    // Tự động điều chỉnh độ rộng cột
                    worksheet.Columns().AdjustToContents();

                    // Lưu file
                    string filePath = @"E:\DanhSachNV.xlsx"; // Đổi đường dẫn nếu cần
                    workbook.SaveAs(filePath);

                    MessageBox.Show("Lưu thành công tại " + filePath);
                }
            }
            else
            {
                MessageBox.Show("Không có danh sách hàng để in.");
            }
        }

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdata.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaNV"].Value.ToString();
                txtTen.Text = row.Cells["TenNV"].Value.ToString();
                txtSDT.Text = row.Cells["SoDT"].Value.ToString();
                txtLuong.Text = row.Cells["MucLuong"].Value.ToString();
                txtPhongBan.Text = row.Cells["TenPhongBan"].Value.ToString();
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh.Equals("Nam"))
                    radioButtonNam.Checked = true;
                else
                    radioButtonNu.Checked = true;
                imageName = row.Cells["Anh"].Value?.ToString();
                if (imageName != "")
                    ptbanh.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + imageName);
                //

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                txtMa.Enabled = false;
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            string[] file;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap Images|*.bmp|JPEG Images|*.jpg|All Files|*.*";
            openFile.FilterIndex = 2;
            openFile.InitialDirectory = Application.StartupPath + "\\Images";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptbanh.Image = Image.FromFile(openFile.FileName);
                file = openFile.FileName.Split('\\');
                imageName = file[file.Length - 1];

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường dữ liệu cần nhập
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NV.");
                return;
            }

            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên NV.");
                return;
            }

            // Kiểm tra Giới tính
            if (!radioButtonNam.Checked && !radioButtonNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.");
                return;
            }

            if (string.IsNullOrEmpty(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Mức lương.");
                return;
            }
            // Nếu vượt qua tất cả các kiểm tra, tiếp tục xử lý thêm nhân viên.

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["MaNV"].Value != null && row.Cells["MaNV"].Value.ToString() == txtMa.Text)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }
            }
            string maNV = txtMa.Text;
            string tenNV = txtTen.Text;
            string soDT = txtSDT.Text;
            string gioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ";
            string anh = imageName != "" ? imageName : ""; // Lưu ảnh vào thư mục và lấy tên ảnh
            decimal mucLuong = Convert.ToDecimal(txtLuong.Text);


            // Kiểm tra xem người dùng có chọn phòng ban trong ComboBox không


            string sql = $"INSERT INTO NhanVien (MaNV, TenNV, SoDT, GioiTinh, MaPhongBan,MucLuong,Anh) " +
                           $"VALUES (N'{maNV}', N'{tenNV}', N'{soDT}', N'{gioiTinh}', N'{txtPhongBan.SelectedValue.ToString().Trim()}', {mucLuong}, N'{imageName}')";

            try
            {
                // Thực hiện câu lệnh SQL để thay đổi dữ liệu trong cơ sở dữ liệu
                dtBase.ChangeData(sql);

                // Tải lại dữ liệu để cập nhật DataGridView
                loadData();

                // Đặt lại các ô nhập về giá trị mặc định
                ResetValue();

                // Thông báo thêm sản phẩm thành công
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            if (!ValidateInput()) return;
            string gioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ";
            string sqlUpdate = $"UPDATE NhanVien SET " +
                               $"TenNV = N'{txtTen.Text}', " +
                               $"SoDT = '{txtSDT.Text}', " +
                               $"GioiTinh = N'{gioiTinh}', " +
                               $"MaPhongBan = N'{txtPhongBan.SelectedValue.ToString().Trim()}', " +
                               $"MucLuong = {txtLuong.Text}, " +
                               $"Anh = '{imageName}' " +
                               
                               $"WHERE MaNV = '{txtMa.Text.Trim()}'";

            try
            {
                dtBase.ChangeData(sqlUpdate);
                loadData();
                ResetValue();
                MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text) ||
                (!radioButtonNam.Checked && !radioButtonNu.Checked))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manv = dgvdata.CurrentRow.Cells[0].Value.ToString();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm có mã hàng '{manv}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM NhanVien WHERE MaNV = '{manv}'";

                try
                {
                    dtBase.ChangeData(sqlDelete);
                    loadData();
                    ResetValue();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValue();

                    // Cập nhật lại trạng thái nút
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
