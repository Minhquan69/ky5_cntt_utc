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
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void txtWelcome_TextChanged(object sender, EventArgs e)
        {

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
            if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            this.Close();
            
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {

        }
        private void frmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
