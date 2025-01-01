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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            txtCV.Text = (2 * 3.14 * double.Parse(txtBK.Text)).ToString();
            txtDT.Text = (3.14 * Math.Pow(double.Parse(txtBK.Text), 2)).ToString();

        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            txtBK.Text ="";
            txtCV.Text = "";
            txtDT.Text = "";
            txtBK.Focus();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
