using ClosedXML.Excel;
using de2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace de2
{
    public partial class frmHangHoa : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        public frmHangHoa()
        {
            InitializeComponent();
            LoadMaterialComboBox();
        }
        private void LoadMaterialComboBox()
        {
            DataTable dtCL = dtBase.ReadData("SELECT * FROM tblChatLieu");
            comboBoxChatLieu.DataSource = dtCL;
            comboBoxChatLieu.DisplayMember = "TenChatlieu";    
            comboBoxChatLieu.ValueMember = "MaChatlieu";    
            comboBoxChatLieu.SelectedIndex = -1;     
            ResetValue();
        }
        void ResetValue()
        {
            
            txtMa.Clear();
            txtTen.Clear();
            txtTu.Clear();
            txtDen.Clear();
            comboBoxChatLieu.SelectedIndex = -1;
        }
        private void txtTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtTu, txtTu.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtTu);
            }
        }

        private void txtDen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtDen, txtDen.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtDen);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = @"SELECT h.MaHang as 'Mã hàng', h.TenHang as 'Tên hàng', c.TenChatLieu as 'Chất liệu', h.DonGiaNhap as 'Giá Nhập', 
            h.DonGiaBan as 'Giá bán', h.SoLuong as 'Số Lượng'
            FROM tblHang h
            JOIN tblChatLieu c ON h.MaChatLieu = c.MaChatLieu
            WHERE 1=1";

            // Thêm các điều kiện vào câu truy vấn
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                query += " AND h.MaHang LIKE '%" + txtMa.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtTen.Text))
            {
                query += " AND h.TenHang LIKE N'%" + txtTen.Text + "%'";
            }
            if (comboBoxChatLieu.SelectedValue != null)
            {
                query += " AND h.MaChatLieu = '" + comboBoxChatLieu.SelectedValue.ToString().Trim() + "'";
            }
            if (!string.IsNullOrEmpty(txtTu.Text))
            {
                query += " AND h.DonGiaBan >= " + Convert.ToDecimal(txtTu.Text);
            }
            if (!string.IsNullOrEmpty(txtDen.Text))
            {
                query += " AND h.DonGiaBan <= " + Convert.ToDecimal(txtDen.Text);
            }

            // Sử dụng hàm ReadData để lấy dữ liệu
            try
            {
                DataTable dt = dtBase.ReadData(query);
                // Hiển thị kết quả trong DataGridView
                dgvdata.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInRaExcel_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count > 0)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Danh Sách Mặt Hàng");

                    // Thêm tiêu đề
                    worksheet.Cell("B1").Value = "CỬA HÀNG BÁN ĐỒ LƯU NIỆM BÌNH AN";
                    worksheet.Range("B1:H1").Merge();
                    worksheet.Range("B1:H1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell("B2").Value = "Địa chỉ: 37B - TT Đống Anh - Hà Nội";
                    worksheet.Range("B2:H2").Merge();
                    worksheet.Range("B2:H2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell("B3").Value = "Số điện thoại: 0987234567";
                    worksheet.Range("B3:H3").Merge();
                    worksheet.Range("B3:H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell("B4").Value = "DANH SÁCH CÁC MẶT HÀNG";
                    worksheet.Range("B4:H4").Merge();
                    worksheet.Range("B4:H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Range("B4:H4").Style.Font.FontColor = XLColor.Blue;

                    // Thêm tiêu đề cột
                    worksheet.Cell("B6").Value = "STT";
                    worksheet.Cell("C6").Value = "Mã hàng";
                    worksheet.Cell("D6").Value = "Tên hàng";
                    worksheet.Cell("E6").Value = "Chất liệu";
                    worksheet.Cell("F6").Value = "Giá nhập";
                    worksheet.Cell("G6").Value = "Giá bán";
                    worksheet.Cell("H6").Value = "Số lượng";
                    worksheet.Range("B6:H6").Style.Font.Bold = true;
                    worksheet.Range("B6:H6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Điền dữ liệu từ DataGridView
                    int row = 7;
                    int rowIndex = 1;
                    foreach (DataGridViewRow dgvRow in dgvdata.Rows)
                    {
                        if (dgvRow.Cells["Mã hàng"].Value != null)
                        {
                            worksheet.Cell(row, 2).Value = rowIndex; // Sequential numbering
                            worksheet.Cell(row, 3).Value = dgvRow.Cells["Mã hàng"].Value?.ToString();
                            worksheet.Cell(row, 4).Value = dgvRow.Cells["Tên hàng"].Value?.ToString();
                            worksheet.Cell(row, 5).Value = dgvRow.Cells["Chất liệu"].Value?.ToString();
                            worksheet.Cell(row, 6).Value = dgvRow.Cells["Giá Nhập"].Value?.ToString();
                            worksheet.Cell(row, 7).Value = dgvRow.Cells["Giá bán"].Value?.ToString();
                            worksheet.Cell(row, 8).Value = dgvRow.Cells["Số Lượng"].Value?.ToString();

                            row++;
                            rowIndex++;
                        }
                    }

                    // Tự động điều chỉnh độ rộng cột
                    worksheet.Columns().AdjustToContents();

                    // Lưu file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Title = "Lưu file Danh sách Mặt Hàng",
                        Filter = "Excel Files|*.xlsx",
                        FileName = "DanhSachMatHang.xlsx"
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


        private void txtMa_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Yellow;
        }

        private void txtMa_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtTen_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Yellow;
        }

        private void txtTu_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtTu_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Yellow;
        }

        private void txtDen_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtDen_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Yellow;
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenChatLieu = dgvdata.Rows[e.RowIndex].Cells["Chất liệu"].Value.ToString();

                string query = @"
            SELECT COUNT(*) 
            FROM tblHang h 
            JOIN tblChatLieu c ON h.MaChatLieu = c.MaChatLieu 
            WHERE c.TenChatLieu = @TenChatLieu";

                try
                {
                    DataProcesser dataProcessor = new DataProcesser();

                    // Tạo danh sách tham số
                    var parameters = new Dictionary<string, object>
            {
                { "@TenChatLieu", tenChatLieu }
            };

                    // Gọi phương thức ExecuteScalar
                    int count = dataProcessor.ExecuteScalar(query, parameters);

                    MessageBox.Show($"Có {count} mặt hàng có chất liệu '{tenChatLieu}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
