using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace KTra
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
            DataTable dtNV = dtBase.ReadData("SELECT * FROM tblMonHoc");
            dgvdata.DataSource = dtNV;

            // Đặt tiêu đề cột
            dgvdata.Columns[0].HeaderText = "Mã môn";
            dgvdata.Columns[1].HeaderText = "Tên môn";
            dgvdata.Columns[2].HeaderText = "Số TC";
            ResetValue();
        }
        void ResetValue()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtTC.Clear();
            //txtLuong.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu không phải ký tự số hoặc không phải phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên dương", txtTC, txtTC.Width / 2, 20, 1000);
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            // Kiểm tra nếu độ dài của TextBox đã đạt tối đa 2 ký tự
            else if (txtTC.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip khi vượt quá 2 ký tự
                toolTip1.Show("Chỉ được nhập tối đa 2 ký tự", txtTC, txtTC.Width / 2, 20, 1000);
                e.Handled = true; // Ngăn không cho nhập thêm ký tự
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtTC);
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

        private void txtMon_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Yellow;
        }

        private void txtMon_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtTC_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.White;
        }

        private void txtTC_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = Color.Yellow;
        }

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdata.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaMon"].Value.ToString();
                txtTen.Text = row.Cells["TenMonHoc"].Value.ToString();
                txtTC.Text = row.Cells["SoTinChi"].Value.ToString();
                

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMa.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mamon = dgvdata.CurrentRow.Cells[0].Value.ToString();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Môn học có mã hàng '{mamon}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM tblMonHoc WHERE Mamon = '{mamon}'";

                try
                {
                    dtBase.ChangeData(sqlDelete);
                    loadData();
                    ResetValue();
                    MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValue();

                    // Cập nhật lại trạng thái nút
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            if (!ValidateInput()) return;
            string sqlUpdate = $"UPDATE tblMonHoc SET " +
                               $"TenMonHoc = N'{txtTen.Text}', " +
                               $"SoTinChi = '{txtTC.Text}' " +

                               $"WHERE MaMon = '{txtMa.Text.Trim()}'";

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
                string.IsNullOrWhiteSpace(txtTC.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
