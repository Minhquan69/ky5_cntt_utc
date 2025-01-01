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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string thongbao = "";
        private void lstDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            clbMonAn.MultiColumn = true;
            //Cho phép hiển thị trên 2 cột 
            clbMonAn.ColumnWidth = clbMonAn.Width / 2;
            //Thêm các phần tử vào CheckedListBox 
            clbMonAn.Items.Add("Ba chỉ cuốn nắm");
            clbMonAn.Items.Add("Ba chỉ luộc chấm mắm tép");
            clbMonAn.Items.Add("Thịt gà rang muối");
            clbMonAn.Items.Add("Thịt gà nướng");
            clbMonAn.Items.Add("Bê nướng");
            clbMonAn.Items.Add("Chả cá lã vọng");
            clbMonAn.Items.Add("Bún ốc");
            clbMonAn.Items.Add("Cháo chim bồ câu");
            clbMonAn.Items.Add("Cháo sườn");
            clbMonAn.Items.Add("Đậu rán");
            clbMonAn.Items.Add("Rau muống xào tỏi");
            clbMonAn.Items.Add("Rau bí ngô luộc");

            String[] forder;
            forder = System.IO.Directory.GetDirectories("E:\\LT Truc Quan");
            cboThumuc.DataSource = forder;

            int i;
            //Cho phép hiển thị trên nhiều cột 
            lstDanhSach.MultiColumn = true;
            //Hiển thị trên 4 cột             
            lstDanhSach.ColumnWidth = lstDanhSach.Width / 4;
            //Cho phép chọn đồng thời nhiều phần tử 
            lstDanhSach.SelectionMode = SelectionMode.MultiSimple;
            //Add dữ liệu vào hộp danh sách 
            for (i = 1; i <= 100; i++)
                lstDanhSach.Items.Add("Item " + i.ToString());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (string item in lstDanhSach.SelectedItems)
            {
                thongbao = thongbao + item + ", ";
            }
            //Xóa dấu phẩy và dấu cách thừa ở cuối chuỗi 
            thongbao = thongbao.Remove(thongbao.Length - 2, 2);
            MessageBox.Show("Bạn đã chọn các phần tử : " + thongbao,
            "Thông báo", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void clbMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (string item in clbMonAn.CheckedItems)
                str = str + item + ", ";
            //Xóa dấu phẩy và dấu cách thừa cuối chuỗi 
            str = str.Remove(str.Length - 2, 2);
            MessageBox.Show("Bạn đã chọn các món sau: " + str);
        }

        private void clbMonAn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                MessageBox.Show("Bạn vừa chọn thêm món: " + clbMonAn.SelectedItem,
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
