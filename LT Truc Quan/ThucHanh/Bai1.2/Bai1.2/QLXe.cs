using System;
using System.Text;

namespace Bai1._2
{
    // Enum để định nghĩa các loại xe
    public enum LoaiXe
    {
        XeDuLich = 1,
        XeTai = 2
    }

    internal class QLXe
    {
        public string HoTen { get; set; }
        public LoaiXe LoaiXe { get; set; }
        public int SoGioThue { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap ho ten nguoi thue: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap loai xe (1 - Xe du lich ; 2 - Xe tai): ");
            int loaiXeInt = int.Parse(Console.ReadLine());
            LoaiXe = (LoaiXe)loaiXeInt;
            Console.Write("Nhap so gio thue: ");
            SoGioThue = int.Parse(Console.ReadLine());
        }

        public void xuat()
        {
            Console.WriteLine("Ho ten:" + HoTen);
            Console.WriteLine("Loai xe:" + LoaiXe);
            Console.WriteLine("So gio thue:" + SoGioThue);
            Console.WriteLine("Tong tien:" + TinhTien());
        }

        public double TinhTien()
        {
            double giaCoBan = LoaiXe == LoaiXe.XeDuLich ? 250000 : 220000;
            double giaTungGio = LoaiXe == LoaiXe.XeDuLich ? 70000 : 85000;

            if (SoGioThue <= 1)
                return giaCoBan;
            return giaCoBan + (SoGioThue - 1) * giaTungGio;
        }
    }
}
