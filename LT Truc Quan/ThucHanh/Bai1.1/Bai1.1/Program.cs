using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong sinh vien: ");
            int soLuong = int.Parse(Console.ReadLine());

            DSSV danhSach = new DSSV(soLuong);

            danhSach.nhap();

            Console.WriteLine("\nDanh sach sinh vien:");
            danhSach.xuat();

          
            danhSach.TinhSoLuongSinhVien();

        }
    }
}
