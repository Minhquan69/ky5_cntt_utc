using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace form_13_9_2024
{
    public partial class Form1 : Form
    {
        double giaDoUong = 0;
        int soLuongDoUong = 0;
        int giaDuThuyen = 0;

        List<Tuple<string, string, int, double>> listData = new List<Tuple<string, string, int, double>>();

        public Form1()
        {
            InitializeComponent();
            foreach (var item in doUong)
            {
                cbChonDoUong.Items.Add(item.Key);
            }
            for (int i = 0; i < 10; i++)
            {
                cbSoLuong.Items.Add((i + 1).ToString());
            }
        }

        Dictionary<string, double> doUong = new Dictionary<string, double>
        {
            { "Coca cola", 0.5 },
            { "Pepsi", 0.8 },
            { "Sevenup", 1 }
        };

        private void btn_Thoat_Clicked(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            tbHoTen.Text = "";
            tbGiaDuThuyen.Text = "";
            tbTien.Text = "";

            tbHoTen.Focus();
            rbCaNgay.Checked = false;
            rbNuaNgay.Checked = false;
            cbChonDoUong.SelectedIndex = -1;
            cbSoLuong.SelectedIndex = -1;
        }

        private void rdoCaNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCaNgay.Checked)
            {
                tbGiaDuThuyen.Clear();
                tbGiaDuThuyen.Text = "200$";
                giaDuThuyen = 200;
            }
        }

        private void rdoNuaNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNuaNgay.Checked)
            {
                tbGiaDuThuyen.Clear();
                tbGiaDuThuyen.Text = "100$";
                giaDuThuyen = 100;
            }
        }

        private void handle_value_douong_changed(object sender, EventArgs e)
        {
            if (cbChonDoUong.SelectedItem != null)
            {
                string tenDoUong = cbChonDoUong.SelectedItem.ToString();

                if (doUong.ContainsKey(tenDoUong))
                {
                    giaDoUong = doUong[tenDoUong];
                }
                else
                {
                    giaDoUong = 0;
                }
            }
            CalculateTotal();
        }

        private void handle_value_soluong_changed(object sender, EventArgs e)
        {
            if (cbSoLuong.SelectedItem != null)
            {
                bool isQuantityValid = int.TryParse(cbSoLuong.SelectedItem.ToString(), out soLuongDoUong);

                if (!isQuantityValid)
                {
                    soLuongDoUong = 0;
                }
            }
            else
            {
                soLuongDoUong = 0;
            }
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            if (giaDoUong > 0 && soLuongDoUong > 0)
            {
                double total = giaDoUong * soLuongDoUong;
                tbTien.Text = total.ToString() ;
            }
            else
            {
                tbTien.Text = "0.00$";
            }
        }

        private void btnThemVaoDS_Click(object sender, EventArgs e)
        {
            string hoTen = tbHoTen.Text;
            string doUong = cbChonDoUong.SelectedItem != null ? cbChonDoUong.SelectedItem.ToString() : "Chưa chọn";
            string soLuong = soLuongDoUong.ToString();
            string giaDuThuyenText = giaDuThuyen.ToString();
            string thoiGianThue = (giaDuThuyen == 200) ? "Ca ngay" : "Nua ngay";
            double tongTien = giaDoUong * soLuongDoUong + giaDuThuyen;

            string item = $"{hoTen} - Drink: {doUong} - Number: {soLuong} - much: {giaDuThuyenText} - Time: {thoiGianThue} - Total: {tongTien:0.00}$";

            lbDanhSach.Items.Add(item);

            listData.Add(new Tuple<string, string, int, double>(hoTen, doUong, soLuongDoUong, tongTien));
        }
    }
}
