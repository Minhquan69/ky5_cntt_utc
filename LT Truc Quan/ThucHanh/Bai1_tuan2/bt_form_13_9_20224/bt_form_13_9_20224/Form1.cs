using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bt_form_13_9_20224
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var item in monHoc)
            {
                comboBoxNameSub.Items.Add(item.Key);
            }
        }

        Dictionary<string, int> monHoc = new Dictionary<string, int>
        {
            { "Tin học đại cương", 2 },
            { "Giải tích F1", 3 },
            { "Tiếng Anh A0", 3 },
            { "Triết học Mác – Lênin", 2 },
            { "Vật lý F1", 3 }
        };

        List<Tuple<string, int, float>> dsMonHoc = new List<Tuple<string, int, float>>();
    

        private void comboBoxNameSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNameSub.SelectedItem != null)
            {
                string tenMonHoc = comboBoxNameSub.SelectedItem.ToString();

                int soTinChi = monHoc[tenMonHoc];
                tbSoTinChi.Text = soTinChi.ToString();

            }
            else
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbDiem.Text) || !float.TryParse(tbDiem.Text, out float diem))
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxNameSub.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenMonHoc = comboBoxNameSub.SelectedItem.ToString();
            int soTinChi = monHoc[tenMonHoc];
            dsMonHoc.Add(new Tuple<string, int, float>(tenMonHoc, soTinChi, diem));

            lbDanhSach.Items.Add($"{tenMonHoc} - {soTinChi} tín chỉ - Điểm: {diem}");

          
        }

        private void buttonTinh_Click(object sender, EventArgs e)
        {
            if (dsMonHoc.Count == 0)
            {
                MessageBox.Show("Danh sách chưa có môn học nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            int tongSoTinChi = dsMonHoc.Sum(mh => mh.Item2);
            float tongDiem = dsMonHoc.Sum(mh => mh.Item2 * mh.Item3);
            float diemTrungBinh = tongDiem / tongSoTinChi;

            tbSoTinChi.Text = tongSoTinChi.ToString();
            tbDiemTrungBinh.Text = diemTrungBinh.ToString("0.00");

            int tongSoTin = 0;
            float tongSoDiem = 0;
            foreach(Tuple<string,int,float> tuple in dsMonHoc)
            {
                tongSoTin+= tuple.Item2;
                tongSoDiem+= tuple.Item3;
            }


            tbTongSoTinChi.Text = tongSoTin.ToString();
            tbTongSoDiem.Text = tongSoDiem.ToString();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
 
            if (e.Alt && e.KeyCode == Keys.H)
            {
                btnTinh.PerformClick();
            }

            if (e.Alt && e.KeyCode == Keys.D)
            {
                btnAddDs.PerformClick();
            }

            if (e.Alt && e.KeyCode == Keys.T)
            {
                btnThoat.PerformClick();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
