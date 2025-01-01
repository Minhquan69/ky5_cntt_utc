using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class BTT2_3 : Form
    {
        double giaDoUong = 0;
        int soLuongDoUong = 0;
        int giaDuThuyen = 0;
        List<Tuple<string, string, int, double>> listData = new List<Tuple<string, string, int, double>>();
        public BTT2_3()
        {
            InitializeComponent();
            foreach (var item in doUong)
            {
                cbbDoUong.Items.Add(item.Key);
            }
            for (int i = 0; i < 10; i++)
            {
                cbbSL.Items.Add((i + 1).ToString());
            }
        }
        Dictionary<string, double> doUong = new Dictionary<string, double>
        {
            { "Coca cola", 0.5 },
            { "Pepsi", 0.8 },
            { "Sevenup", 1 }
        };

       

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtTenKH.Text = "";
            txtGia.Text = "";
            txtTien.Text = "";

            txtTenKH.Focus();
            rdoCaNgay.Checked = false;
            rdoNuaNgay.Checked = false;
            cbbDoUong.SelectedIndex = -1;
            cbbSL.SelectedIndex = -1;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        

        private void rdoCaNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCaNgay.Checked)
            {
                txtGia.Clear();
                txtGia.Text = "200";
                giaDuThuyen = 200;
            }

        }

        private void rdoNuaNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNuaNgay.Checked)
            {
                txtGia.Clear();
                txtGia.Text = "100";
                giaDuThuyen = 100;
            }

        }

        private void cbbDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDoUong.SelectedItem != null)
            {
                string tenDoUong = cbbDoUong.SelectedItem.ToString();

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

        private void cbbSL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSL.SelectedItem != null)
            {
                bool isQuantityValid = int.TryParse(cbbSL.SelectedItem.ToString(), out soLuongDoUong);

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
                txtTien.Text = total.ToString();
            }
            else
            {
                txtTien.Text = "0.00$";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtTenKH.Text;
            string doUong = cbbDoUong.SelectedItem != null ? cbbDoUong.SelectedItem.ToString() : "Chưa chọn";
            string soLuong = soLuongDoUong.ToString();
            string giaDuThuyenText = giaDuThuyen.ToString();
            string thoiGianThue = (giaDuThuyen == 200) ? "Ca ngay" : "Nua ngay";
            double tongTien = giaDoUong * soLuongDoUong + giaDuThuyen;

            string item = $"{hoTen} - Drink: {doUong} - Number: {soLuong} - much: {giaDuThuyenText} - Time: {thoiGianThue} - Total: {tongTien:0.00}$";

            lstDanhSach.Items.Add(item);

            listData.Add(new Tuple<string, string, int, double>(hoTen, doUong, soLuongDoUong, tongTien));
        }
    }
}
