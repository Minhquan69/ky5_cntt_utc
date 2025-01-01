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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace de1
{
    public partial class frmVatLieu : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        string imageName = "";
        public frmVatLieu()
        {
            InitializeComponent();
            loadData();


        }
        private void loadData()
        {
            DataTable dtHang = dtBase.ReadData("SELECT * FROM VatLieu");
            dgvdata.DataSource = dtHang;

            // Đặt tiêu đề cột
            dgvdata.Columns[0].HeaderText = "Mã Vật Liệu";
            dgvdata.Columns[1].HeaderText = "Tên Vật Liệu";
            dgvdata.Columns[2].HeaderText = "Đơn Vị Tính";
            dgvdata.Columns[3].HeaderText = "Giá Nhập";
            dgvdata.Columns[4].HeaderText = "Giá Bán";
            dgvdata.Columns[5].HeaderText = "File Anh";
            dgvdata.Columns[6].HeaderText = "Ghi chú";
            dgvdata.Columns[7].HeaderText = "Số Lượng";

            ResetValue();
        }
        void ResetValue()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDV.Clear();
            giaNhap.Clear();
            giaBan.Clear();
            txtSL.Clear();
            txtGiChu.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnBoQua.Enabled = true;
            ptbanh.Image = null;
        }

        private void frmVatLieu_Load(object sender, EventArgs e)
        {

        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            string[] file;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap Images|*.bmp|JPEG Images|*.jpg|All Files|*.*";
            openFile.FilterIndex = 2;
            openFile.InitialDirectory = Application.StartupPath + "\\Images\\Hang";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptbanh.Image = Image.FromFile(openFile.FileName);
                file = openFile.FileName.Split('\\');
                imageName = file[file.Length - 1];

            }
        }

        private void giaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", giaNhap, giaNhap.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip1.Hide(giaNhap);
            }
        }

        private void giaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", giaBan, giaBan.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip2.Hide(giaBan);
            }
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Hiển thị ToolTip chỉ khi nhập ký tự không phải số
                toolTip1.Show("Chỉ được nhập số nguyên", txtSL, txtSL.Width / 2, 20, 1000); // Thông báo sẽ hiển thị tại vị trí của textbox
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
            else
            {
                // Ẩn ToolTip khi nhập đúng
                toolTip3.Hide(txtSL);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô đầu vào xem có trống không
            if (string.IsNullOrEmpty(txtMa.Text) || string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(giaNhap.Text)
                || string.IsNullOrEmpty(giaBan.Text) || string.IsNullOrEmpty(txtSL.Text) || string.IsNullOrEmpty(txtGiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu.");
                return;
            }

            
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["MaVL"].Value != null && row.Cells["MaVL"].Value.ToString() == txtMa.Text)
                {
                    MessageBox.Show("Mã vật liệu đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }
            }

            // Chuẩn bị câu lệnh SQL để thêm dữ liệu vào bảng
            string sql = $"INSERT INTO VatLieu (MaVL, TenVatLieu, DonViTinh, GiaNhap, GiaBan,SoLuong,Anh,GhiChu) " +
                           $"VALUES (N'{txtMa.Text.Trim()}', N'{txtTen.Text.Trim()}', N'{txtDV.Text.Trim()}', N'{giaNhap.Text.Trim()}', N'{giaBan.Text.Trim()}', N'{txtSL.Text.Trim()}', N'{imageName}',N'{txtGiChu.Text.Trim()}')";

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

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdata.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaVL"].Value.ToString();
                txtTen.Text = row.Cells["TenVatLieu"].Value.ToString();
                txtDV.Text = row.Cells["DonViTinh"].Value.ToString();
                giaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                giaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtSL.Text = row.Cells["SoLuong"].Value.ToString();
                txtGiChu.Text = row.Cells["GhiChu"].Value?.ToString(); // Hiển thị ghi chú
                imageName = row.Cells["Anh"].Value?.ToString();
                if (imageName != "")
                    ptbanh.Image = Image.FromFile(Application.StartupPath + "\\Images\\VatLieu\\" + imageName);
                else ptbanh.Image = null;

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                txtMa.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHang = dgvdata.CurrentRow.Cells[0].Value.ToString();
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm có mã hàng '{maHang}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sqlDelete = $"DELETE FROM VatLieu WHERE MaVL = '{maHang}'";

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled=true;
            if (!ValidateInput()) return;

            string sqlUpdate = $"UPDATE VatLieu SET " +
                               $"TenVatLieu = N'{txtTen.Text}', " +
                               $"DonViTinh = '{txtDV.Text}', " +
                               $"SoLuong = {txtSL.Text}, " +
                               $"GiaNhap = {giaNhap.Text}, " +
                               $"GiaBan = {giaBan.Text}, " +
                               $"Anh = '{imageName}', " +
                               $"GhiChu = N'{txtGiChu.Text}' " +
                               $"WHERE MaVL = '{txtMa.Text.Trim()}'";

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
                string.IsNullOrWhiteSpace(txtSL.Text) ||
                string.IsNullOrWhiteSpace(giaBan.Text) ||
                string.IsNullOrWhiteSpace(giaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtDV.Text) ||
                string.IsNullOrWhiteSpace(txtSL.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
