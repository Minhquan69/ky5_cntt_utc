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
    public partial class BTT1_2 : Form
    {
        public BTT1_2()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            txta.Text = "";
            txtb.Text = "";
            txtc.Text = "";
            txtKQ.Text = "";
            txta.Focus();
        }

        private void btnGiai_Click(object sender, EventArgs e)
        {
            if (txta.Text == "" || txtb.Text == "" || txtc.Text == "")
            {
                MessageBox.Show("Vui long nhap du a, b, c!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double a, b, c;
            if (!double.TryParse(txta.Text, out a) || !double.TryParse(txtb.Text, out b) || !double.TryParse(txtc.Text, out c))
            {
                MessageBox.Show("Vui long nhap gia tri hop le (phai la so).", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            a = double.Parse(txta.Text);
            b = double.Parse(txtb.Text);
            c = double.Parse(txtc.Text);

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

                    kq = "PT co 2 nghiem phan biet: \n" + "x1 = " + x1.ToString() + "\t" + "x2 = " + x2.ToString();

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

                txtKQ.Text = kq;
            }
        }
    }
}
