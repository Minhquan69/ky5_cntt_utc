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

namespace KTRACK
{
    public partial class Form1 : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        string imageName = "";
        public Form1()
        {
            InitializeComponent();
            LoadMaterialComboBox();
            loadData();
        }
        private void LoadMaterialComboBox()
        {
            txtPhongBan.Items.Clear();
            txtPhongBan.Items.Add("Kế Toán");
            txtPhongBan.Items.Add("Thu Ngân");
            txtPhongBan.Items.Add("Bảo Vệ");
            if (txtPhongBan.Items.Count > 0)
            {
                txtPhongBan.SelectedIndex = -1;
            }
        }
        private void loadData()
        {
            DataTable dtNV = dtBase.ReadData("SELECT *  FROM NhanVien ");
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
            txtPhongBan.SelectedIndex = -1;
            btnThem.Enabled = true;
            txtMa.Enabled = true;
            ptbanh.Image = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có muốn thoát Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
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

        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdata.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaNV"].Value.ToString();
                txtTen.Text = row.Cells["TenNV"].Value.ToString();
                txtSDT.Text = row.Cells["SoDT"].Value.ToString();
                txtLuong.Text = row.Cells["MucLuong"].Value.ToString();
                txtPhongBan.Text = row.Cells["PhongBan"].Value.ToString();
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh.Equals("Nam"))
                    radioButtonNam.Checked = true;
                else
                    radioButtonNu.Checked = true;
                imageName = row.Cells["Anh"].Value?.ToString();
                if (imageName != "")
                    ptbanh.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + imageName);
                else ptbanh.Image = null;
                //
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                txtMa.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NV.");
                txtMa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên NV.");
                txtTen.Focus();
                return;
            }
            if (!radioButtonNam.Checked && !radioButtonNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.");
                return;
            }
            if (string.IsNullOrEmpty(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Mức lương.");
                txtLuong.Focus();
                return;
            }

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["MaNV"].Value != null && row.Cells["MaNV"].Value.ToString() == txtMa.Text)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                    txtMa.Focus();
                    return;
                }
            }
            string maNV = txtMa.Text;
            string tenNV = txtTen.Text;
            string soDT = txtSDT.Text;
            string gioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ";
            string phongban = txtPhongBan.SelectedItem?.ToString().Trim() ?? txtPhongBan.Text.Trim();
            decimal mucLuong = Convert.ToDecimal(txtLuong.Text);
            string sql = $"INSERT INTO NhanVien (MaNV, TenNV, SoDT, GioiTinh, PhongBan,MucLuong,Anh) " +
                           $"VALUES (N'{maNV}', N'{tenNV}', N'{soDT}', N'{gioiTinh}', N'{phongban}', {mucLuong}, N'{imageName}')";
            try
            {
                
                dtBase.ChangeData(sql);
                loadData();
                ResetValue();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
