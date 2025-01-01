using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THBuoi1_Baitap2
{
    public partial class FormPoint : Form
    {
        public FormPoint()
        {
            InitializeComponent();
        }

        private void buttonTT_Click(object sender, EventArgs e)
        {
            double x1, x2, y1, y2;
            x1 = double.Parse(tB_PointX1.Text);
            y1 = double.Parse(tB_PointY1.Text);
            x2 = double.Parse(tB_PointX2.Text);
            y2 = double.Parse(tB_PointY2.Text);
            double hsg, kc;
            hsg = (y2 - y1) / (x2-x1);
            kc = Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2)) ;
            textBoxHSG.Text = hsg.ToString();
            textBoxKC.Text = kc.ToString();
        }
    }
}
