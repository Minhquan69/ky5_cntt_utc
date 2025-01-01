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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;
            float x;
            string str = "A=    "   + nudA.Value.ToString() +",     b=" +  nudB.Value.ToString();
            a = Convert.ToInt16(nudA.Value);
            b = Convert.ToInt16(nudB.Value);
            if (a == 0)
            {
                if (b == 0)
                    str = str + ". Phương trình vô số nghiệm";
                else
                    str = str + ". Phương trình vô nghiệm";
            }
            else
            {
                x = (float)-b / a;
                str = str + ". Phương trình có một nghiệm là: x=" + x.ToString();
            }
            txtKetQua.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
