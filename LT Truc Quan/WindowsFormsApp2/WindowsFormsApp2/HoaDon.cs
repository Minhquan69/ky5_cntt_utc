using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace WindowsFormsApp2
{
    public partial class HoaDon : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        string maNv = "";
        private Timer timerCheck;
        private string previousSDT = "";
        double thanhTien;
        private string maHangSelected = "";
        public HoaDon(string MaNV)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            maNv = MaNV;
            //tu dong tk va tao Kh theo SDT
            timerCheck = new Timer();
            timerCheck.Interval = 5000; // 10 giây
            timerCheck.Tick += TimerCheck_Tick;
            // Gắn sự kiện TextChanged cho tbSDT
            tbSDT.TextChanged += TbSDT_TextChanged;
        }
        private void TbSDT_TextChanged(object sender, EventArgs e)
        {
            timerCheck.Stop();
            timerCheck.Start();
            previousSDT = tbSDT.Text;
        }

        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            // Dừng Timer sau khi chạy
            timerCheck.Stop();

            // Kiểm tra nếu số điện thoại hiện tại không thay đổi và không trống
            if (tbSDT.Text == previousSDT && !string.IsNullOrEmpty(previousSDT))
            {
                // Thực hiện tìm kiếm thông tin khách hàng
                string sdt = tbSDT.Text;
                DataTable dtKH = dtBase.ReadData($"SELECT MaKhach, TenKhach, DiaChi, SoDienThoai FROM tblKhach WHERE SoDienThoai = '{sdt}'");

                // Kiểm tra nếu tìm thấy khách hàng trong cơ sở dữ liệu
                if (dtKH != null && dtKH.Rows.Count > 0)
                {
                    cbMaKH.SelectedIndex = -1;
                    tbTenKH.Text = dtKH.Rows[0]["TenKhach"].ToString();
                    tbDiaChi.Text = dtKH.Rows[0]["DiaChi"].ToString();
                    cbMaKH.SelectedItem = dtKH.Rows[0]["MaKhach"].ToString();
                }
                else if (string.IsNullOrEmpty(tbTenKH.Text) && string.IsNullOrEmpty(tbDiaChi.Text)) // Chỉ tạo mã mới khi chưa có thông tin khách hàng
                {
                    // Tạo mã khách hàng mới và thêm vào ComboBox nếu chưa tìm thấy
                    string newCustomerId = GenerateUniqueCustomerCode();
                    tbDiaChi.Clear();
                    tbTenKH.Clear();
                    cbMaKH.Items.Add(newCustomerId);
                    cbMaKH.SelectedItem = newCustomerId;
                }
            }
        }
        private string GenerateUniqueCustomerCode()
        {
            string maKhachHang;
            bool exists;
            Random rand = new Random();
            do
            {
                maKhachHang = "KH" + rand.Next(1, 1000);

                DataTable dtExists = dtBase.ReadData($"SELECT COUNT(*) FROM tblKhach WHERE MaKhach = '{maKhachHang}'");
                exists = dtExists.Rows[0][0].ToString() != "0";
            } while (exists);

            return maKhachHang;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            loadMaHD();
            loadMaNhanVien();
            loadMaKH();
            loadMaHang();
            loadNhanVien();
        }

        //end tk sdt
        void loadMaHD()
        {
            try
            {
                DataTable dtMaHD = dtBase.ReadData(@"
                SELECT MaHDBan 
                FROM tblHDBan 
                WHERE NgayBan >= DATEADD(DAY, -7, GETDATE())");

                cbMaHD.Items.Clear();
                foreach (DataRow row in dtMaHD.Rows)
                {
                    cbMaHD.Items.Add(row["MaHDBan"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu mã hóa đơn: " + ex.Message);
            }
        }
        void loadMaNhanVien()
        {
            DataTable dtNhanVien = dtBase.ReadData("SELECT MaNhanVien FROM tblNhanVien");
            cbMaNV.Items.Clear();
            foreach (DataRow row in dtNhanVien.Rows)
            {
                cbMaNV.Items.Add(row["MaNhanVien"].ToString());
            }
        }
        void loadMaKH()
        {
            DataTable dtMaHD = dtBase.ReadData("SELECT MaKhach FROM tblKhach");
            cbMaKH.Items.Clear();
            foreach (DataRow row in dtMaHD.Rows)
            {
                cbMaKH.Items.Add(row["MaKhach"].ToString());
            }
        }
        void loadMaHang()
        {
            DataTable dtMaHang = dtBase.ReadData("SELECT MaHang FROM tblHang");
            cbMaHang.Items.Clear();
            foreach (DataRow row in dtMaHang.Rows)
            {
                cbMaHang.Items.Add(row["MaHang"].ToString());
            }
        }
        void loadNhanVien()
        {
            DataTable dtNhanVien = dtBase.ReadData($"SELECT TenNhanVien FROM tblNhanVien WHERE MaNhanVien = '{maNv}'");

            if (dtNhanVien.Rows.Count > 0)
            {
                if (!cbMaNV.Items.Contains(maNv))
                {
                    cbMaNV.Items.Add(maNv);
                }

                cbMaNV.SelectedItem = maNv;
                tbTenNV.Text = dtNhanVien.Rows[0]["TenNhanVien"].ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnThemHD.Enabled = true;
            resetStutusProduct();
            string selectedMaNV = cbMaHD.SelectedItem.ToString();


            DataTable dtChiTietHDB = dtBase.ReadData($"SELECT MaHDBan, NgayBan, tblNhanVien.MaNhanVien, TenNhanVien, TenKhach, tblKhach.MaKhach, SoDienThoai, DiaChi " +
                $"FROM tblHDBan JOIN tblNhanVien ON tblHDBan.MaNhanVien = tblNhanVien.MaNhanVien " +
                $"JOIN tblKhach ON tblHDBan.MaKhach = tblKhach.MaKhach " +
                $"WHERE tblHDBan.MaHDBan = '{selectedMaNV}'");


            tbMaHD.Text = dtChiTietHDB.Rows[0]["MaHDBan"].ToString();
            tbNgayBan.Text = dtChiTietHDB.Rows[0]["NgayBan"].ToString();
            cbMaNV.SelectedItem = dtChiTietHDB.Rows[0]["MaNhanVien"].ToString();
            cbMaKH.SelectedItem = dtChiTietHDB.Rows[0]["MaKhach"].ToString();
            tbTenKH.Text = dtChiTietHDB.Rows[0]["TenKhach"].ToString();
            tbSDT.Text = dtChiTietHDB.Rows[0]["SoDienThoai"].ToString();
            tbDiaChi.Text = dtChiTietHDB.Rows[0]["DiaChi"].ToString();


            DataTable dtChiTietHang = dtBase.ReadData($"SELECT tblChiTietHDBan.MaHang, tblHang.TenHang, tblChiTietHDBan.SoLuong, tblHang.DonGiaBan, tblChiTietHDBan.GiamGia, tblChiTietHDBan.ThanhTien " +
                $"FROM tblChiTietHDBan JOIN tblHang ON tblChiTietHDBan.MaHang = tblHang.MaHang " +
                $"WHERE tblChiTietHDBan.MaHDBan = '{selectedMaNV}'");

            dataMH.DataSource = dtChiTietHang;
            dataMH.Columns[0].HeaderText = "Mã hàng";
            dataMH.Columns[1].HeaderText = "Tên hàng";
            dataMH.Columns[2].HeaderText = "Số lượng";
            dataMH.Columns[3].HeaderText = "Đơn giá ";
            dataMH.Columns[4].HeaderText = "Giảm giá";
            dataMH.Columns[5].HeaderText = "Thành tiền";

            // Tính tổng tiền
            DataTable dtTongTien = dtBase.ReadData($"SELECT SUM(CAST(tblChiTietHDBan.ThanhTien AS DECIMAL(18, 2))) AS tongtien " +
                $"FROM tblChiTietHDBan " +
                $"WHERE tblChiTietHDBan.MaHDBan = '{selectedMaNV}';");
            tbTotal.Text = dtTongTien.Rows[0]["tongtien"].ToString();

            dataMH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataMH.ColumnHeadersVisible = true;
        }
        private void resetStutusProduct()
        {

            tbTenHang.Clear();
            tbDonGia.Clear();
            tbSoLuong.Clear();
            tbGiamGia.Clear();
            tbThanhTien.Clear();
            tbTenHang.Clear();
            btnLuuHD.Enabled = false;
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSoLuong.Text = "1";
            tbGiamGia.Text = "0";
            if (btnLuuHD.Enabled  && btnThemHD.Enabled == false)
            {

                string selectedMaHang = cbMaHang.SelectedItem.ToString();
                DataTable dtHang = dtBase.ReadData($"SELECT TenHang, DonGiaBan, SoLuong FROM tblHang WHERE MaHang = '{selectedMaHang}'");

                // Cập nhật thông tin hàng hóa vào TextBox
                tbTenHang.Text = dtHang.Rows[0]["TenHang"].ToString();
                tbDonGia.Text = dtHang.Rows[0]["DonGiaBan"].ToString();

                UpdatePriceAndGrid();

            }
        }
        private void UpdatePriceAndGrid()
        {
            if (string.IsNullOrEmpty(cbMaHang.SelectedItem?.ToString())) return;

            string selectedMaHang = cbMaHang.SelectedItem.ToString();
            DataTable dtHang = dtBase.ReadData($"SELECT TenHang, DonGiaBan FROM tblHang WHERE MaHang = '{selectedMaHang}'");

            if (dtHang.Rows.Count == 0) return;

            tbTenHang.Text = dtHang.Rows[0]["TenHang"].ToString();
            tbDonGia.Text = dtHang.Rows[0]["DonGiaBan"].ToString();

            // Kiểm tra giá trị hợp lệ
            if (!int.TryParse(tbSoLuong.Text, out int soLuong) || soLuong <= 0)
            {

                return;
            }

            if (!int.TryParse(tbGiamGia.Text, out int giamGia) || giamGia < 0 || giamGia > 100)
            {

                return;
            }

            int donGiaBan = int.Parse(dtHang.Rows[0]["DonGiaBan"].ToString());
            thanhTien = (donGiaBan * soLuong) - ((giamGia / 100.0) * (donGiaBan * soLuong));
            tbThanhTien.Text = thanhTien.ToString("F2");

            // Nếu DataSource của DataGridView là null, tạo mới DataTable
            DataTable dtDataGridView;
            if (dataMH.DataSource == null)
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
                dtDataGridView = (DataTable)dataMH.DataSource; // Lấy DataTable hiện tại
            }

            // Kiểm tra xem dòng có tồn tại trong DataTable không
            DataRow existingRow = dtDataGridView.Select($"[Mã hàng] = '{selectedMaHang}'").FirstOrDefault();
            if (existingRow != null)
            {
                // Cập nhật dòng hiện tại
                existingRow["Số lượng"] = soLuong;
                existingRow["Giảm giá"] = giamGia;
                existingRow["Thành tiền"] = thanhTien;
            }
            else
            {
                // Thêm dòng mới nếu chưa tồn tại
                DataRow newRow = dtDataGridView.NewRow();
                newRow["Mã hàng"] = selectedMaHang;
                newRow["Tên hàng"] = tbTenHang.Text;
                newRow["Số lượng"] = soLuong;
                newRow["Đơn giá"] = donGiaBan;
                newRow["Giảm giá"] = giamGia;
                newRow["Thành tiền"] = thanhTien;
                dtDataGridView.Rows.Add(newRow);
            }

            // Cập nhật DataSource cho DataGridView
            dataMH.DataSource = dtDataGridView;

            // Cập nhật tiêu đề cột cho DataGridView
            dataMH.Columns[0].HeaderText = "Mã hàng";
            dataMH.Columns[1].HeaderText = "Tên hàng";
            dataMH.Columns[2].HeaderText = "Số lượng";
            dataMH.Columns[3].HeaderText = "Đơn giá ";
            dataMH.Columns[4].HeaderText = "Giảm giá";
            dataMH.Columns[5].HeaderText = "Thành tiền";

            UpdateTotal();
        }
        private void UpdateTotal()
        {
            double total = 0;

            if (dataMH.DataSource != null)
            {
                DataTable dtDataGridView = (DataTable)dataMH.DataSource;
                foreach (DataRow row in dtDataGridView.Rows)
                {
                    if (double.TryParse(row["Thành tiền"].ToString(), out double thanhTien))
                    {
                        total += thanhTien;
                    }
                }
            }

            tbTotal.Text = total.ToString("F2");
        }

        private void tbSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (btnLuuHD.Enabled) UpdatePriceAndGrid();
        }

        private void tbGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (btnLuuHD.Enabled) UpdatePriceAndGrid();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            resetForm();
            cbMaHD.SelectedIndex = -1;
            btnLuuHD.Enabled = true;
            btnThemHD.Enabled = false;
            tbMaHD.Text = GenerateInvoiceCode();
        }
        private void resetForm()
        {
            tbMaHD.Text = "";
            tbTotal.Clear();
            tbNgayBan.Text = DateTime.Now.ToString("MM/dd/yyyy");
            loadNhanVien();
            tbTenKH.Text = "";
            tbSDT.Text = "";
            tbDiaChi.Text = "";
            tbMaHD.Text = "";
            dataMH.DataSource = null;

        }
        private string GenerateInvoiceCode()
        {
            DateTime today = DateTime.Now;
            string datePart = today.ToString("ddMMyyyy");

            // Sinh số ngẫu nhiên từ 000 đến 999
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);

            // Định dạng số ngẫu nhiên thành chuỗi có 3 chữ số
            string randomPart = randomNumber.ToString("D3");

            // Tạo mã hóa đơn với định dạng HĐB_ddMMyyyy0xxx
            return $"HĐB_{datePart}0{randomPart}";
        }

        private void dataMH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng e.RowIndex không âm
            {
                // Lấy DataTable từ DataGridView
                DataTable dtDataGridView = (DataTable)dataMH.DataSource;

                // Kiểm tra nếu DataTable không null và có các cột tồn tại
                if (dtDataGridView != null && dtDataGridView.Columns.Contains("Mã hàng") &&
                    dtDataGridView.Columns.Contains("Số lượng") &&
                    dtDataGridView.Columns.Contains("Đơn giá") &&
                    dtDataGridView.Columns.Contains("Giảm giá"))
                {
                    // Lấy mã hàng từ hàng đã chọn
                    string maHang = dtDataGridView.Rows[e.RowIndex]["Mã hàng"].ToString();

                    // Lấy số lượng, đơn giá, giảm giá từ hàng đã chọn
                    int soLuong = Convert.ToInt32(dtDataGridView.Rows[e.RowIndex]["Số lượng"]);
                    decimal donGia = Convert.ToDecimal(dtDataGridView.Rows[e.RowIndex]["Đơn giá"]);
                    int giamGia = Convert.ToInt32(dtDataGridView.Rows[e.RowIndex]["Giảm giá"]);

                    // Tính thành tiền cho hàng bị xóa
                    decimal tien = donGia * soLuong - (donGia * soLuong * giamGia / 100);

                    // Xác nhận người dùng có muốn xóa không
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này không?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Xóa hàng khỏi DataGridView
                        dtDataGridView.Rows.RemoveAt(e.RowIndex);
                        // Cập nhật tổng tiền
                        decimal currentTotal;
                        if (decimal.TryParse(tbTotal.Text, out currentTotal))
                        {
                            tbTotal.Text = (currentTotal - tien).ToString("F2");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Một hoặc nhiều cột không tồn tại trong DataTable.");
                }
            }
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {

            btnLuuHD.Enabled = false;
            btnThemHD.Enabled = true;
            DataTable dtDataGridView = (DataTable)dataMH.DataSource;

            if (dtDataGridView == null || dtDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để lưu.");
                return;
            }

            bool isQuantityValid = true;
            string message = "";

            foreach (DataRow row in dtDataGridView.Rows)
            {
                string maHang = row["Mã hàng"].ToString();
                int soLuongDaBan = Convert.ToInt32(row["Số lượng"]);
                DataTable dtHang = dtBase.ReadData($"SELECT SoLuong FROM tblHang WHERE MaHang = '{maHang}'");

                if (dtHang.Rows.Count > 0)
                {
                    int soLuongTonKho = Convert.ToInt32(dtHang.Rows[0]["SoLuong"]);
                    if (soLuongDaBan > soLuongTonKho)
                    {
                        isQuantityValid = false;
                        message += $"Mặt hàng {maHang} không đủ số lượng. Tồn kho: {soLuongTonKho}, Đặt hàng: {soLuongDaBan}\n";
                    }
                }
                else
                {
                    message += $"Mặt hàng {maHang} không tồn tại trong kho.\n";
                }
            }

            if (isQuantityValid)
            {
                // Ensure correct date format
                DateTime ngayBan;
                if (!DateTime.TryParse(tbNgayBan.Text, out ngayBan))
                {
                    MessageBox.Show("Ngày bán không hợp lệ.");
                    return;
                }

                // Format the date to match SQL Server's expected format
                string formattedNgayBan = ngayBan.ToString("yyyy-MM-dd");

                // Check if customer exists in tblKhach
                DataTable dtKhach = dtBase.ReadData($"SELECT * FROM tblKhach WHERE MaKhach = '{cbMaKH.Text}'");
                if (dtKhach.Rows.Count == 0)
                {
                    // Insert customer into tblKhach
                    string queryInsertKhach = $"INSERT INTO tblKhach (MaKhach, TenKhach, DiaChi, SoDienThoai) " +
                                               $"VALUES ('{cbMaKH.Text}', '{tbTenKH.Text}', '{tbDiaChi.Text}', '{tbSDT.Text}')";
                    dtBase.ChangeData(queryInsertKhach);
                }

                // Insert order into tblHDBan
                string queryInsertHDBan = $"INSERT INTO tblHDBan (MaHDBan, MaNhanVien, MaKhach, NgayBan, TongTien) " +
                                          $"VALUES ('{tbMaHD.Text}', '{cbMaNV.SelectedItem}', '{cbMaKH.SelectedItem}', '{formattedNgayBan}', {tbTotal.Text})";
                dtBase.ChangeData(queryInsertHDBan);

                // Insert each item in the DataTable into tblChiTietHDBan and update stock
                foreach (DataRow row in dtDataGridView.Rows)
                {
                    string maHang = row["Mã hàng"].ToString();
                    int soLuong = Convert.ToInt32(row["Số lượng"]);
                    int giamGia = Convert.ToInt32(row["Giảm giá"]);
                    decimal thanhTien = Convert.ToDecimal(row["Thành tiền"]);

                    string queryInsertChiTietHDBan = $"INSERT INTO tblChiTietHDBan (MaHDBan, MaHang, SoLuong, GiamGia, ThanhTien) " +
                                                      $"VALUES ('{tbMaHD.Text}', '{maHang}', {soLuong}, {giamGia}, {thanhTien})";
                    dtBase.ChangeData(queryInsertChiTietHDBan);

                    string queryUpdateSoLuong = $"UPDATE tblHang SET SoLuong = SoLuong - {soLuong} WHERE MaHang = '{maHang}'";
                    dtBase.ChangeData(queryUpdateSoLuong);
                }

                MessageBox.Show("Hóa đơn đã được lưu thành công!");
                resetForm();
                loadMaHD();
                loadMaKH();
                resetStutusProduct();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            btnThemHD.Enabled = true;
            if (btnLuuHD.Enabled)
            {
                resetForm();

                resetStutusProduct();
                dataMH.DataSource = null;
                loadMaHD();
            }
            else
            {
                // Nếu hóa đơn đã được lưu, thực hiện xóa hóa đơn và cập nhật lại số lượng hàng trong kho
                string maHDBan = tbMaHD.Text;

                // Lấy thông tin chi tiết các mặt hàng trong hóa đơn để cập nhật lại tồn kho
                DataTable dtChiTietHDBan = dtBase.ReadData($"SELECT MaHang, SoLuong FROM tblChiTietHDBan WHERE MaHDBan = '{maHDBan}'");

                // Cập nhật lại số lượng hàng trong kho
                foreach (DataRow row in dtChiTietHDBan.Rows)
                {
                    string maHang = row["MaHang"].ToString();
                    int soLuong = Convert.ToInt32(row["SoLuong"]);

                    string queryUpdateSoLuong = $"UPDATE tblHang SET SoLuong = SoLuong + {soLuong} WHERE MaHang = '{maHang}'";
                    dtBase.ChangeData(queryUpdateSoLuong);
                }

                // Xóa chi tiết hóa đơn từ tblChiTietHDBan
                string queryDeleteChiTietHDBan = $"DELETE FROM tblChiTietHDBan WHERE MaHDBan = '{maHDBan}'";
                dtBase.ChangeData(queryDeleteChiTietHDBan);

                // Xóa hóa đơn từ tblHDBan
                string queryDeleteHDBan = $"DELETE FROM tblHDBan WHERE MaHDBan = '{maHDBan}'";
                dtBase.ChangeData(queryDeleteHDBan);

                MessageBox.Show("Hóa đơn đã được hủy thành công và tồn kho đã được cập nhật!");


                resetForm();
                resetStutusProduct();
                loadMaHD();
                dataMH.DataSource = null;
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            // Tạo một workbook mới
            using (var workbook = new XLWorkbook())
            {
                // Tạo một worksheet mới
                var worksheet = workbook.Worksheets.Add("HoaDon");

                // Thêm thông tin hóa đơn
                worksheet.Cell("A1").Value = "Mã Hóa Đơn:";
                worksheet.Cell("B1").Value = tbMaHD.Text;

                worksheet.Cell("A2").Value = "Ngày Bán:";
                worksheet.Cell("B2").Value = tbNgayBan.Text;

                worksheet.Cell("A3").Value = "Khách Hàng:";
                worksheet.Cell("B3").Value = tbTenKH.Text;

                worksheet.Cell("A4").Value = "Địa Chỉ:";
                worksheet.Cell("B4").Value = tbDiaChi.Text;

                worksheet.Cell("A5").Value = "Số Điện Thoại:";
                worksheet.Cell("B5").Value = tbSDT.Text;

                worksheet.Cell("A6").Value = "Nhân Viên:";
                worksheet.Cell("B6").Value = cbMaNV.SelectedItem.ToString();

                // Tạo tiêu đề cho bảng chi tiết hóa đơn
                worksheet.Cell("A8").Value = "Mã Hàng";
                worksheet.Cell("B8").Value = "Tên Hàng";
                worksheet.Cell("C8").Value = "Số Lượng";
                worksheet.Cell("D8").Value = "Giảm Giá";
                worksheet.Cell("E8").Value = "Thành Tiền";


                worksheet.Range("A8:E8").Style.Font.Bold = true;

                string selectedMaHDBan = tbMaHD.Text; // Sử dụng mã hóa đơn đã nhập
                DataTable dtChiTietHang = dtBase.ReadData($"SELECT tblChiTietHDBan.MaHang, tblHang.TenHang, tblChiTietHDBan.SoLuong, tblChiTietHDBan.GiamGia, tblChiTietHDBan.ThanhTien " +
                    $"FROM tblChiTietHDBan JOIN tblHang ON tblChiTietHDBan.MaHang = tblHang.MaHang " +
                    $"WHERE tblChiTietHDBan.MaHDBan = '{selectedMaHDBan}'");

                int row = 9;
                foreach (DataRow dataRow in dtChiTietHang.Rows)
                {
                    worksheet.Cell(row, 1).Value = dataRow["MaHang"];
                    worksheet.Cell(row, 2).Value = dataRow["TenHang"];
                    worksheet.Cell(row, 3).Value = dataRow["SoLuong"];
                    worksheet.Cell(row, 4).Value = dataRow["GiamGia"];
                    worksheet.Cell(row, 5).Value = dataRow["ThanhTien"];
                    row++;
                }

                worksheet.Cell($"D{row}").Value = "Tổng Tiền:";
                worksheet.Cell($"E{row}").Value = tbTotal.Text;

                worksheet.Column(5).Style.NumberFormat.Format = "#,##0.00";

                string filePath = Path.Combine(@"D:\C#\Excel", $"HoaDon_{tbMaHD.Text}.xlsx");
                workbook.SaveAs(filePath);


                MessageBox.Show("Hóa đơn đã được xuất ra file Excel thành công!");
            }
        }
    }
}
