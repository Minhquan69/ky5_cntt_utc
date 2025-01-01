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
    public partial class BTT1_1 : Form
    {
        public BTT1_1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            double x1, x2, y1, y2;
            x1 = double.Parse(txtx1.Text);
            y1 = double.Parse(txty1.Text);
            x2 = double.Parse(txtx2.Text);
            y2 = double.Parse(txty2.Text);
            double hsg, kc;
            hsg = (y2 - y1) / (x2 - x1);
            kc = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            txtHSG.Text = hsg.ToString();
            txtKC.Text = kc.ToString();
        }
    }
}
