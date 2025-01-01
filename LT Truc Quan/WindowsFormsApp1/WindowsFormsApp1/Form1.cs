using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmWelcome : Form
    {
        
        public frmWelcome()
        {
            InitializeComponent();
            using (var workbook = new XLWorkbook()) ;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            txtWelcome.Text = "Welcome to Visual C#";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWelcome.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
