using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THBuoi1_Baitap3
{
    public partial class FormBT3 : Form
    {
        public FormBT3()
        {
            InitializeComponent();
        }

        private void buttonGPT_Click(object sender, EventArgs e)
        {
            if (textBoxNhapA.Text == "" || textBoxNhapB.Text == "" || textBoxNhapC.Text == "")
            {
                MessageBox.Show("Vui long nhap du a, b, c!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }         
            
            double a, b, c;
            if (!double.TryParse(textBoxNhapA.Text, out a) || !double.TryParse(textBoxNhapB.Text, out b) || !double.TryParse(textBoxNhapC.Text, out c))
            {
                MessageBox.Show("Vui long nhap gia tri hop le (phai la so).", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            a = double.Parse(textBoxNhapA.Text);
            b = double.Parse(textBoxNhapB.Text);
            c = double.Parse(textBoxNhapC.Text);

            if (a == 0)
            {
                MessageBox.Show("Ban phai nhap a khac 0.");
                return;
            }

            else
            {
                double x1, x2, delta;
                string kq;
                delta = b * b - (4 * a * c);
                if (delta > 0)
                {
                    x1 = Math.Round((-b + Math.Sqrt(delta)) / (2 * a), 2);
                    x2 = Math.Round((-b - Math.Sqrt(delta)) / (2 * a), 2);

                    kq = "PT co 2 nghiem phan biet:\n" + "x1 = " + x1.ToString() + "\t" + "x2 = " + x2.ToString();

                }
                else if (delta == 0)
                {
                    x1 = Math.Round(-b / (2 * a), 2);
                    kq = "PT co nghiem kep:\n" + "x1 = x2 = " + x1.ToString();

                }
                else
                {
                    kq = "Phuong trinh vo nghiem";
                }

                textBoxKQ.Text = kq;
            }    

        }

        private void buttonLL_Click(object sender, EventArgs e)
        {
            textBoxNhapA.Text = "";
            textBoxNhapB.Text = "";
            textBoxNhapC.Text = "";
            textBoxKQ.Text = "";
            textBoxNhapA.Focus();

        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat khong?", "Xac nhan thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == System.Windows.Forms.DialogResult.Yes)
                this.Close();

        }
    }
}
