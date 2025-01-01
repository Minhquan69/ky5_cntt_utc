using System;

namespace Bai1._0
{
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap so luong thi sinh: ");
            int soLuong = int.Parse(Console.ReadLine());

            TuyenSinh ts = new TuyenSinh(soLuong);

            ts.Nhap();

            Console.Write("Nhap diem chuan: ");
            double diemChuan = double.Parse(Console.ReadLine());

            ts.XuatDanhSachTrungTuyen(diemChuan);
           
        }
    }
}
