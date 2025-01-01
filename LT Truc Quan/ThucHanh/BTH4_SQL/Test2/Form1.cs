using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class Frmmain : Form
    {
        Test2.DataBaseProcess dtbase = new Test2.DataBaseProcess();
        public Frmmain()
        {
            
            InitializeComponent();
        }

        private void txtdongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void HienChiTiet(bool hien)
        {
            txtmsp2.Enabled = hien;
            txttensp2.Enabled = hien;
            dtpngayhh.Enabled = hien;
            dtpngaysx.Enabled = hien;
            txtdonvi.Enabled = hien;
            txtdongia.Enabled = hien;
            txtghichu.Enabled = hien;
            //Ẩn hiện 2 nút Lưu và Hủy
            btnluu.Enabled = hien;
            btnhuy.Enabled = hien;
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            //Load dữ liệu lên DataGridView
            dgvKetQua.DataSource = dtbase.DataReader("Select * from tblMatHang");
            //Ẩn nút Sửa,xóa      
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            //Ẩn groupBox chi tiết
            HienChiTiet(false);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Cập nhật trên nhãn tiêu đề
            lbtieude.Text = "TÌM KIẾM MẶT HÀNG";
            //Cấm nút Sửa và Xóa
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            //Viet cau lenh SQL cho tim kiem 
            string sql = "SELECT * FROM tblMatHang where MaSP is not null ";
            //Tim theo MaSP khac rong
            if (txtmsp1.Text.Trim() != "")
            {
                sql += " and MaSP like '%" + txtmsp1.Text + "%'";
            }
            //kiem tra TenSP 
            if (txttensp1.Text.Trim() != "")
            {
                sql += " AND TenSP like N'%" + txttensp1.Text + "%'";
            }
            //Load dữ liệu tìm được lên dataGridView
            dgvKetQua.DataSource = dtbase.DataReader(sql);
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnthem.Enabled = false;
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                txtmsp2.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
                txttensp2.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
                dtpngaysx.Value = (DateTime)dgvKetQua.CurrentRow.Cells[2].Value;
                dtpngayhh.Value = (DateTime)dgvKetQua.CurrentRow.Cells[3].Value;
                txtdonvi.Text = dgvKetQua.CurrentRow.Cells[4].Value.ToString();
                txtdongia.Text = dgvKetQua.CurrentRow.Cells[5].Value.ToString();
                txtghichu.Text = dgvKetQua.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }
        private void XoaTrangChiTiet()
        {
            txtmsp2.Text = "";
            txttensp2.Text = "";
            dtpngaysx.Value = DateTime.Today;
            dtpngayhh.Value = DateTime.Today;
            txtdonvi.Text = "";
            txtdongia.Text = "";
            txtghichu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lbtieude.Text = "THÊM MẶT HÀNG";
            //Xoa trang GroupBox chi tiết sản phẩm
            XoaTrangChiTiet();
            //Cam nut sua xoa
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            //Hiện GroupBox Chi tiết
            HienChiTiet(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Cập nhật tiêu đề
            lbtieude.Text = "CẬP NHẬT MẶT HÀNG";
            //Ẩn hai nút Thêm và Xóa
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            //Hiện gropbox chi tiết
            HienChiTiet(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Bật Message Box cảnh báo người sử dụng
            if (MessageBox.Show("Bạn  có  chắc  chắn  xóa  mã  mặt  hàng  " + txtmsp2.Text + " không ? Nếu  có  ấn  nút  Lưu, không  thì  ấn  nút  Hủy", "Xóa  sản  phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lbtieude.Text = "XÓA MẶT HÀNG";
                btnthem.Enabled = false;
                btnsua.Enabled = false;
                //Hiện gropbox chi tiết
                HienChiTiet(true);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            //Chúng ta sử dụng control ErrorProvider để hiển thị lỗi
            //Kiểm tra tên sản phầm có bị để trống không
            if (txttensp2.Text.Trim() == "")
            {
                errChiTiet.SetError(txttensp2, "Bạn không để trống tên sản phẩm!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Kiểm  tra  ngày  sản  xuất,  lỗi  nếu  người  sử  dụng  nhập  vào  ngày  sản  xuất  lớn  hơn ngày hiện tại
            if (dtpngaysx.Value > DateTime.Now)
            {
                errChiTiet.SetError(dtpngaysx, "Ngày sản xuất không hợp lệ!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Kiểm tra ngày hết hạn xem có lớn hơn ngày sản xuất không
            if (dtpngayhh.Value < dtpngaysx.Value)
            {
                errChiTiet.SetError(dtpngayhh, "Ngay  hết  hạn  nhỏ  hơn  ngày  sản  xuất!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Kiểm  tra   đơn vị  xem có  để trống  không  
            if (txtdonvi.Text.Trim() == "")
            {
                errChiTiet.SetError(txtdonvi, "Bạn  không  để  trống  đơn  vi!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Kiểm  tra  đơn  giá  
            if (txtdongia.Text.Trim() == "")
            {
                errChiTiet.SetError(txtdongia, "Bạn  không  để  trống  đơn  giá!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Nếu  nút Thêm  enable  thì  thực  hiện thêm  mới  
            //Dùng  ký  tự  N'  trước mỗi giá  trị kiểu  text để  insert giá  trị có  dấu tiếng  việt vào  CSDL được  đúng 
            if (btnthem.Enabled == true)
            {  //Kiểm  tra  xem  ô  nhập  MaSP  có  bị  trống  không  if
                if (txtmsp2.Text.Trim() == "")
                {
                    errChiTiet.SetError(txtmsp2, "Bạn  không  để  trống  mã  sản phẩm  trường  này!");
                    return;
                }
                else
                {  //Kiểm  tra  xem  mã  sản  phẩm  đã  tồn  tại  chưa  đẻ  tránh việc  insert  mới  bị  lỗi  
                    sql = "Select  *  From  tblMatHang  Where  MaSP  ='" + txtmsp2.Text + "'";
                    DataTable dtSP = dtbase.DataReader(sql);
                    if (dtSP.Rows.Count > 0)
                    {
                        errChiTiet.SetError(txtmsp2, "Mã sản phẩm trùng trong cơ sở dữ liệu");
                        return;
                    }
                    errChiTiet.Clear();
                }
                //Insert vao CSDL
                sql = "INSERT  INTO  tblMatHang(MaSP, TenSP, NgaySX, NgayHH, DonVi, DonGia, GhiChu) VALUES(";
                sql += "N'" + txtmsp1.Text + "',N'" + txttensp1.Text + "','" + string.Format("{0:MM/dd/yyyy}", dtpngaysx) + "','" +
                                string.Format("{0:MM/dd/yyyy}", dtpngayhh) + "',N'" + txtdonvi.Text + "',N'" + txtdongia.Text + "',N'" + txtghichu.Text + "')";
            }
            //Nếu nút Sửa enable thì thực hiện cập nhật dữ liệu
            if (btnsua.Enabled == true)
            {
                sql = "Update tblMatHang SET ";
                sql += "TenSP = N'" + txttensp2.Text + "',";
                sql += "NgaySX = '" + dtpngaysx.Value.Date + "',";
                sql += "NgayHH = '" + dtpngayhh.Value.Date + "',";
                sql += "DonVi = N'" + txtdonvi.Text + "',";
                sql += "DonGia = '" + txtdongia.Text + "',";
                sql += "GhiChu = N'" + txtghichu.Text + "' ";
                sql += "Where MaSP = N'" + txtmsp2.Text + "'";
            }
            //Nếu nút Xóa enable thì thực hiện xóa dữ liệu
            if (btnxoa.Enabled == true)
            {
                sql = "Delete From tblMatHang Where MaSP =N'" + txtmsp2.Text + "'";
            }
            dtbase.DataChange(sql);
            //Cap nhat lai DataGrid
            sql = "Select * from tblMatHang";
            dgvKetQua.DataSource = dtbase.DataReader(sql);
            //Ẩn hiện các nút phù hợp chức năng
            HienChiTiet(false);
            btnsua.Enabled = false;
            btnxoa.Enabled = false;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //Thiết lập lại các nút như ban đầu
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            btnthem.Enabled = true;
            //xoa trang chi tiết
            XoaTrangChiTiet();
            //Cam nhap vào groupBox chi tiết
            HienChiTiet(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "TB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        
    }
}
