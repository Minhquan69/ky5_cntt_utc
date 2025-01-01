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
    public partial class TimKiem : Form
    {
        private List<NguoiGui> listNguoiGuis = new List<NguoiGui>();
        public TimKiem()
        {
            InitializeComponent();
            listNguoiGuis = StaticData._NguoiGui;
        }

        private void TimKiem_Load(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(txtTim.Text);
            NguoiGui khachHang = listNguoiGuis.FirstOrDefault(kh => kh.MaKH1 == maKH);

            if (khachHang != null)
            {
                txtTim.Text = $"Khách hàng {khachHang.TenKH1} phải trả {khachHang.Tien1} nghìn đồng";
            }
            else
            {
                txtTim.Text = $"Khách hàng {maKH} không có trong danh sách";
            }
        }
    }
}
