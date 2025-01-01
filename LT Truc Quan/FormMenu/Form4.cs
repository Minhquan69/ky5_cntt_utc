using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMenu
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            int[] dapAn = { 90, 22, 45, 61, 24, 90, 54, 75, 18, 26 }; // Đáp án đúng


            for (int i = 0; i < 10; i++)
            {
                TextBox txtBox = this.Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (txtBox != null && int.TryParse(txtBox.Text, out int cauTraLoi))
                {
                    if (cauTraLoi == dapAn[i])
                    {
                        txtBox.BackColor = Color.Green; // Đúng

                    }
                    else
                    {
                        txtBox.BackColor = Color.Red; // Sai
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] dapAn = { 90, 22, 45, 61, 24, 90, 54, 75, 18, 26 }; // Đáp án đúng
            for (int i = 0; i < 10; i++)
            {
                TextBox txtBox = this.Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (txtBox != null)
                {
                    txtBox.Text = dapAn[i].ToString();
                }
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                TextBox txtBox = this.Controls.Find($"textBox{i + 1}", true).FirstOrDefault() as TextBox;
                if (txtBox != null)
                {
                    txtBox.Text = string.Empty;
                    txtBox.BackColor = SystemColors.Window; // Trả lại màu nền mặc định
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
        }
    }
}
