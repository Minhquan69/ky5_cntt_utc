using BTTH5.Classes;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTTH5.Forms
{
    public partial class frmHoaDon : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        Classes.Common cmn = new Classes.Common();

        double thanhTien;
        private object maHang;

        public frmHoaDon()
        {
            InitializeComponent();
            mahd_load();
        }


        void mahd_load()
        {

            // Lấy danh sách mã hóa đơn trong vòng 7 ngày gần đây
            DataTable dtHD = dtBase.ReadData("SELECT MaHDBan FROM tblHDBan WHERE NgayBan >= GETDATE()-7");
            cboHoaDon.DataSource = dtHD;
            cboHoaDon.DisplayMember = "MaHDBan";
        }

        void mahang_load()
        {
            DataTable dthang = dtBase.ReadData("Select * from tblHang");
            cbomahang.DataSource = dthang;
            //cboChatLieu.DisplayMember = "TenChatLieu";
            cbomahang.ValueMember = "MaHang";
        }

        void makhach_load()
        {
            DataTable dtkhach = dtBase.ReadData("Select * from tblKhach");
            cbomakhach.DataSource = dtkhach;
            cbomakhach.ValueMember = "MaKhach";

        }
        void LoadData()
        {
            mahang_load();
            mahd_load();
            makhach_load();
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();

            // Kiểm tra nếu mã nhân viên không rỗng
            if (!string.IsNullOrEmpty(Program.maNV))
            {
                // Truy vấn thông tin nhân viên dựa theo mã nhân viên
                DataTable dtNhanVien = dtBase.ReadData($"SELECT MaNhanVien, TenNhanVien FROM tblNhanVien WHERE MaNhanVien = '{Program.maNV}'");
                if (dtNhanVien.Rows.Count > 0)
                {
                    // Gán thông tin nhân viên vào các TextBox
                    txtmanhanvien.Text = Program.maNV;
                    txttennhanvien.Text = dtNhanVien.Rows[0]["TenNhanVien"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với mã: " + Program.maNV, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetStutusProduct()
        {

            txttenhang.Clear();
            txtdongia.Clear();
            txtsoluong.Clear();
            txtgiamgia.Clear();
            txtthanhtien.Clear();
            txttenhang.Clear();
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        { 
            resetStutusProduct();

            if (string.IsNullOrWhiteSpace(cboHoaDon.Text))
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtHDBan = dtBase.ReadData($"SELECT * FROM tblHDBan WHERE MaHDBan='{cboHoaDon.Text}'");
            if (dtHDBan.Rows.Count > 0)
            {

                txtmahoadon.Text = dtHDBan.Rows[0]["MaHDBan"].ToString();
                dtpngayban.Text = dtHDBan.Rows[0]["NgayBan"].ToString();
                lbltongtien.Text = "Tổng tiền: " + dtHDBan.Rows[0]["TongTien"].ToString();

                txtmanhanvien.Text = dtHDBan.Rows[0]["MaNhanVien"].ToString();
                DataTable dtnv = dtBase.ReadData($"SELECT * FROM tblNhanVien WHERE MaNhanVien = '{txtmanhanvien.Text}'");
                if (dtnv.Rows.Count > 0)
                {
                    txttennhanvien.Text = dtnv.Rows[0]["TenNhanVien"].ToString();
                }
                else
                {
                    txttennhanvien.Clear(); 
                }

                cbomakhach.SelectedValue = dtHDBan.Rows[0]["MaKhach"].ToString(); 
                string maKhach = dtHDBan.Rows[0]["MaKhach"].ToString();
                DataTable dtKhach = dtBase.ReadData($"SELECT * FROM tblKhach WHERE MaKhach = '{maKhach}'");
                if (dtKhach.Rows.Count > 0)
                {
                    txttenkhach.Text = dtKhach.Rows[0]["TenKhach"].ToString();
                    txtdiachi.Text = dtKhach.Rows[0]["DiaChi"].ToString();
                    txtsdt.Text = dtKhach.Rows[0]["SoDienThoai"].ToString();
                }
                else
                {
                    txttenkhach.Clear();
                    txtdiachi.Clear();
                    txtsdt.Clear();
                }

                DataTable dtChiTiet = dtBase.ReadData(
                    "SELECT tblChiTietHDBan.MaHang, TenHang, DonGiaBan, tblChiTietHDBan.SoLuong, GiamGia, ThanhTien " +
                    "FROM tblChiTietHDBan INNER JOIN tblHang ON tblChiTietHDBan.MaHang = tblHang.MaHang " +
                    $"WHERE MaHDBan = '{cboHoaDon.Text}'"
                );

                dgvchitiet.DataSource = dtChiTiet; 
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn với mã: " + cboHoaDon.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtmahoadon.Clear();
                dtpngayban.Value = DateTime.Now;
                lbltongtien.Text = "Tổng tiền:";
                txtmanhanvien.Clear();
                txttennhanvien.Clear();
                cbomakhach.SelectedIndex = -1;
                txttenkhach.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
                dgvchitiet.DataSource = null;
            }
        }



        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtsdt.Text;

            if (sdt.Length == 10)
            {
                DataTable dtKhach = dtBase.ReadData($"SELECT * FROM tblKhach WHERE SoDienThoai = '{sdt}'");

                if (dtKhach.Rows.Count > 0)
                {
                    txttenkhach.Text = dtKhach.Rows[0]["TenKhach"].ToString();
                    cbomakhach.Text = dtKhach.Rows[0]["MaKhach"].ToString();
                    txtdiachi.Text = dtKhach.Rows[0]["DiaChi"].ToString();
                }
                else
                {
                    Common cmn = new Common();
                    string maKhachMoi = cmn.AutoSingKey("tblKhach", "MaKhach", "KH_"); // Thay đổi "KH_" theo mã định dạng bạn muốn

                    txttenkhach.Clear(); 
                    cbomakhach.Text = maKhachMoi;
                    txtdiachi.Clear();

                    MessageBox.Show("Khách hàng chưa tồn tại. Mã khách hàng mới đã được tạo: " + maKhachMoi, "Thông báo", MessageBoxButtons.OK);
                }
            }
        }


        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetStutusProduct();
            cbomahang.Text = "";

            if (cbomahang.SelectedValue == null)
            {
                txttenhang.Clear();
                txtdongia.Clear();
                txtsoluong.Clear();
                txtthanhtien.Clear();
                txtgiamgia.Clear();
                return;
            }

            string maHang = cbomahang.SelectedValue.ToString();

            DataTable dtHang = dtBase.ReadData($"SELECT TenHang, DonGiaBan, SoLuong FROM tblHang WHERE MaHang = '{maHang}'");

            if (dtHang.Rows.Count > 0)
            {
                txttenhang.Text = dtHang.Rows[0]["TenHang"].ToString();
                txtdongia.Text = dtHang.Rows[0]["DonGiaBan"].ToString();
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHD = "HĐB_" + DateTime.Now.ToString("ddMMyyyy") + "0" + new Random().Next(100, 1000).ToString();
            txtmahoadon.Text = maHD;

            txttenkhach.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            txtdongia.Clear();
            txtsoluong.Clear();
            dgvchitiet.DataSource = null;
            txtthanhtien.Clear();
            cbomakhach.SelectedIndex = -1;
            cbomahang.SelectedIndex = -1;
            lbltongtien.Text = "";

            mahd_load();
        }


        private void btnluu_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtmahoadon.Text;

            try
            {
                string sqlHoaDon = $"INSERT INTO tblHDBan (MaHDBan, MaNhanVien, MaKhach, NgayBan, TongTien) " +
                                   $"VALUES ('{maHoaDon}', '{txtmanhanvien.Text}', '{cbomakhach.Text}', '{DateTime.Now}', '{lbltongtien.Text.Replace("Tổng tiền: ", "").Trim()}')";

                dtBase.ChangeData(sqlHoaDon);

                foreach (DataGridViewRow row in dgvchitiet.Rows)
                {
                    if (row.IsNewRow) continue;

                    string maHang = row.Cells["Mã Hàng"].Value?.ToString() ?? "N/A";
                    string tenHang = row.Cells["Tên Hàng"].Value?.ToString() ?? "N/A";
                    int soLuong = Convert.ToInt32(row.Cells["Số Lượng"].Value ?? 0);
                    decimal donGia = Convert.ToDecimal(row.Cells["Đơn Giá"].Value ?? 0);
                    decimal giamGia = Convert.ToDecimal(row.Cells["Giảm Giá"].Value ?? 0);
                    decimal thanhTien = Convert.ToDecimal(row.Cells["Thành Tiền"].Value ?? 0);

                    DataTable dtHang = dtBase.ReadData($"SELECT SoLuong FROM tblHang WHERE MaHang = '{maHang}'");
                    if (dtHang.Rows.Count == 0)
                    {
                        MessageBox.Show($"Không tìm thấy hàng hóa {maHang}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int soLuongHienCo = int.Parse(dtHang.Rows[0]["SoLuong"].ToString());
                    if (soLuong > soLuongHienCo)
                    {
                        MessageBox.Show($"Không đủ số lượng hàng {maHang} trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sqlChiTiet = $"INSERT INTO tblChiTietHDBan (MaHDBan, MaHang, SoLuong, GiamGia, ThanhTien) " +
                                $"VALUES ('{maHoaDon}', '{maHang}', {soLuong}, {giamGia}, {thanhTien})";

                    dtBase.ChangeData(sqlChiTiet);

                    string sqlCapNhatKho = $"UPDATE tblHang SET SoLuong = SoLuong - {soLuong} WHERE MaHang = '{maHang}'";
                    dtBase.ChangeData(sqlCapNhatKho);
                }

                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);
                btnThem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void dgvchitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvchitiet.Rows.RemoveAt(e.RowIndex);
                UpdateTotalAmount();
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maHoaDon = txtmahoadon.Text;

                if (string.IsNullOrWhiteSpace(maHoaDon))
                {
                    MessageBox.Show("Không có mã hóa đơn để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtChiTiet = dtBase.ReadData($"SELECT MaHang, SoLuong FROM tblChiTietHDBan WHERE MaHDBan = '{maHoaDon}'");

                foreach (DataRow row in dtChiTiet.Rows)
                {
                    string maHang = row["MaHang"].ToString();
                    int soLuong = int.Parse(row["SoLuong"].ToString());

                    string sqlCapNhatKho = $"UPDATE tblHang SET SoLuong = SoLuong + {soLuong} WHERE MaHang = '{maHang}'";
                    dtBase.ChangeData(sqlCapNhatKho);
                }

                string sqlXoaChiTiet = $"DELETE FROM tblChiTietHDBan WHERE MaHDBan = '{maHoaDon}'";
                dtBase.ChangeData(sqlXoaChiTiet);

                string sqlXoaHoaDon = $"DELETE FROM tblHDBan WHERE MaHDBan = '{maHoaDon}'";
                dtBase.ChangeData(sqlXoaHoaDon);


                txtmahoadon.Clear();
                txttenkhach.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
                txtdongia.Clear();
                txtsoluong.Clear();
                txtgiamgia.Clear();
                txtthanhtien.Clear();

                dgvchitiet.DataSource = null;

                lbltongtien.Text = "Tổng tiền: 0.00";

                cboHoaDon.SelectedIndex = -1;
                cbomakhach.SelectedIndex = -1;
                cbomahang.SelectedIndex = -1;

                mahd_load();

                MessageBox.Show("Hủy hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;

            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

            // Tiêu đề cột
            worksheet.Cells[1, 1] = "Mã Hóa Đơn";
            worksheet.Cells[1, 2] = "Mã Hàng";
            worksheet.Cells[1, 3] = "Tên Hàng";
            worksheet.Cells[1, 4] = "Số Lượng";
            worksheet.Cells[1, 5] = "Đơn Giá";
            worksheet.Cells[1, 6] = "Giảm Giá";
            worksheet.Cells[1, 7] = "Thành Tiền";

            worksheet.Cells[2, 1] = txtmahoadon.Text;

            int rowIndex = 2;
            foreach (DataGridViewRow row in dgvchitiet.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng mới

                // Lấy giá trị từ DataGridView
                string maHang = row.Cells["MaHang"].Value?.ToString() ?? "N/A";
                string tenHang = row.Cells["TenHang"].Value?.ToString() ?? "N/A";
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 0);
                decimal donGia = Convert.ToDecimal(row.Cells["DonGiaBan"].Value ?? 0);
                decimal giamGia = Convert.ToDecimal(row.Cells["GiamGia"].Value ?? 0);
                decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value ?? 0);

                // Ghi dữ liệu vào worksheet
                worksheet.Cells[rowIndex, 2] = maHang;
                worksheet.Cells[rowIndex, 3] = tenHang;
                worksheet.Cells[rowIndex, 4] = soLuong;
                worksheet.Cells[rowIndex, 5] = donGia;
                worksheet.Cells[rowIndex, 6] = giamGia;
                worksheet.Cells[rowIndex, 7] = thanhTien;

                rowIndex++; // Tăng chỉ số hàng
            }

            // Thêm tổng tiền
            //worksheet.Cells[rowIndex + 1, 6] = "Tổng Tiền"; // Cột cho Tổng Tiền
            worksheet.Cells[rowIndex + 1, 7] = lbltongtien.Text; // Lấy tổng tiền từ nhãn

            // Hiển thị hộp thoại lưu file
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu Hóa Đơn",
                FileName = $"HoaDon_{txtmahoadon.Text}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu workbook vào file
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("In hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);
            }

            // Dọn dẹp
            workbook.Close();
            excelApp.Quit();

            // Giải phóng các đối tượng COM
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btnthemkhach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttenkhach.Text) ||
                string.IsNullOrWhiteSpace(txtdiachi.Text) ||
                string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtKhach = dtBase.ReadData($"SELECT * FROM tblKhach WHERE SoDienThoai = '{txtsdt.Text}'");
            if (dtKhach.Rows.Count > 0)
            {
                MessageBox.Show("Khách hàng với số điện thoại này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"INSERT INTO tblKhach (MaKhach, TenKhach, DiaChi, SoDienThoai) " +
                         $"VALUES ('{cbomakhach.Text}', N'{txttenkhach.Text}', N'{txtdiachi.Text}', '{txtsdt.Text}')";

            try
            {
                dtBase.ChangeData(sql); 
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbomakhach.Text="";
                txttenkhach.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
                dgvchitiet.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();

        }

        private void cbomakhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbomakhach.SelectedValue != null)
            {
                string maKhach = cbomakhach.SelectedValue.ToString();
                DataTable dtKhach = dtBase.ReadData($"SELECT TenKhach, SoDienThoai, DiaChi FROM tblKhach WHERE MaKhach = '{maKhach}'");

                if (dtKhach.Rows.Count > 0)
                {
                    txttenkhach.Text = dtKhach.Rows[0]["TenKhach"].ToString();
                    txtsdt.Text = dtKhach.Rows[0]["SoDienThoai"].ToString();
                    txtdiachi.Text = dtKhach.Rows[0]["DiaChi"].ToString();
                }
            }
        }
        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvchitiet.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["Thành tiền"].Value);
            }
            lbltongtien.Text = $"Tổng tiền: {totalAmount:F2}"; 
        }


        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            CheckAndCalculate();
        }

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            CheckAndCalculate();
        }

        private void CheckAndCalculate()
        {
            if (!string.IsNullOrEmpty(txtsoluong.Text) && !string.IsNullOrEmpty(txtgiamgia.Text) &&
                int.TryParse(txtsoluong.Text, out int soLuong) && soLuong > 0 &&
                int.TryParse(txtgiamgia.Text, out int giamGia) && giamGia >= 0 && giamGia <= 100)
            {
                string selectedMaHang = cbomahang.SelectedValue?.ToString(); // Lấy mã hàng từ ComboBox

                DataTable dtHang = dtBase.ReadData($"SELECT TenHang, DonGiaBan, SoLuong FROM tblHang WHERE MaHang = '{selectedMaHang}'");

                txttenhang.Text = dtHang.Rows[0]["TenHang"].ToString();
                txtdongia.Text = dtHang.Rows[0]["DonGiaBan"].ToString();

                int soLuongHienCo = int.Parse(dtHang.Rows[0]["SoLuong"].ToString());

                if (soLuong > soLuongHienCo)
                {
                    MessageBox.Show($"Số lượng hàng '{txttenhang.Text}' trong kho không đủ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CalculateThanhTien();
                AddToDataGridView();
            }
        }


        private void CalculateThanhTien()
        {
            if (cbomahang.SelectedItem == null) return;

            string selectedMaHang = cbomahang.SelectedItem.ToString();

            if (int.TryParse(txtsoluong.Text, out int soLuong) &&
                decimal.TryParse(txtdongia.Text, out decimal donGia) &&
                int.TryParse(txtgiamgia.Text, out int giamGia))
            {
                decimal thanhTien = donGia * soLuong * (1 - (giamGia / 100.0M));
                txtthanhtien.Text = thanhTien.ToString("N2");
            }
        }

        private void AddToDataGridView()
        {
            if (cbomahang.SelectedItem == null) return;

            string maHang = cbomahang.SelectedValue.ToString();

            DataTable dtDataGridView;
            if (dgvchitiet.DataSource == null)
            {
                dtDataGridView = new DataTable();
                dtDataGridView.Columns.Add("Mã hàng", typeof(string));
                dtDataGridView.Columns.Add("Tên hàng", typeof(string));
                dtDataGridView.Columns.Add("Số lượng", typeof(int));
                dtDataGridView.Columns.Add("Đơn giá", typeof(decimal));
                dtDataGridView.Columns.Add("Giảm giá", typeof(int));
                dtDataGridView.Columns.Add("Thành tiền", typeof(decimal));
            }
            else
            {
                dtDataGridView = (DataTable)dgvchitiet.DataSource;
            }

            if (!int.TryParse(txtsoluong.Text, out int soLuong) ||
                !int.TryParse(txtgiamgia.Text, out int giamGia) ||
                !decimal.TryParse(txtthanhtien.Text, out decimal thanhTien))
            {
                MessageBox.Show("Vui lòng nhập số lượng, giảm giá và thành tiền hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow existingRow = dtDataGridView.Select($"[Mã hàng] = '{maHang}'").FirstOrDefault();
            if (existingRow != null)
            {
                existingRow["Số lượng"] = soLuong;
                existingRow["Giảm giá"] = giamGia;
                existingRow["Thành tiền"] = thanhTien;
            }
            else
            {
                DataRow newRow = dtDataGridView.NewRow();
                newRow["Mã hàng"] = maHang;
                newRow["Tên hàng"] = txttenhang.Text;
                newRow["Số lượng"] = soLuong;
                newRow["Đơn giá"] = decimal.Parse(txtdongia.Text);
                newRow["Giảm giá"] = giamGia;
                newRow["Thành tiền"] = thanhTien;
                dtDataGridView.Rows.Add(newRow);
            }

            dgvchitiet.DataSource = dtDataGridView;
            UpdateTotalAmount();
        }

    }
}
