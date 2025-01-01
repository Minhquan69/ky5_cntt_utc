using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsApp2
{
    public static class StaticData
    {
        // Danh sách dùng chung giữa các Form để lưu trữ thông tin khách hàng
        public static List<NguoiGui> _NguoiGui = new List<NguoiGui>();
    }
}
