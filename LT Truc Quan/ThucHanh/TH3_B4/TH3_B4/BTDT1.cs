using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TH3_B4
{
    public partial class BTDT1 : Form
    {
        BaiTapDienTu bt = new BaiTapDienTu();

        public BTDT1(BaiTapDienTu baiTap)
        {
            InitializeComponent();
            bt = baiTap;
            rtbhienthi.Text = bt.Debai;
        }

        // Constructor mặc định
        public BTDT1()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            int diem = 0;
            string string1 = txt1.Text;

            if (string1.Equals(bt.Dapantungcau[0]))
            {
                txt1.BackColor = Color.Green;
                diem++;
            }
            else
            {
                txt1.BackColor = Color.Red;
            }

            if (txt2.Text.Equals(bt.Dapantungcau[1])) { txt2.BackColor = Color.Green; diem++; } else { txt2.BackColor = Color.Red; }
            if (txt3.Text.Equals(bt.Dapantungcau[2])) { txt3.BackColor = Color.Green; diem++; } else { txt3.BackColor = Color.Red; }
            if (txt4.Text.Equals(bt.Dapantungcau[3])) { txt4.BackColor = Color.Green; diem++; } else { txt4.BackColor = Color.Red; }
            if (txt5.Text.Equals(bt.Dapantungcau[4])) { txt5.BackColor = Color.Green; diem++; } else { txt5.BackColor = Color.Red; }
            if (txt6.Text.Equals(bt.Dapantungcau[5])) { txt6.BackColor = Color.Green; diem++; } else { txt6.BackColor = Color.Red; }
            if (txt7.Text.Equals(bt.Dapantungcau[6])) { txt7.BackColor = Color.Green; diem++; } else { txt7.BackColor = Color.Red; }
            if (txt8.Text.Equals(bt.Dapantungcau[7])) { txt8.BackColor = Color.Green; diem++; } else { txt8.BackColor = Color.Red; }
            if (txt9.Text.Equals(bt.Dapantungcau[8])) { txt9.BackColor = Color.Green; diem++; } else { txt9.BackColor = Color.Red; }
            if (txt10.Text.Equals(bt.Dapantungcau[9])) { txt10.BackColor = Color.Green; diem++; } else { txt10.BackColor = Color.Red; }

            MessageBox.Show($"Điểm của bạn là: {diem}", "Kết quả");
        }

        private void btndapan_Click(object sender, EventArgs e)
        {
            rtbhienthi.Text = bt.Dapan;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnlamlai_Click(object sender, EventArgs e)
        {
            foreach (Control control in gbdientu.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = control as TextBox;
                    txt.Text = ""; 
                    txt.BackColor = Color.White; 

                }

            }
            rtbhienthi.Text = bt.Debai;
        }

        private void rtbhienthi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
