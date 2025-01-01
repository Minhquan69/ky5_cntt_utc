using BTTH5.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTH5
{
    public partial class frmMain : Form
    {
        public string tenNhanVien { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        void LoadData()
        {
            danhMụcToolStripMenuItem.Enabled = false;
            bánHàngToolStripMenuItem.Enabled=false;
            thốngKêToolStripMenuItem.Enabled=false;
            hệThốngToolStripMenuItem.Enabled = true;
            đăngXuấtToolStripMenuItem.Enabled = false;
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            Forms.frmChatLieu chatLieu = new Forms.frmChatLieu();
            chatLieu.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmSanPham frmSp = new Forms.frmSanPham(tenNhanVien);
            frmSp.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmDangNhap frmSp = new Forms.frmDangNhap(this);
            frmSp.ShowDialog();
           
        }


        public void EnableMenuItems()
        {
            danhMụcToolStripMenuItem.Enabled = true;
            bánHàngToolStripMenuItem.Enabled = true;
            thốngKêToolStripMenuItem.Enabled = true;
            hệThốngToolStripMenuItem.Enabled = true;
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmDangNhap frmDN = new frmDangNhap(this);

            frmDN.ShowDialog();

            this.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHoaDon frmhd = new Forms.frmHoaDon();
            frmhd.ShowDialog();
        }
    }
}
