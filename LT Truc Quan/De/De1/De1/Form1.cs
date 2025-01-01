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

namespace De1
{
    public partial class Form1 : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        string imageName = "";
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            DataTable dtHang = dtBase.ReadData("SELECT * FROM VatLieu");
            dgvData.DataSource = dtHang;
            // Đặt tiêu đề cột
            dgvData.Columns[0].HeaderText = "Mã Vật Liệu";
            dgvData.Columns[1].HeaderText = "Tên Vật Liệu";
            dgvData.Columns[2].HeaderText = "Đơn Vị Tính";
            dgvData.Columns[3].HeaderText = "Giá Nhập";
            dgvData.Columns[4].HeaderText = "Giá Bán";
            dgvData.Columns[6].HeaderText = "File Anh";
            dgvData.Columns[7].HeaderText = "Ghi chú";
            dgvData.Columns[5].HeaderText = "Số Lượng";
            ResetValue();
        }
        void ResetValue()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDonVi.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtGhiChu.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnBoQua.Enabled = true;
            ptbAnh.Image = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô đầu vào xem có trống không
            if (string.IsNullOrEmpty(txtMa.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtGiaNhap.Text)
                || string.IsNullOrEmpty(txtGiaBan.Text) || string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu.");
                return;
            }
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["MaVL"].Value != null && row.Cells["MaVL"].Value.ToString() == txtMa.Text)
                {
                    MessageBox.Show("Mã vật liệu đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }
            }

            string sql = $"INSERT INTO VatLieu (MaVL, TenVatLieu, DonViTinh, GiaNhap, GiaBan,SoLuong,Anh,GhiChu) " +
                           $"VALUES (N'{txtMa.Text.Trim()}', N'{txtTen.Text.Trim()}', N'{txtDonVi.Text.Trim()}', N'{txtGiaNhap.Text.Trim()}', " +
                           $"N'{txtGiaBan.Text.Trim()}', N'{txtSoLuong.Text.Trim()}', N'{imageName}',N'{txtGhiChu.Text.Trim()}')";

            try
            {
                dtBase.ChangeData(sql);
                LoadData();
                // Thông báo thêm sản phẩm thành công
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            string[] file;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap Images|*.bmp|JPEG Images|*.jpg|All Files|*.*";
            openFile.FilterIndex = 2;
            openFile.InitialDirectory = Application.StartupPath + "\\Images\\VatLieu";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.Image = Image.FromFile(openFile.FileName);
                file = openFile.FileName.Split('\\');
                imageName = file[file.Length - 1];
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtGiaNhap, txtGiaNhap.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtGiaNhap);
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtGiaBan, txtGiaBan.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtGiaBan);
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtSoLuong, txtSoLuong.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(txtSoLuong);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaVL"].Value.ToString();
                txtTen.Text = row.Cells["TenVatLieu"].Value.ToString();
                txtDonVi.Text = row.Cells["DonViTinh"].Value.ToString();
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString(); 
                imageName = row.Cells["Anh"].Value?.ToString();
                if (imageName != "")
                    ptbAnh.Image = Image.FromFile(Application.StartupPath + "\\Images\\VatLieu\\" + imageName);
                //

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                txtMa.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHang = dgvData.CurrentRow.Cells[0].Value.ToString();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm có mã hàng '{maHang}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM VatLieu WHERE MaVL = '{maHang}'";

                try
                {
                    dtBase.ChangeData(sqlDelete);
                    LoadData();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (!ValidateInput()) return;
            string sqlUpdate = $"UPDATE VatLieu SET " +
                               $"TenVatLieu = N'{txtTen.Text}', " +
                               $"DonViTinh = '{txtDonVi.Text}', " +
                               $"SoLuong = {txtSoLuong.Text}, " +
                               $"GiaNhap = {txtGiaNhap.Text}, " +
                               $"GiaBan = {txtGiaBan.Text}, " +
                               $"Anh = '{imageName}', " +
                               $"GhiChu = N'{txtGhiChu.Text}' " +
                               $"WHERE MaVL = '{txtMa.Text.Trim()}'";

            try
            {
                dtBase.ChangeData(sqlUpdate);
                LoadData();
                txtMa.Enabled = true;
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
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtDonVi.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

    }
}
