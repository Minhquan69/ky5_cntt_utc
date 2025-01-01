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

namespace WindowsFormsApp2
{
    public partial class BTT2_2 : Form
    {
        public BTT2_2()
        {
            InitializeComponent();
            LoadSubjects();
        }
        private void LoadSubjects()
        {
            // Thêm các môn học vào ComboBox
            comboBox1.Items.Add("Tin học đại cương");
            comboBox1.Items.Add("Giải tích F1");
            comboBox1.Items.Add("Tiếng Anh A0");
            comboBox1.Items.Add("Triết học Mác – Lênin");
            comboBox1.Items.Add("Vật lý F1");

            // Khóa TextBox Số tín chỉ để không cho phép nhập
            textBox1.ReadOnly = true;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tự động điền số tín chỉ khi chọn môn học
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Tin học đại cương":
                    textBox1.Text = "2";
                    break;
                case "Giải tích F1":
                case "Tiếng Anh A0":
                case "Vật lý F1":
                    textBox1.Text = "3";
                    break;
                case "Triết học Mác – Lênin":
                    textBox1.Text = "2";
                    break;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra điểm nhập
            if (string.IsNullOrEmpty(txtDiem.Text) || !double.TryParse(txtDiem.Text, out double diem))
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ!");
                return;
            }

            // Thêm môn học vào ListBox
            string monHoc = $"{comboBox1.SelectedItem} - {textBox1.Text} tín chỉ - Điểm: {txtDiem.Text}";
            listBox1.Items.Add(monHoc);
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một môn học.");
                return;
            }

            int tongTinChi = 0;
            double tongDiem = 0;

            foreach (string item in listBox1.Items)
            {
                // Giả định dữ liệu dạng "Tên môn - Số tín chỉ tín chỉ - Điểm: X"
                string[] parts = item.Split('-');
                int tinChi = int.Parse(parts[1].Trim().Split(' ')[0]);
                double diem = double.Parse(parts[2].Trim().Split(':')[1]);

                tongTinChi += tinChi;
                tongDiem += diem * tinChi;
            }

            double diemTrungBinh = tongDiem / tongTinChi;
            txtSotinchi.Text = tongTinChi.ToString();
            txtTongDiem.Text = tongDiem.ToString();
            txtDTB.Text = diemTrungBinh.ToString("0.00");

        }
    }
}
