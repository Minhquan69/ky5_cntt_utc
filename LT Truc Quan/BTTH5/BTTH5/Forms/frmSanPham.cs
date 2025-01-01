using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BTTH5.Forms
{
    public partial class frmSanPham : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        string imageName = "";

        public frmSanPham(string tenNhanVien)
        {
            InitializeComponent();
            LoadMaterialComboBox();
            LoadData();
            lbuser.Text = "Xin chào: " + tenNhanVien;
        }

        private void LoadMaterialComboBox()
        {
            DataTable dtCL = dtBase.ReadData("Select * from tblChatLieu");
            cboChatLieu.DataSource = dtCL;
            cboChatLieu.DisplayMember = "TenChatLieu";
            cboChatLieu.ValueMember = "MaChatLieu";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            DataTable dtHang = dtBase.ReadData("SELECT * FROM tblHang");
            dgvHang.DataSource = dtHang;

            // Đặt tiêu đề cột
            dgvHang.Columns[0].HeaderText = "Mã hàng";
            dgvHang.Columns[1].HeaderText = "Tên hàng";
            dgvHang.Columns[2].HeaderText = "Chất liệu";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Giá nhập";
            dgvHang.Columns[5].HeaderText = "Giá bán";
            dgvHang.Columns[6].HeaderText = "File Ảnh";
            dgvHang.Columns[7].HeaderText = "Ghi chú";

            ResetValue();
        }

        void ResetValue()
        {
            txtMa.Clear();
            TxtTen.Clear();
            cboChatLieu.Text = "";
            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            txtDonGiaBan.Clear();
            piBImage.Image = null;
            txtGhiChu.Clear();
            txtMa.Enabled = true;
            txtMa.Focus();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] file;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap Images|*.bmp|JPEG Images|*.jpg|All Files|*.*";
            openFile.FilterIndex = 2;
            openFile.InitialDirectory = Application.StartupPath + "\\Images\\Hang";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                piBImage.Image = Image.FromFile(openFile.FileName);
                file = openFile.FileName.Split('\\');
                imageName = file[file.Length - 1];

            }
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMa.Text = dgvHang.CurrentRow.Cells[0].Value.ToString();
            TxtTen.Text = dgvHang.CurrentRow.Cells[1].Value.ToString();
            cboChatLieu.Text = "";
            cboChatLieu.SelectedText = dgvHang.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.Text = dgvHang.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaNhap.Text = dgvHang.CurrentRow.Cells[4].Value.ToString();
            txtDonGiaBan.Text = dgvHang.CurrentRow.Cells[5].Value.ToString();
            imageName = dgvHang.CurrentRow.Cells[6].Value.ToString();
            if (imageName != "")
                piBImage.Image = Image.FromFile(Application.StartupPath + "\\Images\\Hang\\" + imageName);
            //
            txtGhiChu.Text = dgvHang.CurrentRow.Cells[7].Value.ToString();

            ToggleControlState(false);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
        }

        private void ToggleControlState(bool isEnabled)
        {
            txtMa.Enabled = isEnabled;
            TxtTen.Enabled = isEnabled;
            cboChatLieu.Enabled = isEnabled;
            txtDonGiaBan.Enabled = isEnabled;
            txtDonGiaNhap.Enabled = isEnabled;
            txtSoLuong.Enabled = isEnabled;
            btnAnh.Enabled = isEnabled;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHang = dgvHang.CurrentRow.Cells[0].Value.ToString();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm có mã hàng '{maHang}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM tblHang WHERE Mahang = '{maHang}'";

                try
                {
                    dtBase.ChangeData(sqlDelete);
                    LoadData();
                    ResetValue();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            TxtTen.Enabled = true;
            cboChatLieu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            btnAnh.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string sql = $"INSERT INTO tblHang VALUES ('{txtMa.Text}', N'{TxtTen.Text}', '{cboChatLieu.SelectedValue}', " +
                $"{txtSoLuong.Text}, {txtDonGiaNhap.Text}, {txtDonGiaBan.Text}, '{imageName}', N'{txtGhiChu.Text}')";

            try
            {
                dtBase.ChangeData(sql);
                LoadData();
                ResetValue();
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar); // Kiểm tra chỉ cho phép số
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar); // Kiểm tra chỉ cho phép số
        }

        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar); // Kiểm tra chỉ cho phép số
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string sqlUpdate = $"UPDATE tblHang SET " +
                               $"Tenhang = N'{TxtTen.Text}', " +
                               $"ChatLieu = '{cboChatLieu.Text}', " +
                               $"Soluong = {txtSoLuong.Text}, " +
                               $"Dongianhap = {txtDonGiaNhap.Text}, " +
                               $"Dongiaban = {txtDonGiaBan.Text}, " +
                               $"Anh = '{imageName}', " +
                               $"GhiChu = N'{txtGhiChu.Text}' " +
                               $"WHERE Mahang = '{txtMa.Text}'";

            try
            {
                dtBase.ChangeData(sqlUpdate);
                LoadData();
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
                string.IsNullOrWhiteSpace(TxtTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtDonGiaBan.Text) ||
                string.IsNullOrWhiteSpace(cboChatLieu.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Kiểm tra đơn giá bán phải lớn hơn đơn giá nhập
            if (decimal.TryParse(txtDonGiaNhap.Text, out decimal donGiaNhap) &&
                decimal.TryParse(txtDonGiaBan.Text, out decimal donGiaBan))
            {
                if (donGiaBan <= donGiaNhap)
                {
                    MessageBox.Show("Đơn giá bán phải lớn hơn đơn giá nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            ToggleControlState(true); 
            btnHuy.Enabled = false;
        }

       
    }
}
